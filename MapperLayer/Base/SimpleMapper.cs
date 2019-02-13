using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using ARM_User.BusinessLayer.Common;
using ARM_User.DataLayer;
using ARM_User.DataLayer.Cache;
using BSB.Common.DataGateway;

namespace ARM_User.MapperLayer.Common
{
  public abstract class SimpleMapper<ObjectType, ObjectListType, TableType, RowType>
    : AbstractMapper, ISimpleFinder<ObjectType, ObjectListType>, ISimpleFinder
    where ObjectType : DomainObject
    where ObjectListType : DOList<ObjectType>, new()
    where TableType : DataTable, new()
    where RowType : DataRow
  {
    protected bool allowCacheChild = false;

    protected virtual IDataGateway Gateway
    {
      get { return DataGatewayFactoryHolder.CacheFactory.GetGateway(typeof (TableType)); }
    }

    protected abstract ObjectType CreateByRow(RowType row);

    public virtual Type GetTypeOfObjectType(RowType row)
    {
      return typeof (ObjectType);
    }

    protected virtual void MarkAsNeedLoad()
    {
      CacheManager.Instance.MarkAsNeedLoad(typeof (TableType));
    }

    protected virtual List<ObjectType> FindByTableLoader(TableLoader tabLoader, bool forceRewrite)
    {
      var objList = new List<ObjectType>();
      List<ObjectType> objListForCacheChild;
      objListForCacheChild = new List<ObjectType>();

      tabLoader.Gateway = Gateway;
      var rows = tabLoader.CreateAndLoad();

      foreach (RowType row in rows)
      {
        decimal id = Convert.ToInt64(row[IdName()]);
        var obj = (ObjectType) UnitOfWork.Instance.FindObject(GetTypeOfObjectType(row), id, false);
        if (obj == null)
        {
          if (!UnitOfWork.Instance.IsObjectRegisteredAsRemoved(GetTypeOfObjectType(row), id, false))
          {
            obj = CreateByRow(row);
            if (obj != null)
            {
              UnitOfWork.Instance.RegisterClean(obj);
              if (allowCacheChild)
                objListForCacheChild.Add(obj);
            }
          }
        }
        else
        {
          decimal ver = 0; 
          if (row.Table.Columns.Contains("VER"))
            ver = (decimal) row["VER"];
         // if (ver != obj.Ver || forceRewrite)
          //{
            if (obj.State == DOState.Clean)
            {
              var objNew = CreateByRow(row);
              if (objNew != null)
              {
                objNew.SetState(DOState.Clean);
                objNew.CopyTo(obj);
                if (allowCacheChild)
                  objListForCacheChild.Add(obj);
              }
            }
            else if (obj.State == DOState.Dirty)
            {
              //throw new ApplicationException("Измененная запись была отредактированна другим пользователем");
            }
          //}
        }

        if (obj != null)
          objList.Add(obj);
      }

      if (allowCacheChild && objListForCacheChild.Count > 0)
        CacheChild(objListForCacheChild);

      return objList;
    }

    protected virtual void CacheChild(List<ObjectType> objListForCacheChild)
    {
    }

    protected ObjectListType FindBy(string fieldName, decimal idParent)
    {
      var objList = new ObjectListType();
      objList.Loader = new VLLoader(new ByFieldTableLoader(fieldName, idParent), this);
      return objList;
    }

    protected ObjectListType FindBy(string fieldName, decimal idParent, string sort)
    {
      var objList = new ObjectListType();
      objList.Loader = new VLLoader(new ByFieldTableLoader(fieldName, idParent, sort), this);
      return objList;
    }

    protected ObjectListType FindByParent(decimal idParent)
    {
      var objList = new ObjectListType();
      objList.Loader = new VLLoader(new ByParentTableLoader(idParent), this);
      return objList;
    }

    #region ISimpleFinder<ObjectType,ObjectListType> Members

    public virtual ObjectType Find(decimal id)
    {
      var obj = (ObjectType) UnitOfWork.Instance.FindObject(typeof (ObjectType), id, true);
      if (obj != null)
      {
        return obj;
      }
      if (!UnitOfWork.Instance.IsObjectRegisteredAsRemoved(typeof (ObjectType), id, true))
      {
        try
        {
          var objList = FindByTableLoader(new OneRowTableLoader(id), false);
          if (objList != null && objList.Count == 1)
            return objList[0];
          return null;
        }
        catch (NotSupportedException)
        {
          FindAll().GetSource();
            // GetSource вызывается для того, чтобы был загружен виртуальный список. Иначе будет бесконечная рекурсия
          obj = (ObjectType) UnitOfWork.Instance.FindObject(typeof (ObjectType), id, true);
          return obj;
        }
      }
      return null;
    }

    public virtual ObjectListType FindAll()
    {
      var objList = new ObjectListType();
      objList.Loader = new VLLoader(new AllRowsTableLoader(), this);
      return objList;
    }

    public virtual void Refresh(decimal id)
    {
      var objList = new ObjectListType();
      objList.Loader = new VLLoader(new OneRowTableLoader(id), this, true);
      objList.GetSource();
    }

    #endregion

    #region ISimpleFinder Members

    DomainObject ISimpleFinder.Find(decimal id)
    {
      return Find(id);
    }

    IDOList ISimpleFinder.FindAll()
    {
      return FindAll();
    }

    void ISimpleFinder.Refresh(decimal id)
    {
      Refresh(id);
    }

    #endregion

    #region Table Loaders Classes

    public abstract class TableLoader
    {
      public IDataGateway Gateway;
      public abstract ICollection CreateAndLoad();
    }

    public class OneRowTableLoader : TableLoader
    {
      private readonly decimal id;

      public OneRowTableLoader(decimal id)
      {
        this.id = id;
      }

      public override ICollection CreateAndLoad()
      {
        var gw = Gateway; //DataGatewayFactoryHolder.CacheFactory.GetGateway(typeof(TableType));
        var tab = new TableType();

        gw.Load(id, tab);

        return tab.Rows;
      }
    }

    public class AllRowsTableLoader : TableLoader
    {
      public override ICollection CreateAndLoad()
      {
        var gw = Gateway; //DataGatewayFactoryHolder.CacheFactory.GetGateway(typeof(TableType));
        var tab = new TableType();
        gw.Load(tab);
        return tab.Rows;
      }
    }

    public class ByFieldTableLoader : TableLoader
    {
      private readonly string fieldName;
      private readonly decimal idParent;
      private readonly string sort;

      public ByFieldTableLoader(string fieldName, decimal idParent)
      {
        this.fieldName = fieldName;
        this.idParent = idParent;
      }

      public ByFieldTableLoader(string fieldName, decimal idParent, string sort)
        : this(fieldName, idParent)
      {
        this.sort = sort;
      }

      public override ICollection CreateAndLoad()
      {
        var gw = Gateway; //DataGatewayFactoryHolder.CacheFactory.GetGateway(typeof(TableType));
        var tab = new TableType();
        gw.Load(tab);
        return tab.Select(fieldName + " = " + idParent, sort);
      }
    }

    public class ByParentTableLoader : TableLoader
    {
      private readonly decimal idParent;

      public ByParentTableLoader(decimal idParent)
      {
        this.idParent = idParent;
      }

      public override ICollection CreateAndLoad()
      {
        var gw = Gateway; //DataGatewayFactoryHolder.CacheFactory.GetGateway(typeof(TableType));
        if (!(gw is IChildDataGateway))
          throw new NotSupportedException();

        var cgw = (IChildDataGateway) gw;

        var tab = new TableType();
        cgw.LoadByParent(idParent, tab);
        return tab.Rows;
      }
    }

    public class ByParentGroupTableLoader : TableLoader
    {
      private readonly decimal[] idParents;

      public ByParentGroupTableLoader(decimal[] idParents)
      {
        this.idParents = idParents;
      }

      public override ICollection CreateAndLoad()
      {
        var gw = Gateway; //DataGatewayFactoryHolder.CacheFactory.GetGateway(typeof(TableType));
        if (!(gw is IChildGroupDataGateway))
          throw new NotSupportedException();

        var cgw = (IChildGroupDataGateway) gw;

        var tab = new TableType();
        cgw.LoadByParents(idParents, tab);
        return tab.Rows;
      }
    }

    //public class ComplexTableLoader : TableLoader
    //{
    //  protected List<TableLoader> listTableLoaders;

    //  public ComplexTableLoader(params TableLoader[] listTableLoaders)
    //  {
    //    this.listTableLoaders = new List<TableLoader>(listTableLoaders);
    //  }

    //  public override ICollection CreateAndLoad()
    //  {
    //    ArrayList list = new ArrayList();
    //    foreach(TableLoader loader in listTableLoaders)
    //      list.AddRange(loader.CreateAndLoad());
    //    return list;
    //  }
    //}

    #endregion

    #region Virtual List Loader classes

    public class VLLoader : IVirtualListLoader<ObjectType>
    {
      private readonly bool forceRewrite;
      private readonly SimpleMapper<ObjectType, ObjectListType, TableType, RowType> mapper;
      private readonly TableLoader tabLoader;

      public VLLoader(TableLoader tabLoader, SimpleMapper<ObjectType, ObjectListType, TableType, RowType> mapper)
        : this(tabLoader, mapper, false)
      {
      }

      public VLLoader(TableLoader tabLoader, SimpleMapper<ObjectType, ObjectListType, TableType, RowType> mapper,
        bool forceRewrite)
      {
        this.tabLoader = tabLoader;
        this.mapper = mapper;
        this.forceRewrite = forceRewrite;
      }

      #region IVirtualListLoader<ObjectType> Members

      public List<ObjectType> Load()
      {
        return mapper.FindByTableLoader(tabLoader, forceRewrite);
      }

      #endregion
    }

    public class VLComplexLoader : IVirtualListLoader<ObjectType>
    {
      private bool forceRewrite;
      private readonly VLLoader[] vlLoaders;

      public VLComplexLoader(bool forceRewrite, params VLLoader[] vlLoaders)
      {
        this.forceRewrite = forceRewrite;
        this.vlLoaders = vlLoaders;
      }

      #region IVirtualListLoader<ObjectType> Members

      public List<ObjectType> Load()
      {
        var list = new List<ObjectType>();
        foreach (var vlLoader in vlLoaders)
          list.AddRange(vlLoader.Load());
        return list;
      }

      #endregion
    }

    #endregion
  }
}