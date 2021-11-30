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
        public List<Reservation> Get()
        {
            DBConnect objDB = new DBConnect();
            DataSet ds = objDB.GetDataSet("SELECT * FROM Reservations");
            List<Reservation> reservationList = new List<Reservation>();
            Reservation reservation;

            foreach(DataRow record in ds.Tables[0].Rows)
            {
                reservation = new Reservation();

            }
        }
    }
}
