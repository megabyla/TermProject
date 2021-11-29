using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FurnitureStore.Library
{
    public class Furniture
    {
        public int furnitureID { get; set; }
        public string name { get; set; }
        public string furnitureType { get; set; }

        public Furniture()
        {

        }

        public Furniture(int furnitureID, string Name, string furnitureType)
        {

            this.furnitureID = furnitureID;
            this.name = name;
            this.furnitureType = furnitureType;

        }
    }
}