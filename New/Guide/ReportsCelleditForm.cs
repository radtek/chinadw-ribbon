using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ARM_User.New.Guide
{
    public partial class ReportsCelleditForm : ARM_User.DisplayLayer.Base.SimpleEditForm
    {
    # region [field]
            public String HTMLText;
    #endregion
        public ReportsCelleditForm()
        {
            InitializeComponent();
        }

        private void DialogHTMLCelleditForm_Load(object sender, EventArgs e)
        {
            richTextBox1.Text = HTMLText;
        }
    }
}
