using DataLayer.DataHelper;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PasswordManagerWeb
{
    public partial class AccountManagement : System.Web.UI.Page
    {
        AccountHelper accHelper = new AccountHelper();
        protected void Page_Load(object sender, EventArgs e)
        {
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

        protected void btnAddAccount_Click(object sender, EventArgs e)
        {
            if (Session["EditAccountID"] == null)
            {
                AccountData accData = new AccountData();
                accData.AddedBy = Convert.ToInt32(Session["UserID"]);
                accData.Description = txtDescription.Text;
                accData.Name = txtName.Text;
                if (accHelper.AddAccount(accData))
                {
                    lblMessage.Text = "Account added successfully.";
                    lblMessage.ForeColor = Color.Green;
                    this.BindAccounts();
                }
                else
                {
                    lblMessage.Text = "Some error occured.";
                    lblMessage.ForeColor = Color.Red;
                }
            }
            else
            {
                AccountData accData = new AccountData();
                accData.AddedBy = Convert.ToInt32(Session["UserID"]);
                accData.Description = txtDescription.Text;
                accData.Name = txtName.Text;
                accData.AccountID = Convert.ToInt32(Session["EditAccountID"]);
                if (accHelper.UpdateAccount(accData))
                {
                    lblMessage.Text = "Account updated successfully.";
                    lblMessage.ForeColor = Color.Green;
                    this.BindAccounts();
                    Session["EditAccountID"] = null;
                    btnAddAccount.Text = "Add Account";
                }
                else
                {
                    lblMessage.Text = "Some error occured.";
                    lblMessage.ForeColor = Color.Red;
                }
            }

        }

        protected void lstAccount_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            (lstAccount.FindControl("DataPager1") as DataPager).SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            this.BindAccounts();
        }

        protected void lstAccount_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                if (accHelper.DeleteAccount(Convert.ToInt32(e.CommandArgument)))
                {
                    lblMessage.Text = "Account deleted successfully.";
                    lblMessage.ForeColor = Color.Green;
                    this.BindAccounts();
                }
                else
                {
                    lblMessage.Text = "Some error occured.";
                    lblMessage.ForeColor = Color.Red;
                }
            }
            else
                if (e.CommandName == "Edit")
                {
                    AccountData accData = accHelper.GetAccountsByID(Convert.ToInt32(e.CommandArgument));
                    txtDescription.Text = accData.Description;
                    txtName.Text = accData.Name;
                    Session["EditAccountID"] = accData.AccountID;
                    btnAddAccount.Text = "Update Account";
                }
        }

        protected void lstAccount_ItemDeleting(object sender, ListViewDeleteEventArgs e)
        {

        }

        protected void lstAccount_ItemEditing(object sender, ListViewEditEventArgs e)
        {

        }
    }
}