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
    public partial class PasswordManager : System.Web.UI.Page
    {
        PasswordHelper passHelper = new PasswordHelper();
        AccountHelper accHelper = new AccountHelper();
        protected void Page_Load(object sender, EventArgs e)
        {
            string type = Request.QueryString["type"];
            if (!Page.IsPostBack)
            {
                LoadCredentials();
            }

        }

        public void LoadCredentials()
        {

            int type = Convert.ToInt32(Request.QueryString["type"]);
            AccountData actData = accHelper.GetAccountsByID(Convert.ToInt32(Request.QueryString["type"]));
            SocialMediaData socialData = passHelper.GetSavedCredentials(type, Convert.ToInt32(Session["UserID"]));
            lblType.Text = actData.Name;
            if (socialData != null)
            {
                txtPassword.Attributes.Add("value", socialData.Password);
                txtConfirmPAssword.Attributes.Add("value", socialData.Password);
            }
        }

        protected void btnSaveEditPwd_Click(object sender, EventArgs e)
        {
            int type = Convert.ToInt32(Request.QueryString["type"]);
            SocialMediaData socialData = passHelper.GetSavedCredentials(type, Convert.ToInt32(Session["UserID"]));
            if (socialData.SocialMediaID == 0)
            {
                socialData.Password = txtPassword.Text;
                socialData.Type = type;
                socialData.UserID = Convert.ToInt32(Session["UserID"]);
                socialData.Createdon = DateTime.Now.ToString();
                if (passHelper.AddCredentials(socialData))
                {
                    Response.Write("<script>alert('Password saved successfully.');</script>");
                    LoadCredentials();
                }
                else
                {
                    Response.Write("<script>alert('Some error occured.');</script>");
                }
            }
            else
            {
                socialData.Password = txtPassword.Text;
                socialData.Type = type;
                if (passHelper.UpdateCredentials(socialData))
                {
                    Response.Write("<script>alert('Password updated successfully.');</script>");
                    LoadCredentials();
                }
                else
                {
                    Response.Write("<script>alert('Some error occured.');</script>");
                }
            }
        }
    }
}