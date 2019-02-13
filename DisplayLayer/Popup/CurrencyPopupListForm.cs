﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ARM_User.BusinessLayer.Guides;
using ARM_User.MapperLayer.Common;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;



namespace ARM_User.DisplayLayer.Guides.PopupList
{
    public partial class CurrencyPopupListForm: ARM_User.DisplayLayer.Base.ChoiceBaseForm
    {
        
        public CurrencyPopupListForm()
        {
            InitializeComponent();
        }

        private void CurrencyPopupListForm_Load(object sender, EventArgs e)
        {
            try
            {
                MainBS.DataSource = MapperRegistry.Instance.GetCurrencyECBMapper().FindByCondition(2);
                gridMain.DataSource = MainBS;
            }
            catch (Exception ex)
            {
                var rethrow = ExceptionPolicy.HandleException(ex, "Display Policy");
                if (rethrow)
                    throw;
            }
        }
        
       
    }
}
