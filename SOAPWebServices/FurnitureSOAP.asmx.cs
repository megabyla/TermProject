using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using Utilities;

namespace SOAPWebServices
{
    /// <summary>
    /// Summary description for Furniture
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class FurnitureSOAP : System.Web.Services.WebService
    {
        [WebMethod]
        public int addFurniture(Furniture newFurniture)
        {
            DBConnect objDB = new DBConnect();
            //SqlCommand objCommand = new SqlCommand();

            if (newFurniture != null)
            {
                SqlCommand cmdAddFurniture = new SqlCommand();
                cmdAddFurniture.Parameters.Clear();
                cmdAddFurniture.CommandType = CommandType.StoredProcedure;
                cmdAddFurniture.CommandText = "TP_AddFurniture";

                SqlParameter furnitureName = new SqlParameter("@furnitureName", newFurniture.furnitureName);
                furnitureName.Direction = ParameterDirection.Input;
                cmdAddFurniture.Parameters.Add(furnitureName);

                SqlParameter petBreed = new SqlParameter("@PetBreed", newFurniture.petBreed);
                petBreed.Direction = ParameterDirection.Input;
                cmdAddFurniture.Parameters.Add(petBreed);

                SqlParameter petAge = new SqlParameter("@PetAge", newFurniture.petAge);
                petAge.Direction = ParameterDirection.Input;
                cmdAddFurniture.Parameters.Add(petAge);

                SqlParameter animalType = new SqlParameter("@AnimalType", newFurniture.animalType);
                animalType.Direction = ParameterDirection.Input;
                cmdAddFurniture.Parameters.Add(animalType);

                SqlParameter caregiverId = new SqlParameter("@CaregiverId", newFurniture.caregiverId);
                caregiverId.Direction = ParameterDirection.Input;
                cmdAddFurniture.Parameters.Add(caregiverId);

                DataSet ds = objDB.GetDataSetUsingCmdObj(cmdAddFurniture);

                int petID = Int32.Parse(ds.Tables[0].Rows[0][0].ToString());
                if (petID < 0)
                {
                    return -1;
                }

                return petID;
            }
            return -1;
        }

        [WebMethod]
        public void deletePet(int petId)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand cmdDeletePet = new SqlCommand();
            cmdDeletePet.Parameters.Clear();

            cmdDeletePet.CommandType = CommandType.StoredProcedure;
            cmdDeletePet.CommandText = "TP_DeletePet";

            //SqlParameter inputPetId = new SqlParameter("@petId", petId);
            //inputPetId.Direction = ParameterDirection.Input;
            //cmdDeletePet.Parameters.Add(petId);
            cmdDeletePet.Parameters.AddWithValue("@petId", petId);

            int result = objDB.DoUpdateUsingCmdObj(cmdDeletePet);
        }

        [WebMethod]
        public void deletePetImage(int petId)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand cmdDeletePetImage = new SqlCommand();
            cmdDeletePetImage.Parameters.Clear();

            cmdDeletePetImage.CommandType = CommandType.StoredProcedure;
            cmdDeletePetImage.CommandText = "TP_DeletePetImage";

            //SqlParameter inputPetId = new SqlParameter("@petId", petId);
            //inputPetId.Direction = ParameterDirection.Input;
            //cmdDeletePetImage.Parameters.Add(petId);
            cmdDeletePetImage.Parameters.AddWithValue("@petId", petId);


            int result = objDB.DoUpdateUsingCmdObj(cmdDeletePetImage);
        }

        [WebMethod]
        public void updatePetAge(int petId, string petAge)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand cmdUpdatePet = new SqlCommand();
            cmdUpdatePet.Parameters.Clear();

            cmdUpdatePet.CommandType = CommandType.StoredProcedure;
            cmdUpdatePet.CommandText = "TP_ChangePetAge";

            SqlParameter petID = new SqlParameter("@petId", petId);
            petID.Direction = ParameterDirection.Input;
            cmdUpdatePet.Parameters.Add(petID);

            SqlParameter petAgeRange = new SqlParameter("@petAge", petAge);
            petAgeRange.Direction = ParameterDirection.Input;
            cmdUpdatePet.Parameters.Add(petAgeRange);

            objDB.DoUpdateUsingCmdObj(cmdUpdatePet);
        }

        [WebMethod]
        public void sendRequest(int petId, string petName, int userId)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand cmdRequestPet = new SqlCommand();
            cmdRequestPet.Parameters.Clear();

            cmdRequestPet.CommandType = CommandType.StoredProcedure;
            cmdRequestPet.CommandText = "TP_RequestAdoption";

            SqlParameter petID = new SqlParameter("@petId", petId);
            petID.Direction = ParameterDirection.Input;
            cmdRequestPet.Parameters.Add(petID);

            SqlParameter rPetName = new SqlParameter("@petName", petName);
            rPetName.Direction = ParameterDirection.Input;
            cmdRequestPet.Parameters.Add(rPetName);

            SqlParameter userID = new SqlParameter("@userId", userId);
            userID.Direction = ParameterDirection.Input;
            cmdRequestPet.Parameters.Add(userID);

            objDB.DoUpdateUsingCmdObj(cmdRequestPet);
        }
    }
}