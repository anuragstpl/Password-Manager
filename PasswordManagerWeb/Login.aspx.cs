using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntityLayer;
using DataLayer.DataHelper;
using System.Configuration;
using System.Net.Mail;
using DataLayer.Helper;

namespace PasswordManagerWeb
{
    public partial class Login : System.Web.UI.Page
    {
        UserHelper userHelper = new UserHelper();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSignIn_Click(object sender, EventArgs e)
        {

            EntityLayer.User user = new User();
            user = userHelper.LoginUser(txtUsername.Text, txtPassword.Text);
            if (user != null)
            {
                Session["UserID"] = user.UserID;
                Session["Name"] = user.FirstName + " " + user.LastName;
                Response.Redirect("Dashboard.aspx");
            }
            else
            {
                if (ViewState["LoginCounter"] != null)
                {
                    int a = Convert.ToInt32(ViewState["LoginCounter"]);
                    a++;
                    ViewState["LoginCounter"] = a;
                    if (Convert.ToInt32(ViewState["LoginCounter"]) > 4)
                    {
                        try
                        {
                            user = userHelper.GetUserByUsername(txtUsername.Text);
                            if (user != null)
                            {
                                MailMessage mailMessage = new MailMessage();
                                mailMessage.From = new MailAddress(ConfigurationManager.AppSettings["UserName"]);
                                mailMessage.Subject = "Alert ! Secure your account.";
                                mailMessage.Body = "Hi , Please secure your account as someone tries to open the account....";
                                mailMessage.IsBodyHtml = false;
                                mailMessage.To.Add(new MailAddress(user.Email));
                                mailMessage.CC.Add(new MailAddress("anurag.dealstodo@gmail.com"));
                                mailMessage.Bcc.Add(new MailAddress("yseetaram60@gmail.com"));
                                SmtpClient smtp = new SmtpClient();
                                smtp.Host = ConfigurationManager.AppSettings["Host"];
                                smtp.EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["EnableSsl"]);
                                System.Net.NetworkCredential NetworkCred = new System.Net.NetworkCredential();
                                NetworkCred.UserName = ConfigurationManager.AppSettings["UserName"]; //reading from web.config  
                                NetworkCred.Password = ConfigurationManager.AppSettings["Password"]; //reading from web.config  
                                smtp.UseDefaultCredentials = true;
                                smtp.Credentials = NetworkCred;
                                smtp.Port = int.Parse(ConfigurationManager.AppSettings["Port"]); //reading from web.config  
                                smtp.Send(mailMessage);
                            }
                        }
                        catch (Exception ex)
                        {
                            System.IO.StreamWriter file = new System.IO.StreamWriter(HttpContext.Current.Server.MapPath("~/Logs/logdata.txt"));
                            file.WriteLine(ex.Message);
                            file.Dispose();
                        }
                    }
                    LogHelper.writelog(DateTime.Now.ToString() + ": Login Failure.");
                    Response.Write("<script>alert('Incorrect userid or password');</script>");
                }
                else
                {
                    ViewState["LoginCounter"] = 1;
                    LogHelper.writelog(DateTime.Now.ToString() + ": Login Failure.");
                    Response.Write("<script>alert('Incorrect userid or password');</script>");
                }
            }
        }

        protected void btnSignUp_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }
    }
}