using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestAPI.Models
{
    public class Reservation
    {
       // public int ReservationId;
        public String ReservationTime;
        public DateTime ReservationDate;
        public int ReservationCount;
        public int FurnitureId;



        public Reservation()
        {
        }

        public Reservation(int furnitureId, 
            DateTime date, String time, int count)
        {
            //this.ReservationId = id;
            this.FurnitureId = furnitureId;
            this.ReservationDate = date;
            this.ReservationTime = time;
            this.ReservationCount = count;
        }
}
}
