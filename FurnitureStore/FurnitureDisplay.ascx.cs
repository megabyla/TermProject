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
            //DBFunctions dbFunctions = new DBFunctions();
            lblFurnitureName.Text = (String)objDB.GetField("furnitureName", 0);
            lblFurnitureDesc.Text = (String)objDB.GetField("furnitureDescription", 0);
            lblFurnitureType.Text = (String)objDB.GetField("furnitureType", 0);
            Decimal price = (Decimal)objDB.GetField("furniturePrice", 0);
            lblFurniturePrice.Text = price.ToString("C2");



        }


    }
}