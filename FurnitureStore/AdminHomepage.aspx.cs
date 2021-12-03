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
            ArrayList furnitureidList = new ArrayList();
        protected void Page_Load(object sender, EventArgs e)
        {
            //getting user info from session cookie to populate 
          //  userName = Session["username"].ToString();
            //lblName.Text = userName;
           // showPets();
        }

        protected void btnAdd_Click1(object sender, EventArgs e)
        {
           
        }

        protected void btnRemove_Click(object sender, EventArgs e)
        {
            deleteDiv.Visible = true;
            displayDiv.Visible = false;
            modifiyDiv.Visible = false;
            requestDiv.Visible = false;
            acceptDiv.Visible = false;
        }

        protected void btnResvRequest_Click(object sender, EventArgs e)
        {

        }

        protected void gvAllFurniture_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnDeleteFurniture_Click(object sender, EventArgs e)
        {

        }

        protected void btnModify_Click(object sender, EventArgs e)
        {

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {

        }

        protected void gvResvRequests_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnAccept_Click(object sender, EventArgs e)
        {

        }

        protected void btnReject_Click(object sender, EventArgs e)
        {

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
 Response.Redirect("AddFurniture.aspx");
        }
    }
}