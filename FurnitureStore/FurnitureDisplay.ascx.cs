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
            lblFurnitureName.Text = dsFurniture.Tables[0].Rows[0]["furnitureName"].ToString();
            lblFurnitureType.Text = dsFurniture.Tables[0].Rows[0]["furnitureType"].ToString();
            Decimal price = Convert.ToDecimal(dsFurniture.Tables[0].Rows[0]["furniturePrice"].ToString());
            lblFurniturePrice.Text = price.ToString("C2");
        }

        protected void btnSelect_Click(object sender, EventArgs e)
        {

        }
    }
}