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

        public Furniture(int furnitureID, string furnitureName)
        {
            this.furnitureID = furnitureID;
            this.furnitureName = furnitureName;
            this.furnitureType = furnitureType;
        }

    }
}
   

