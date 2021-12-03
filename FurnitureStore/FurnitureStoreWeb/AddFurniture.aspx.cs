using SOAPWebServices;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;


namespace FurnitureStore.FurnitureStoreWeb
{

    public partial class AddFurniture : System.Web.UI.Page
    {
        string username;
        int userID;

        protected void Page_Load(object sender, EventArgs e)
        {
            //store UN and UserId for to add to database when pet is added!
            username = Session["username"].ToString();
            userID = (int)Session["userID"];
        }

        protected void btnSubmit_addfurniture_Click(object sender, EventArgs e)
        {
            SOAPWebServices.Furniture newFurniture = new Furniture();
            newFurniture.furnitureName = txtFurnitureName.Text;
            newFurniture.furnitureID = userID;
            newFurniture.furniturePieces = txtFurniturePieces.Text;
            newFurniture.furnitureType = txtFurnitureType.Text;
            newFurniture.furnitureDescription = txtFurnitureDesc.Text;
            newFurniture.furniturePrice = Int32.Parse(txtFurniturePrice.Text);  
        }

        protected void btnGoHome_Click(object sender, EventArgs e)
        {

        }

        protected void btnAddMore_Click(object sender, EventArgs e)
        {

        }
    }
}