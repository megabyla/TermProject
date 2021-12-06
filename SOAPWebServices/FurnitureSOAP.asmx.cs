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

                SqlParameter furnitureType = new SqlParameter("@furnitureType", newFurniture.furnitureType);
                furnitureType.Direction = ParameterDirection.Input;
                cmdAddFurniture.Parameters.Add(furnitureType);

                SqlParameter furniturePrice = new SqlParameter("@furniturePrice", newFurniture.furniturePrice);
                furniturePrice.Direction = ParameterDirection.Input;
                cmdAddFurniture.Parameters.Add(furniturePrice);

                SqlParameter furniturePieces = new SqlParameter("@furniturePieces", newFurniture.furniturePieces);
                furniturePieces.Direction = ParameterDirection.Input;
                cmdAddFurniture.Parameters.Add(furniturePieces);

                SqlParameter furnitureDescription = new SqlParameter("@furnitureDescription", newFurniture.furnitureDescription);
                furnitureDescription.Direction = ParameterDirection.Input;
                cmdAddFurniture.Parameters.Add(furnitureDescription);

                DataSet ds = objDB.GetDataSetUsingCmdObj(cmdAddFurniture);

                int furnitureID = Int32.Parse(ds.Tables[0].Rows[0][0].ToString());
                if (furnitureID < 0)
                {
                    return -1;
                }

                return furnitureID;
            }
            return -1;
        }

        [WebMethod]
        public void deleteFurniture(int furnitureID)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand cmdDeleteFurniture = new SqlCommand();
            cmdDeleteFurniture.Parameters.Clear();

            cmdDeleteFurniture.CommandType = CommandType.StoredProcedure;
            cmdDeleteFurniture.CommandText = "TP_DeleteFurniture";

            cmdDeleteFurniture.Parameters.AddWithValue("@furnitureID", furnitureID);

            int result = objDB.DoUpdateUsingCmdObj(cmdDeleteFurniture);
        }

        [WebMethod]
        public void deleteFurnitureImage(int furnitureID)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand cmdDeleteFurnitureImage = new SqlCommand();
            cmdDeleteFurnitureImage.Parameters.Clear();

            cmdDeleteFurnitureImage.CommandType = CommandType.StoredProcedure;
            cmdDeleteFurnitureImage.CommandText = "TP_DeleteFurnitureImage";

            cmdDeleteFurnitureImage.Parameters.AddWithValue("@furnitureID", furnitureID);

            int result = objDB.DoUpdateUsingCmdObj(cmdDeleteFurnitureImage);
        }

        [WebMethod]
        public DataSet GetFurnitureByType(string type)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();
            DataSet dsFurniture;

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetFurnitureByType";

            SqlParameter inputParameter = new SqlParameter("@theType", type);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.VarChar;
            inputParameter.Size = 50;
            objCommand.Parameters.Add(inputParameter);

            dsFurniture = objDB.GetDataSetUsingCmdObj(objCommand);
            return dsFurniture;
        }

        public DataSet ModifyFurniture(int id, string name, string type, int price, int pieces, string desc)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();
            DataSet dsFurniture;

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_ModifyFurniture";

            SqlParameter inputParameter = new SqlParameter("@furnitureID", id);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.VarChar;
            inputParameter.Size = 50;
            objCommand.Parameters.Add(inputParameter);

            inputParameter = new SqlParameter("@furnitureName", name);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.VarChar;
            inputParameter.Size = 50;
            objCommand.Parameters.Add(inputParameter);

            inputParameter = new SqlParameter("@furnitureType", type);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.VarChar;
            inputParameter.Size = 50;
            objCommand.Parameters.Add(inputParameter);

            inputParameter = new SqlParameter("@furniturePrice", price);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.VarChar;
            inputParameter.Size = 50;
            objCommand.Parameters.Add(inputParameter);

            inputParameter = new SqlParameter("@furniturePieces", pieces);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.VarChar;
            inputParameter.Size = 50;
            objCommand.Parameters.Add(inputParameter);

            inputParameter = new SqlParameter("@furnitureDescription", desc);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.VarChar;
            inputParameter.Size = 50;
            objCommand.Parameters.Add(inputParameter);

            dsFurniture = objDB.GetDataSetUsingCmdObj(objCommand);
            return dsFurniture;
        }
    }
}