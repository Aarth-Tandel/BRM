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

        public List<Application> GetAppication(string text = null)
        {
            if(text != null)
            {
                var application = db.ApplicationContext.Where(m => m.application == text).ToList();
                return application;
            }
            else return db.ApplicationContext.ToList();
        }

        public List<Release> GetRelease(int ID = 0, string text = null)
        {
            if (ID != 0 && text == null)
            {
                var release = db.ReleaseContext.Where(m => m.Application_ID == ID).ToList();
                return release;
            }
            else
            {
                var release = db.ReleaseContext.Where(m => m.release == text).ToList();
                return release;
            }
        }

        public List<Changes> GetChanges()
        {
            return db.ChangesContext.ToList();
        }

        public List<Environments> GetEnvironment(int ID = 0, string text = null)
        {
            if (ID != 0 && text == null)
            {
                var environment = db.EnvironmentContext.Where(m => m.Release_ID == ID).ToList();
                return environment;
            }
            else
            {
                var environment = db.EnvironmentContext.Where(m => m.Environment == text).ToList();
                return environment;
            }
        }

        public List<Server> GetServer(int ID = 0, string text = null)
        {
            if (ID != 0 && text == null)
            {
                var server = db.ServerContext.Where(s => s.Environment_ID == ID).ToList();
                return server;
            }
            else
            {
                var server = db.ServerContext.Where(s => s.server == text).ToList();
                return server;
            }
        }

        public void SaveLogs(int Application_ID, int Release_ID, int Change_ID, int Environment_ID, int Server_ID, int UserID)
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

            var id = db.LogsContext.OrderByDescending(p => p.ID).Select(r => r.ID).First();
            if (id == 0) id = 1;
            else id++;
            log.URL = "http://localhost:8080/job/BRM%20Tool/"+id+"/console";

            db.LogsContext.Add(log);
            db.SaveChanges();
        }
    }
}
