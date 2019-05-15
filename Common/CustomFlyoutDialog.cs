using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.XtraBars.Docking2010.Customization;
using DevExpress.XtraBars.Docking2010.Views.WindowsUI;
using System.Windows.Forms;
using ARM_User;

namespace BSB.Common.DB
{
    public class CustomFlyoutDialog: FlyoutDialog
    {
        public CustomFlyoutDialog(MainForm owner, FlyoutAction actions, Control UserControleToShow)
            :base(owner,actions)
        {
            this.Properties.HeaderOffset = 0;
            this.Properties.Alignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.Properties.Style = FlyoutStyle.Popup;
            
            this.FlyoutControl = UserControleToShow;
            /*this.LookAndFeel.SkinName = owner.defaultLookAndFeel.LookAndFeel.SkinName;
            this.LookAndFeel.Style = owner.defaultLookAndFeel.LookAndFeel.Style;*/
        }
        public static DialogResult ShowForm(MainForm owner, FlyoutAction actions, Control UserControlToShow)
        {
            
            CustomFlyoutDialog customFlyout = new CustomFlyoutDialog(owner, actions, UserControlToShow);
            return customFlyout.ShowDialog();

        }
    }
}
