using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FurnitureStore.FurnitureStoreWeb
{
    public partial class AdminHomepage : System.Web.UI.Page
    { 
            string userName;
            ArrayList furnitureList = new ArrayList();
            //keeps track of all of the pets the Admin has under their id so they can't delete someone else's id
            ArrayList furnitureidList = new ArrayList();
        protected void Page_Load(object sender, EventArgs e)
        {
            //getting user info from session cookie to populate 
            userName = Session["username"].ToString();
            //lblName.Text = userName;
           // showPets();
        }

        protected void gvAllFurniture(object sender, EventArgs e)
        {

        }


        protected void btnModify_Click1(object sender, EventArgs e)
        {

        }

        protected void btnCancel_Click1(object sender, EventArgs e)
        {

        }

        protected void btnAccept_Click1(object sender, EventArgs e)
        {

        }

        protected void btnReject_Click1(object sender, EventArgs e)
        {

        }

        protected void btnDeleteFurniture_Click1(object sender, EventArgs e)
        {

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {

        }

        protected void btnRemove_Click(object sender, EventArgs e)
        {

        }

        protected void btnAdoptionRequest_Click(object sender, EventArgs e)
        {

        }
    }
}