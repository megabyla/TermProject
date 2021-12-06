using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureStoreLibrary
{
    public class Images
    {
        public int imageID { get; set; }
        public string imageName { get; set; }
        public int size { get; set; }
        public long imageData { get; set; }




        public Images(int imageID, string imageName, int size, long imageData)
        {
            this.imageID = imageID;
            this.imageName = imageName;
            this.size = size;
            this.imageData = imageData;

        }

        public Images()
        {
        }
    }
}