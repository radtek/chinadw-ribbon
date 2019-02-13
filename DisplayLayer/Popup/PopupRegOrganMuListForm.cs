using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using ARM_User.MapperLayer.Common;
using System.Windows.Forms;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;

namespace ARM_User.DisplayLayer.Popup
{
    public partial class PopupRegOrganMuListForm : ARM_User.DisplayLayer.Base.ChoiceTreeBaseForm
    {
        public PopupRegOrganMuListForm()
        {
            InitializeComponent();
        }

        private void PopupRegOrganMuListForm_Load(object sender, EventArgs e)
        {
            try
            {
                MainBS.DataSource = MapperRegistry.Instance.GetRegOrganMUMapper().FindAll();
                treeMain.DataSource = MainBS;
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
