using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;
using FurnitureStoreLibrary;
using System.Data;
using System.Web.Script.Serialization;
using System.Net;
using System.IO;
using FurnitureStore.Library;

namespace FurnitureStore
{
    public partial class FurnitureInfo : System.Web.UI.Page
    {
        int furnitureID = 0;
        int userID = 0;
        string url = "https://localhost:44393/api/reservation/";
        DBFunctions functions = new DBFunctions();
        DBConnect objDB = new DBConnect();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                furnitureID = int.Parse(Request.QueryString["id"]);
                RetrieveFurniture(furnitureID);
            }

            userID = Convert.ToInt32(Session["userID"]);

        }

        private void RetrieveFurniture(int id)
        {
            DataSet dsFurni = functions.GetFurnitureById(id, objDB);
            lblFurnitureName.Text = dsFurni.Tables[0].Rows[0]["furnitureName"].ToString();
            lblFurniturePiece.Text = "<b>Number of Pieces:</b> " + dsFurni.Tables[0].Rows[0]["furniturePieces"].ToString();
            lblFurnitureType.Text = "<b>Type:</b> " + dsFurni.Tables[0].Rows[0]["furnitureType"].ToString();
            lblDescription.Text = dsFurni.Tables[0].Rows[0]["furnitureDescription"].ToString();
            Decimal price = Convert.ToDecimal(dsFurni.Tables[0].Rows[0]["furniturePrice"].ToString());
            lblFurniturePrice.Text = "<b>Price:</b> " + price.ToString("C2");
        }

        protected void btnReserve_Click(object sender, EventArgs e)
        {
            if (Session["username"] != null)
            {
                Reservation reservation = new Reservation();
                //Furniture furniture = new Furniture();
                //DataSet dsFurni = functions.GetFurnitureById(furnitureID, objDB);
                //furniture.furnitureName = dsFurni.Tables[0].Rows[0]["furnitureName"].ToString();
                //furniture.furniturePieces = dsFurni.Tables[0].Rows[0]["furniturePieces"].ToString();
                //furniture.furnitureType = dsFurni.Tables[0].Rows[0]["furnitureType"].ToString();
                //furniture.furnitureDescription = dsFurni.Tables[0].Rows[0]["furnitureDescription"].ToString();
                //furniture.furniturePrice = (float)(dsFurni.Tables[0].Rows[0]["furniturePrice"]);

                reservation.furnitureID = int.Parse(Request.QueryString["id"]);
                reservation.reservationCount = 1;
                reservation.reservationDate = DateTime.Today;
                reservation.userID = userID;
                DateTime time = DateTime.Now;
                string timeString = time.ToString("hh:mm tt");
                reservation.reservationTime = timeString;

            
            try
                {
                    JavaScriptSerializer js = new JavaScriptSerializer();
                    String jsonReservation = js.Serialize(reservation);

                    WebRequest request = WebRequest.Create(url + "AddReservation/");
                    request.Method = "POST";
                    request.ContentLength = jsonReservation.Length;
                    request.ContentType = "application/json";

                    StreamWriter writer = new StreamWriter(request.GetRequestStream());
                    writer.Write(jsonReservation);
                    writer.Flush();
                    writer.Close();

                    WebResponse response = request.GetResponse();
                    Stream theDataStream = response.GetResponseStream();
                    StreamReader reader = new StreamReader(theDataStream);
                    String data = reader.ReadToEnd();
                    reader.Close();
                    response.Close();

                    if (data == "true")
                    {
                        lblStatus.Text = "Update was successful!";
                    }

                    else
                    {
                        lblStatus.Text = "Update was unsuccessful!";
                    }
                }
                catch (Exception ex)
                {
                    lblStatus.Text = "Error: " + ex.Message;
                }
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }
    }
}