using System.Collections.Generic;
using System.Linq;
using DatabaseLayer;
using EntityLayer;
using System.Data;

namespace BusinessLayer
{
    public class BLLogTable
    {
        CallProcedure procedure = new CallProcedure();
        BRMContext db = new BRMContext();

        public List<LogData> GetLogData(int rowCount, int rowFrom)
        {
            var result = procedure.GetLogData(rowCount, rowFrom);
            return result;
        }

        public void DeleteLog(int id)
        {
           Logs log = (from t in db.LogsContext
                          where t.ID == id
                          select t).FirstOrDefault();
            db.LogsContext.Remove(log);
            db.SaveChanges();
        }

    }
}
