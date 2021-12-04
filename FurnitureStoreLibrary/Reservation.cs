using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureStoreLibrary
{
    public class Reservation
    {
        public int furnitureID { get; set; }
        public int reservationID { get; set;}
        public String reservationDate { get; set; }
        public String reservationTime { get; set; }
        public int reservationCount { get; set; }
        public int userID { get; set; }



        public Reservation()
        {
        }

        public Reservation(int reservationID, int furnitureID, string date, String time,
             int count, int userID)
        {
            this.reservationID = reservationID;
            this.furnitureID = furnitureID;
            this.reservationDate = date;
            this.reservationTime = time;
            this.reservationCount = count;
            this.userID = userID;
        }


    }
}
