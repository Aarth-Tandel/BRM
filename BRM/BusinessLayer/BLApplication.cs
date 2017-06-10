using System;
using System.Collections.Generic;
using System.Linq;
using DatabaseLayer;
using EntityLayer;

namespace BusinessLayer
{
    public class BLApplication
    {
        BRMContext db = new BRMContext();

        public List<Application> GetAppication()
        {
            return db.ApplicationContext.ToList();
        }

        public List<Release> GetRelease(int ID)
        {
            var release = db.ReleaseContext.Where(m => m.Application_ID == ID).ToList();
            return release;
        }

        public List<Changes> GetChanges()
        {
            return db.ChangesContext.ToList();
        }

        public List<Environments> GetEnvironment(int ID)
        {
            var environment = db.EnvironmentContext.Where(m => m.Release_ID == ID).ToList();
            return environment;
        }

        public List<Server> GetServer(int ID)
        {
            var server = db.ServerContext.Where(s => s.Environment_ID == ID).ToList();
            return server;
        }

        public void SaveLogs(int Application_ID, int Release_ID, int Change_ID, int Environment_ID,int Server_ID, int UserID)
        {
            Logs log = new Logs();
            log.Application_ID = Application_ID;
            log.Change_ID = Change_ID;
            log.Environment_ID = Environment_ID;
            log.Release_ID = Release_ID;
            log.StartDate = DateTime.Now.ToString("M/d/yyyy");
            log.CompleteDate = DateTime.Now.ToString("M/d/yyyy");
            log.Server_ID = Server_ID;
            log.Users_ID = UserID;

            db.LogsContext.Add(log);
            db.SaveChanges();
        }
    }
}
