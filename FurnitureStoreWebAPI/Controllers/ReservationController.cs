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
using FurnitureStore.Library;

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
                reservation.reservationID = int.Parse(ds.Tables[0].Rows[i]["reservationID"].ToString());
                reservation.furnitureID = int.Parse(ds.Tables[0].Rows[i]["furnitureID"].ToString());
                reservation.reservationDate = ds.Tables[0].Rows[i]["reservationDate"].ToString();
                reservation.reservationTime = ds.Tables[0].Rows[i]["reservationTime"].ToString();
                reservation.reservationCount = int.Parse(ds.Tables[0].Rows[i]["reservationCount"].ToString());
                reservationList.Add(reservation);
            }
            return reservationList;
        }

        [HttpGet("GetReservationByID/{id}")]
        public Furniture GetReservationByID(int id)
        {
            DBConnect objDB = new DBConnect();
            DataSet ds = dBFunctions.GetFurnitureById(id, objDB);
            Furniture furniture = new Furniture();

            furniture.furnitureID = int.Parse(ds.Tables[0].Rows[0]["furnitureID"].ToString());
            furniture.furnitureName = ds.Tables[0].Rows[0]["furnitureName"].ToString();
            furniture.furnitureDescription = ds.Tables[0].Rows[0]["furnitureDescription"].ToString();
            furniture.furnitureType = ds.Tables[0].Rows[0]["furnitureType"].ToString();
            furniture.furniturePrice = float.Parse(ds.Tables[0].Rows[0]["furniturePrice"].ToString());

            return furniture;
        }


        [HttpPost]
        [HttpPost("AddReservation")]
        public Boolean AddReservation([FromBody] Reservation reservation)
        {
            DBConnect objDB = new DBConnect();
            int flag = dBFunctions.AddReservation(reservation.reservationTime, reservation.reservationDate, reservation.reservationCount,
                reservation.userID, reservation.furnitureID, objDB);
            if (flag > 0)
            { return true; }
            else { return false; }

        }

        [HttpPut]
        [HttpPut("UpdateReservation")]
        public Boolean UpdateReservation([FromBody] Reservation reservation)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_UpdateReservationCount";

            SqlParameter inputParameter = new SqlParameter("@reservationID", reservation.reservationID);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.Int;
            inputParameter.Size = 4;
            objCommand.Parameters.Add(inputParameter);

            inputParameter = new SqlParameter("@reservationCount", reservation.reservationCount);
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
        public Boolean DeleteReservation([FromBody]Reservation reservation)
        {
            DBConnect objDB = new DBConnect();
            //SqlCommand cmdDeleteReservation = new SqlCommand();

            //cmdDeleteReservation.Parameters.Clear();

            //cmdDeleteReservation.CommandType = CommandType.StoredProcedure;
            //cmdDeleteReservation.CommandText = "TP_DeleteReservation";

            //cmdDeleteReservation.Parameters.AddWithValue("@reservationID", id);

            //int result = objDB.DoUpdateUsingCmdObj(cmdDeleteReservation);
            SqlCommand objCommand = new SqlCommand();

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_DeleteReservation";

            SqlParameter inputParameter = new SqlParameter("@reservationID", reservation.reservationID);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.Int;
            inputParameter.Size = 4;
            objCommand.Parameters.Add(inputParameter);

            int result = objDB.DoUpdateUsingCmdObj(objCommand);

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
