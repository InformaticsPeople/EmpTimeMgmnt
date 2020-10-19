using System;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;

namespace EmpTimeMgmnt.WebParts.EmpTimeWP
{
    [ToolboxItemAttribute(false)]
    public class EmpTimeWP : WebPart
    {
        // Visual Studio might automatically update this path when you change the Visual Web Part project item.
        private const string _ascxPath = @"~/_CONTROLTEMPLATES/15/EmpTimeMgmnt.WebParts/EmpTimeWP/EmpTimeWPUserControl.ascx";

        //constructor create while loading trigger to none title
       public EmpTimeWP()
        {
             //this will none for title of webpart
            ChromeType = PartChromeType.None;
        }
        protected override void CreateChildControls()
        {
            Control control = Page.LoadControl(_ascxPath);
            Controls.Add(control);
        }
    }
}
