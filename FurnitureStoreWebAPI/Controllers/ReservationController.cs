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
            DataSet ds = objDB.GetDataSet("SELECT * FROM TP_Reservation");
            List<Reservation> reservationList = new List<Reservation>();

            int count = ds.Tables[0].Rows.Count;
            foreach (DataRow record in ds.Tables[0].Rows)
            {
                Reservation reservation = new Reservation();
                reservation.ReservationTime = ds.Tables[0].Rows[0]["reservationTime"].ToString();
                reservation.ReservationDate = DateTime.Parse(ds.Tables[0].Rows[0]["reservationDate"].ToString());
                reservation.ReservationCount = int.Parse(ds.Tables[0].Rows[0]["reservationCount"].ToString());
                reservation.FurnitureId = int.Parse(ds.Tables[0].Rows[0]["furnitureId"].ToString());
                reservationList.Add(reservation);
            }
            return reservationList;
        }
    }
}
