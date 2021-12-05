using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace FurnitureStoreLibrary
{
    public class DBFunctions
    {
        public DataSet GetFurniture(DBConnect newDB)
        {
            SqlCommand objCommand = new SqlCommand();
            DataSet dsFurniture;
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetFurniture";
            dsFurniture = newDB.GetDataSetUsingCmdObj(objCommand);
            return dsFurniture;
        }

        public DataSet GetFurnitureById(int fId, DBConnect newDB)
        {
            SqlCommand objCommand = new SqlCommand();
            DataSet dsFurniture;


            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetFurnitureById";

            SqlParameter inputParameter = new SqlParameter("@theId", fId);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.Int;
            inputParameter.Size = 4;
            objCommand.Parameters.Add(inputParameter);

            dsFurniture = newDB.GetDataSetUsingCmdObj(objCommand);
            return dsFurniture;
        }
        public DataSet GetReservations(DBConnect newDB)
        {
            SqlCommand objCommand = new SqlCommand();
            DataSet dsReservations;
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetReservations";
            dsReservations = newDB.GetDataSetUsingCmdObj(objCommand);
            return dsReservations;
        }

        public DataSet GetReservationsByType(string type, DBConnect newDB)
        {
            SqlCommand objCommand = new SqlCommand();
            DataSet dsReservations;

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetReservationsByType";

            SqlParameter inputParameter = new SqlParameter("@theType", type);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.VarChar;
            inputParameter.Size = 50;
            objCommand.Parameters.Add(inputParameter);

            dsReservations = newDB.GetDataSetUsingCmdObj(objCommand);
            return dsReservations;
        }

        public int AddReservation(string rTime, string date, int count, int userID, int furnitureID, DBConnect newDB)
        {
            SqlCommand objCommand = new SqlCommand();
            DataSet dsReservations;

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_AddReservations";
            dsReservations = newDB.GetDataSetUsingCmdObj(objCommand);

            SqlParameter parameters = new SqlParameter("@reservationTime", rTime);
            parameters.Direction = ParameterDirection.Input;
            parameters.SqlDbType = SqlDbType.VarChar;
            parameters.Size = 10;
            objCommand.Parameters.Add(parameters);

            parameters = new SqlParameter("@reservationDate", date);
            parameters.Direction = ParameterDirection.Input;
            parameters.SqlDbType = SqlDbType.Date;
            parameters.Size = 8;
            objCommand.Parameters.Add(parameters);

            parameters = new SqlParameter("@reservationCount", count);
            parameters.Direction = ParameterDirection.Input;
            parameters.SqlDbType = SqlDbType.Int;
            parameters.Size = 4;
            objCommand.Parameters.Add(parameters); 
            
            parameters = new SqlParameter("@userID", userID);
            parameters.Direction = ParameterDirection.Input;
            parameters.SqlDbType = SqlDbType.Int;
            parameters.Size = 4;
            objCommand.Parameters.Add(parameters);

            parameters = new SqlParameter("@furnitureID", furnitureID);
            parameters.Direction = ParameterDirection.Input;
            parameters.SqlDbType = SqlDbType.Int;
            parameters.Size = 4;
            objCommand.Parameters.Add(parameters);

            int flag = newDB.DoUpdateUsingCmdObj(objCommand);

            return flag;
        }





    }
}
