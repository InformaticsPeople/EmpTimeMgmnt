using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Linq;
using Microsoft.SharePoint.Administration;
using System;
using Microsoft.SharePoint.Utilities;
using Microsoft.SharePoint;
using System.Collections.Generic;

namespace EmpTimeMgmnt.WebParts.EmpTimeWP
{
    public partial class EmpTimeWPUserControl : UserControl
    {
        ObjectDataSource gridDS = null;
        /// <summary>
        /// n the Page_Load event we are declaring the GridView Object, its event and Datasource
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                if (!Page.IsPostBack)
                {
                    BinData();
                }
              
            }
            catch (Exception ex)
            {
                //log
                SPDiagnosticsService diagnosticsService = SPDiagnosticsService.Local;
                SPDiagnosticsCategory cat = diagnosticsService.Areas["SharePoint Foundation"].Categories["Unknown"];
                diagnosticsService.WriteTrace(1, cat, TraceSeverity.Medium, ex.StackTrace, cat.Name, cat.Area.Name);
                SPUtility.TransferToErrorPage("Some Error occured, Please try after some time. <br/> If problem persists, contact your adminstrator");
            }

        }
        public void BinData()
        {

            DataTable dt1 = new DataTable();
            dt1.Columns.Add("Category", typeof(string));
            dt1.Columns.Add("ID", typeof(string));
            DataTable dtdata = new DataTable();
            dtdata.Columns.Add("ID", typeof(int));
            dtdata.Columns.Add("Title", typeof(string));
            dtdata.Columns.Add("Description", typeof(string));
            dtdata.Columns.Add("Category", typeof(string));
            dtdata.Columns.Add("Created", typeof(string));
            SPFieldMultiChoiceValue choices = new SPFieldMultiChoiceValue();
            using (SPSite objSPSite = new SPSite(SPContext.Current.Web.Url))
            {
                using (SPWeb objSPWeb = objSPSite.OpenWeb())
                {
                    SPList objSPList = objSPWeb.Lists.TryGetList("Cygnet");
                    SPListItemCollection listItems = objSPList.GetItems();
                    foreach (SPItem item in listItems)
                    {

                        //choices = new SPFieldMultiChoiceValue(item["Category"].ToString());
                        //for (int i = 0; i < choices.Count; i++)
                        //{
                        //    dt1.Rows.Add(choices[i], choices[i]);
                        //}
                        //ddlcategory.Items.Clear();
                        //ddlcategory.DataSource = dt1;
                        //ddlcategory.DataTextField = "Category";
                        //ddlcategory.DataValueField = "Category";
                        //ddlcategory.DataBind();
                        DataRow dr = dtdata.NewRow();
                        dr["ID"] = Convert.ToInt16(item["ID"]);
                        dr["Title"] = item["Title"].ToString();
                        dr["Description"] = item["Description"].ToString();
                        dr["Category"] = item["Category"].ToString();
                        dtdata.Rows.Add(dr);
                    }
                    gvListData.DataSource = dtdata;
                    gvListData.DataBind();
                }
            }
        }
        protected void btnDeleteListItem_Click(object sender, EventArgs e)
        {
            using (SPSite objSPSite = new SPSite(SPContext.Current.Web.Url))
            {
                using (SPWeb objSPWeb = objSPSite.OpenWeb())
                {
                    bool allowUnsafeUpdate = objSPWeb.AllowUnsafeUpdates;
                    SPList objSPList = objSPWeb.Lists.TryGetList("Cygnet");
                    if (objSPList != null)
                    {
                        objSPWeb.AllowUnsafeUpdates = true;
                        SPListItem objSPListItem = objSPList.GetItemById(Convert.ToInt16(txtTitle.Text.Trim()));
                        objSPListItem.Delete();
                        lblResult.Text = "Item with ID: " + txtTitle.Text + " deleted successfuly.";
                        objSPWeb.AllowUnsafeUpdates = allowUnsafeUpdate;
                    }
                    else
                    {
                        lblResult.Text = "The list is not exists.";
                    }
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            //usig -dspose obje
            using (SPSite objSPSite = new SPSite(SPContext.Current.Web.Url))
            {
                using (SPWeb objSPWeb = objSPSite.OpenWeb())
                {
                    bool allowUnsafeUpdate = objSPWeb.AllowUnsafeUpdates;
                    SPList objSPList = objSPWeb.Lists.TryGetList("Cygnet");
                    if (objSPList != null)
                    {
                        objSPWeb.AllowUnsafeUpdates = true;
                        SPListItem objSPListItem = objSPList.Items.Add();
                        objSPListItem["Title"] = Convert.ToString(txtTitle.Text.Trim());
                        objSPListItem["Description"] = Convert.ToString(txtDescription.Text.Trim());
                        objSPListItem["Category"] = Convert.ToString(ddlcategory.SelectedItem.Text);                      
                        objSPListItem.Update();
                        lblResult.Text = "Submitted successfully.";
                        Clear();
                        BinData();
                        objSPWeb.AllowUnsafeUpdates = allowUnsafeUpdate;
                    }
                    else
                    {
                        lblResult.Text = "The list is not exists.";
                    }
                }
            }
        }
        void Clear()
        {
            txtTitle.Text = "";
            txtDescription.Text = "";
            ddlcategory.SelectedIndex = 0;            
        }
    }
}
