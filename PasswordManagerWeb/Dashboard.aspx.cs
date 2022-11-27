using DataLayer.DataHelper;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PasswordManagerWeb
{
    public partial class Dashboard : System.Web.UI.Page
    {
        PasswordHelper passHelper = new PasswordHelper();
        AccountHelper accHelper = new AccountHelper();
        protected void Page_Load(object sender, EventArgs e)
        {
            List<SocialMediaData> lstOldPwdData = passHelper.GetAgedPassword(Convert.ToInt32(Session["UserID"]));
            if (lstOldPwdData.Count > 0)
            {
                foreach (SocialMediaData item in lstOldPwdData)
                {
                    ltrNotification.Text += "<div class='alert alert-warning'><a href='#' class='close' data-dismiss='alert'>&times;</a> <strong>Password Change !</strong> Your password for " + item.Type + " is older more than 90 days. <a href='PasswordManager.aspx?type=" + item.Type + "'>Click Here</a> to change it. </div>";
                }
            }
            if (!this.IsPostBack)
            {
                this.BindAccounts();
            }
        }

        private void BindAccounts()
        {
            List<EntityLayer.AccountData> lstPatient = accHelper.GetAllAccountsByUserID(Convert.ToInt32(Session["UserID"]));
            lstAccount.DataSource = lstPatient;
            lstAccount.DataBind();
        }

        protected void lstAccount_ItemEditing(object sender, ListViewEditEventArgs e)
        {

        }

        protected void lstAccount_ItemDeleting(object sender, ListViewDeleteEventArgs e)
        {

        }

        protected void lstAccount_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "ManagePwd")
            {
                Response.Redirect("PasswordManager.aspx?type="+e.CommandArgument.ToString());
            }
        }

        protected void lstAccount_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {

        }
    }
}