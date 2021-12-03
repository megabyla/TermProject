using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureStoreLibrary
{
    public class Reservation
    {
        //public int ReservationId;
        public String ReservationTime { get; set; }
        public DateTime ReservationDate { get; set; }
        public int ReservationCount { get; set; }
        public int FurnitureId { get; set; }



        public Reservation()
        {
        }

        public Reservation(int furnitureId, DateTime date, String time,
             int count)
        {
            this.FurnitureId = furnitureId;
            this.ReservationDate = date;
            this.ReservationTime = time;
            this.ReservationCount = count;
        }
    }
}
