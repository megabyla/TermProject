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

    }
}
