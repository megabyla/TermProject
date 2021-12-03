using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using FurnitureStoreLibrary;


namespace FurnitureStore.FurnitureStoreWeb
{
    public partial class Reservations : System.Web.UI.Page
    {
        string url = "https://localhost:44393/api/reservation/";
        protected void Page_Load(object sender, EventArgs e)
        {
            WebRequest request = WebRequest.Create(url + "GetReservations/");
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

            Repeater1.DataSource = reservations;
            Repeater1.DataBind();
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }
    }
}