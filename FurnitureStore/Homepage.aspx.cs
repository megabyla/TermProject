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

            string type = SearchFilter1.getFilter();
            string search = SearchFilter1.getSearch();

            DataSet allFurnitureDS = dBFunctions.GetFurniture(newDB);
            
            if (type == "null" && search == "")
            {
                foreach (DataRow record in allFurnitureDS.Tables[0].Rows)
                {
                    FurnitureDisplay displayCtrl = (FurnitureDisplay)LoadControl("FurnitureDisplay.ascx");
                    displayCtrl.FurnitureId = int.Parse(record["furnitureID"].ToString());
                    displayCtrl.DataBind();
                    Form.Controls.Add(displayCtrl);
                }
            }
            else if (type!="null" && search == "")
            {
                DataSet typeFurnitureDS = dBFunctions.GetFurnitureByType(type);
                foreach (DataRow record in typeFurnitureDS.Tables[0].Rows)
                {
                    FurnitureDisplay displayCtrl = (FurnitureDisplay)LoadControl("FurnitureDisplay.ascx");
                    displayCtrl.FurnitureId = int.Parse(record["furnitureID"].ToString());
                    displayCtrl.DataBind();
                    Form.Controls.Add(displayCtrl);
                }
            }

            else if (search != null && search != "")
            {
                //SearchFilter1.setFilter("null");
                SearchFilter1.FilterDdl = "null";
                DataSet searchFurnitureDS = dBFunctions.GetFurnitureByName(search);
                int count = searchFurnitureDS.Tables[0].Rows.Count;

                if (count > 0)
                {
                    foreach (DataRow record in searchFurnitureDS.Tables[0].Rows)
                    {
                        FurnitureDisplay displayCtrl = (FurnitureDisplay)LoadControl("FurnitureDisplay.ascx");
                        displayCtrl.FurnitureId = int.Parse(record["furnitureID"].ToString());
                        displayCtrl.DataBind();

                        Form.Controls.Add(displayCtrl);
                        
                    }
                }
                else
                {
                    foreach (DataRow record in allFurnitureDS.Tables[0].Rows)
                    {
                        FurnitureDisplay displayCtrl = (FurnitureDisplay)LoadControl("FurnitureDisplay.ascx");
                        displayCtrl.FurnitureId = int.Parse(record["furnitureID"].ToString());
                        displayCtrl.DataBind();
                        Form.Controls.Add(displayCtrl);
                    }
                }
            }
         

            
        }
    }
}