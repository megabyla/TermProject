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
        public int FurnitureID { get; set; }
        public int ReservationID { get; set;}
        public String ReservationDate { get; set; }
        public String ReservationTime { get; set; }
        public int ReservationCount { get; set; }
        public int UserID { get; set; }



        public Reservation()
        {
        }

        public Reservation(int reservationID, int furnitureID, string date, String time,
             int count, int userID)
        {
            this.FurnitureID = furnitureID;
            this.ReservationID = reservationID;
            this.ReservationDate = date;
            this.ReservationTime = time;
            this.ReservationCount = count;
            this.UserID = userID;
        }


    }
}
