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
        DBConnect objDB = new DBConnect();

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
            Response.Redirect("FurnitureInfo.aspx?id=" + furnitureId);
        }
        public IEnumerable<Images> Collection()
        {

            using (SqlConnection con = new SqlConnection())
            {
                con.Open();
                string qry = "SELECT * FROM FurnitureImages";
                SqlCommand cmd = new SqlCommand(qry, con);
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                   
                        Images evt = new Images();
                        {
                        evt.imageID = int.Parse(dr["Id"].ToString());
                         evt.imageName=dr["imageName"].ToString();
                        evt.size = int.Parse(dr["Size"].ToString());
                        evt.imageData = long.Parse(dr["imageData"].ToString());
                           
                        };
                    yield return (evt);
                }
                }
            }
        }
    }
