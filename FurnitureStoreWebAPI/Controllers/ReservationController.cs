using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FurnitureStoreWebAPI.Models;
using Utilities;
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
            DataSet ds = objDB.GetDataSet("SELECT * FROM Reservations");
            List<Reservation> reservationList = new List<Reservation>();

            int count = ds.Tables[0].Rows.Count;

            for(int i = 0; i< count; i++)
            {
                Reservation reservation = new Reservation();
                reservation.FurnitureId = Int32.Parse(objDB.GetField("FurnitureId", i).ToString());
                reservation.ReservationName = objDB.GetField("ReservationName", i).ToString();
                reservation.ReservationTime = objDB.GetField("ReservationTime", i).ToString();
                reservation.ReservationDate = DateTime.Parse(objDB.GetField("ReservationDate", i).ToString());
                reservation.ReservationCount = Int32.Parse(objDB.GetField("ReservationCount", i).ToString());
                reservation.FurnitureId = Int32.Parse(objDB.GetField("FurnitureId", i).ToString());
                reservationList.Add(reservation);
            }
            return reservationList;
        }
    }
}
