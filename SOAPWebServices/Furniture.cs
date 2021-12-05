using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SOAPWebServices
{
    public class Furniture
    {
        public int furnitureID { get; set; }
        public string furnitureName { get; set; }
        public string furnitureType { get; set; }
        public float furniturePrice { get; set; } 
        public string furniturePieces { get; set; }
        public string furnitureDescription { get; set; }    


        public Furniture(int furnitureID, string furnitureName, string furnitureType, float furniturePrice, string furniturePieces, string furnitureDescription)
        {
            this.furnitureID = furnitureID;
            this.furnitureName = furnitureName;
            this.furnitureType = furnitureType;
            this.furniturePrice = furniturePrice;   
            this.furniturePieces = furniturePieces;
            this.furnitureDescription = furnitureDescription;
        }

        public Furniture()
        {
        }
    }
}
   

