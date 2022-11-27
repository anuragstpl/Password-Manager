using DataLayer.DataHelper;
using DataLayer.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PasswordManagerWeb
{
    public partial class Register : System.Web.UI.Page
    {
        UserHelper userHelper = new UserHelper();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSignUp_Click(object sender, EventArgs e)
        {
            EntityLayer.User usr = new EntityLayer.User();
            usr.Email = txtEmail.Text;
            usr.FirstName = txtFName.Text;
            usr.LastName = txtLName.Text;
            usr.Password = txtPassword.Text;
            usr.Username = txtUserName.Text;

            bool isAdded = userHelper.RegisterUser(usr);
            if (isAdded)
            {
                Response.Write("<script>alert('User saved successfully.');</script>");
            }
            else
            {
                Response.Write("<script>alert('Some error occured.');</script>");
            }

        }

        protected void btnSignin_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}