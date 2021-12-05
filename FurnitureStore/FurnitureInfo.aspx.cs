using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;
using FurnitureStoreLibrary;
using System.Data;

namespace FurnitureStore
{
    public partial class FurnitureInfo : System.Web.UI.Page
    {
        int furnitureID = 0;
        DBFunctions functions = new DBFunctions();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                furnitureID = int.Parse(Request.QueryString["id"]);
                RetrieveFurniture(furnitureID);
            }

        }

        private void RetrieveFurniture(int id)
        {
            DBConnect objDB = new DBConnect();
            DataSet dsFurni = functions.GetFurnitureById(id, objDB);
            lblFurnitureName.Text = dsFurni.Tables[0].Rows[0]["furnitureName"].ToString();
            lblFurniturePiece.Text = "Number of Pieces: " + dsFurni.Tables[0].Rows[0]["furniturePieces"].ToString();
            lblFurnitureType.Text = "Type: " + dsFurni.Tables[0].Rows[0]["furnitureType"].ToString();
            lblDescription.Text = dsFurni.Tables[0].Rows[0]["furnitureDescription"].ToString();
            Decimal price = Convert.ToDecimal(dsFurni.Tables[0].Rows[0]["furniturePrice"].ToString());
            lblFurniturePrice.Text = "Price: " + price.ToString("C2");
        }
    }
}