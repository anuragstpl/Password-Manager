using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PasswordManagerWeb
{
    public partial class ComplianceMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
               // txtName.Text = Session["Name"].ToString();
            }
            
        }

        protected void lnkLogout_Click(object sender, EventArgs e)
        {
            Session["UserID"] = null;
            Response.Redirect("Login.aspx");
        }
    }
}