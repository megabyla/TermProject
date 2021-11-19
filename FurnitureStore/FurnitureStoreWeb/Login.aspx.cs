using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FurnitureStore.FurnitureStoreWeb
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                HttpCookie reqCookies = Request.Cookies["userInfo"];

                if (reqCookies != null)
                {
                    txtUsername.Text = reqCookies["Username"].ToString();
                    txtPassword.Text = reqCookies["Password"].ToString();
                    string userType = reqCookies["UserType"].ToString();
                    checkCookies.Checked = true;

                    if (userType == "User")
                    {
                        user.Checked = true;
                    }
                    else
                    {
                        user.Checked = false;
                        admin.Checked = true;
                    }
                }
                else
                {
                    Session.Add("UserType", null);
                    Session.Add("Username", null);
                }

            }
        }

        protected void btnLogin_Click2(object sender, EventArgs e)
        {
            Response.Redirect("Homepage.aspx");
        }

        protected void btnForgotPassword(object sender, EventArgs e)
        {
            Response.Redirect("ForgotPass.aspx");
        }

      
    }
}