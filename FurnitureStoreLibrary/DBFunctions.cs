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
    class DBFunctions
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
    }
}
