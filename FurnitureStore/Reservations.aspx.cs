using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using System.Web.UI.WebControls;
using FurnitureStoreLibrary;
using Utilities;
using System.Data;
using System.Globalization;
using System.Data.SqlClient;

namespace FurnitureStore.FurnitureStoreWeb
{
    public partial class Reservations : System.Web.UI.Page
    {
        int userID;
        DBFunctions dBFunctions = new DBFunctions();
        string url = "https://localhost:44393/api/reservation/";
        protected void Page_Load(object sender, EventArgs e)
        {
            userID = Convert.ToInt32(Session["userID"]); 
            if (!IsPostBack)
            {
                if (Session["username"] != null)
                {
                    BindRepeater();
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
            }
        }
        protected void BindRepeater()
        {
            //SqlCommand objCommand = new SqlCommand();
            //DataSet dsReservations;
            //DBConnect objdb = new DBConnect();
            //objCommand.CommandType = CommandType.StoredProcedure;
            //objCommand.CommandText = "TP_GetReservationsByUserID";

            //SqlParameter inputParameter = new SqlParameter("@userId", userID);
            //inputParameter.Direction = ParameterDirection.Input;
            //inputParameter.SqlDbType = SqlDbType.Int;
            //inputParameter.Size = 4;
            //objCommand.Parameters.Add(inputParameter);

            //dsReservations = obj.GetDataSetUsingCmdObj(objCommand);
            //return dsReservations;

            WebRequest request = WebRequest.Create(url + "GetReservationByUserID/" + userID);
            WebResponse response = request.GetResponse();

            // Read the data from the Web Response, which requires working with streams.

            Stream theDataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(theDataStream);
            String data = reader.ReadToEnd();
            reader.Close();
            response.Close();

            // Deserialize a JSON string that contains an array of JSON objects into an Array of Team objects.

            JavaScriptSerializer js = new JavaScriptSerializer();
            List<Reservation> reservations = js.Deserialize<List<Reservation>>(data);

            // Bind the list to the GridView to display all customers.
            reservations.ToString();
            Repeater1.DataSource = reservations;
            Repeater1.DataBind();
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            Reservation reservation = new Reservation();

            reservation.furnitureID = int.Parse(((Label)e.Item.FindControl("lblFurnitureID")).Text);
            reservation.reservationID = int.Parse(((Label)e.Item.FindControl("lblReservationID")).Text);
            reservation.reservationTime = ((Label)e.Item.FindControl("lblReservationTime")).Text;
            DateTime dt = Convert.ToDateTime(((Label)e.Item.FindControl("lblReservationDate")).Text);
            reservation.reservationDate = dt;
            reservation.reservationCount = int.Parse(((Label)e.Item.FindControl("lblReservationCount")).Text);

            //JavaScriptSerializer js = new JavaScriptSerializer();
            //String jsonReservation = js.Serialize(reservation);

            if (e.CommandName == "edit")
            {
                ((Label)e.Item.FindControl("lblReservationCount")).Visible = false;
                ((TextBox)e.Item.FindControl("txtCountEdit")).Visible = true;
                ((LinkButton)e.Item.FindControl("lnkEdit")).Visible = false;
                ((LinkButton)e.Item.FindControl("lnkUpdate")).Visible = true;
                ((LinkButton)e.Item.FindControl("lnkCancel")).Visible = true;
            }
            if(e.CommandName == "update")
            {
                try
                {
                    reservation.reservationCount = int.Parse(((TextBox)e.Item.FindControl("txtCountEdit")).Text);
                    JavaScriptSerializer js = new JavaScriptSerializer();
                    String jsonReservation = js.Serialize(reservation);

                    WebRequest request = WebRequest.Create(url + "UpdateReservation");
                    request.Method = "PUT";
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
                        BindRepeater();
                    }

                    else
                    {
                        lblStatus.Text = "Update was unsuccessful!";
                        BindRepeater();
                    }
                }
                catch (Exception ex)
                {
                    lblStatus.Text = "Error: " + ex.Message;
                }
            }
            if(e.CommandName == "cancel")
            {
                ((Label)e.Item.FindControl("lblReservationCount")).Visible = true;
                ((TextBox)e.Item.FindControl("txtCountEdit")).Visible = false;
                ((LinkButton)e.Item.FindControl("lnkEdit")).Visible = true;
                ((LinkButton)e.Item.FindControl("lnkUpdate")).Visible = false;
                ((LinkButton)e.Item.FindControl("lnkCancel")).Visible = false;
            }
            if(e.CommandName == "delete")
            {
                try
                {
                    reservation.reservationID = int.Parse(((Label)e.Item.FindControl("lblReservationID")).Text);

                    JavaScriptSerializer js = new JavaScriptSerializer();
                    String jsonReservation = js.Serialize(reservation);

                    WebRequest request = WebRequest.Create(url + "DeleteReservation");
                    request.Method = "DELETE";
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
                        lblStatus.Text = "Delete was successful!";
                        BindRepeater();
                    }

                    else
                    {
                        lblStatus.Text = "Delete was unsuccessful!";
                        BindRepeater();
                    }
                }
                catch (Exception ex)
                {
                    lblStatus.Text = "Error: " + ex.Message;
                }
            }

        }

        protected void ddlReservationFilter_SelectedIndexChanged(object sender, EventArgs e)
        {            
            DBConnect objDB = new DBConnect();

            if (ddlReservationFilter.SelectedItem.Value == "null")
            {
                DataSet dsAll = dBFunctions.GetReservations(objDB);
                Repeater1.DataSource = dsAll;
                Repeater1.DataBind();
            }
            else
            {
                DataSet ds = dBFunctions.GetReservationsByType(ddlReservationFilter.SelectedItem.Value, objDB);
                Repeater1.DataSource = ds;
                Repeater1.DataBind();
            }
        }
    }
}


