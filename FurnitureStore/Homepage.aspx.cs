using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FurnitureStoreLibrary;
using Utilities;

namespace FurnitureStore.FurnitureStoreWeb
{
    public partial class Homepage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DBFunctions dBFunctions = new DBFunctions();
            DBConnect newDB = new DBConnect();
            int count = 0;

            DataSet furnitureDS = dBFunctions.GetFurniture(newDB);
            count = furnitureDS.Tables[0].Rows.Count;

            foreach(DataRow record in furnitureDS.Tables[0].Rows)
            {
                FurnitureDisplay displayCtrl = (FurnitureDisplay)LoadControl("FurnitureDisplay.ascx");
                displayCtrl.FurnitureId = int.Parse(record["furnitureID"].ToString());
                displayCtrl.DataBind();
                Form.Controls.Add(displayCtrl);
            }
        }
    }
}