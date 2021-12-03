using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities;
using FurnitureStoreLibrary;
using System.Data.SqlClient;

namespace FurnitureStoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    public class ReservationController : Controller
    {
        DBFunctions dBFunctions = new DBFunctions();

        [HttpGet]
        [HttpGet("GetReservations")]
        public List<Reservation> Get()
        {
            DBConnect objDB = new DBConnect();
            DataSet ds = dBFunctions.GetReservations(objDB);
            List<Reservation> reservationList = new List<Reservation>();

            int count = ds.Tables[0].Rows.Count;
            for (int i = 0; i < count; i++)
            {
                Reservation reservation = new Reservation();
                reservation.FurnitureID = int.Parse(ds.Tables[0].Rows[i]["furnitureID"].ToString());
                reservation.ReservationDate = ds.Tables[0].Rows[i]["reservationDate"].ToString();
                reservation.ReservationTime = ds.Tables[0].Rows[i]["reservationTime"].ToString();
                reservation.ReservationCount = int.Parse(ds.Tables[0].Rows[i]["reservationCount"].ToString());
                reservationList.Add(reservation);
            }
            return reservationList;
        }

        [HttpPost]
        [HttpPost("AddReservation")]
        public Boolean AddReservation([FromBody]Reservation reservation)
        {
            DBConnect objDB = new DBConnect();
            int flag = dBFunctions.AddReservation(reservation.ReservationTime, reservation.ReservationDate, reservation.ReservationCount, 
                reservation.UserID, reservation.FurnitureID, objDB);
            if (flag > 0)
            { return true; }
            else { return false; }

        }

        [HttpPut]
        [HttpPut("UpdateReservation")]
        public Boolean UpdateReservation([FromBody]Reservation reservation)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_UpdateReservationCount";

            SqlParameter inputParameter = new SqlParameter("@reservationID", reservation.ReservationID);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.Int;
            inputParameter.Size = 4;
            objCommand.Parameters.Add(inputParameter); 

            inputParameter = new SqlParameter("@reservationCount", reservation.ReservationCount);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.Int;
            inputParameter.Size = 4;
            objCommand.Parameters.Add(inputParameter);

            int flag = objDB.DoUpdateUsingCmdObj(objCommand);
            if (flag > 0)
            { return true; }
            else { return false; }
        }


        [HttpDelete]
        [HttpDelete("DeleteReservation")]
        public Boolean DeleteReservation(int reservationID)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand cmdDeleteReservation = new SqlCommand();

            cmdDeleteReservation.Parameters.Clear();

            cmdDeleteReservation.CommandType = CommandType.StoredProcedure;
            cmdDeleteReservation.CommandText = "TP_DeleteReservation";

            cmdDeleteReservation.Parameters.AddWithValue("@reservationID", reservationID);

            int result = objDB.DoUpdateUsingCmdObj(cmdDeleteReservation);
            
            if (result > 0)
            {
                return true;
            }
            else { 
                return false; 
            }
        }



    }
}
