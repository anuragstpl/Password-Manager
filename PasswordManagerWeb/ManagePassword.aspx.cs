using DataLayer.DataHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PasswordManagerWeb
{
    public partial class ManagePassword : System.Web.UI.Page
    {
        UserHelper userHelper = new UserHelper();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSaveEditPwd_Click(object sender, EventArgs e)
        {
            EntityLayer.User user = new EntityLayer.User();
            user.Password = txtPassword.Text;
            user.oldPassword = txtOldPassword.Text;
            user.UserID = Convert.ToInt32(Session["UserID"]);
            lblMessage.Text = userHelper.UpdatePassword(user);
        }
    }
}