using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;
using FurnitureStoreLibrary;

namespace FurnitureStore.FurnitureStoreWeb
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {

            Response.Redirect("Login.aspx");
        }
    }
}

//"First Name cannot be left empty or contain numbers/special characters!"
//"Last Name cannot be left empty or contain numbers/special characters!"
//"Phone Number cannot be left empty or contain letters/special characters!"