using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities;
using FurnitureStoreLibrary;
using System.Data;

namespace FurnitureStoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    public class ReservationController : Controller
    {
        [HttpGet]
        [HttpGet("GetReservations")]
        public List<Reservation> Get()
        {
            DBConnect objDB = new DBConnect();
            DataSet ds = objDB.GetDataSet("SELECT * FROM TP_Reservation");
            List<Reservation> reservationList = new List<Reservation>();

            int count = ds.Tables[0].Rows.Count;
            for(int i = 0; i < count; i++)
            {
                /*Reservation reservation = new Reservation();
                reservation.FurnitureId = int.Parse(objDB.GetField("furnitureID", i).ToString());
                reservation.ReservationDate = DateTime.Parse(objDB.GetField("reservationDate", i).ToString());
                reservation.ReservationTime = objDB.GetField("reservationTime", i).ToString();
                reservation.ReservationCount = int.Parse(objDB.GetField("reservationCount", i).ToString());
                reservationList.Add(reservation);*/
                Reservation reservation = new Reservation();
                reservation.FurnitureId = int.Parse(ds.Tables[0].Rows[i]["furnitureID"].ToString());
                reservation.ReservationDate = DateTime.Parse(ds.Tables[0].Rows[i]["reservationDate"].ToString());
                reservation.ReservationTime = ds.Tables[0].Rows[i]["reservationTime"].ToString();
                reservation.ReservationCount = int.Parse(ds.Tables[0].Rows[i]["reservationCount"].ToString());
                reservationList.Add(reservation);
            }
            return reservationList;
        }
    }
}
