using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FurnitureStoreWebAPI.Models
{
    public class Reservation
    {
        public int ReservationId;
        public String ReservationName;
        public String ReservationTime;
        public DateTime ReservationDate;
        public int ReservationCount;
        public int FurnitureId;



        public Reservation()
        {
        }

        public Reservation(int id, String name, String time,
            DateTime date, int count, int furnitureId)
        {
            this.ReservationId = id;
            this.ReservationName = name;
            this.ReservationTime = time;
            this.ReservationDate = date;
            this.ReservationCount = count;
            this.FurnitureId = furnitureId;
        }
}
}
