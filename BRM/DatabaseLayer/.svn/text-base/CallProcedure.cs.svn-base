using EntityLayer;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DatabaseLayer
{
    public class CallProcedure
    {
        BRMContext db = new BRMContext();

        public dynamic GetLogData(int rowCount, int rowFrom)
        {
            var param1 = new SqlParameter();
            param1.ParameterName = "@Value1";
            param1.SqlDbType = SqlDbType.Int;
            param1.SqlValue = rowCount;

            var param2 = new SqlParameter();
            param2.ParameterName = "@Value2";
            param2.SqlDbType = SqlDbType.Int;
            param2.SqlValue = rowFrom;

            var query = db.LogDataContext.SqlQuery("BRM.spLogs @value1,@value2", param1, param2).ToList();
            List<LogData> x = new List<LogData>();

            foreach (var val in query)
                x.Add(val);
            return x;
        }
    }
}
