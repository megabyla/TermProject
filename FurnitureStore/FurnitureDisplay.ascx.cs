using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;
using FurnitureStoreLibrary;
using System.Data;
using System.Data.SqlClient;

namespace FurnitureStore
{
    public partial class FurnitureDisplay : System.Web.UI.UserControl
    {
        int furnitureId;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [Category("Misc")]
        public int FurnitureId
        {
            get { return furnitureId; }
            set { furnitureId = value; }
        }

        public override void DataBind()
        {
            DBConnect objDB = new DBConnect();
            DBFunctions dbFunctions = new DBFunctions();
            DataSet dsFurniture = dbFunctions.GetFurnitureById(furnitureId, objDB);
            int furnitureID = Int32.Parse(dsFurniture.Tables[0].Rows[0]["furnitureID"].ToString());
            lblFurnitureName.Text = dsFurniture.Tables[0].Rows[0]["furnitureName"].ToString();
            lblFurnitureType.Text = dsFurniture.Tables[0].Rows[0]["furnitureType"].ToString();
            Decimal price = Convert.ToDecimal(dsFurniture.Tables[0].Rows[0]["furniturePrice"].ToString());
            lblFurniturePrice.Text = price.ToString("C2");

            SqlCommand cmdGetImage = new SqlCommand();
            cmdGetImage.CommandType = CommandType.StoredProcedure;
            cmdGetImage.CommandText = "TP_GetImageById";

            SqlParameter inputId = new SqlParameter("@furnitureID", furnitureID);
            inputId.Direction = ParameterDirection.Input;
            cmdGetImage.Parameters.Add(inputId);

            DataSet ds = objDB.GetDataSetUsingCmdObj(cmdGetImage);

            byte[] bytes = (byte[])ds.Tables[0].Rows[0]["ImageData"];

            string strBase64 = Convert.ToBase64String(bytes);

            imgFurniture.ImageUrl = "data:Image/png;base64," + strBase64;



        }
        protected void btnSelect_Click(object sender, EventArgs e)
        {
            Response.Redirect("FurnitureInfo.aspx?id=" + furnitureId);
        }

    }
}