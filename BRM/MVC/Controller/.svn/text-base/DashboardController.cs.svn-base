using System.Web.Mvc;
using BusinessLayer;
using BRM.Models;
using Newtonsoft.Json;

namespace BRM.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dashboard
        BLApplication application = new BLApplication();
        BLLogTable Table = new BLLogTable();

        public ActionResult Application()
        {
            if (Session["UserName"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        public JsonResult GetApplication(string Text = null)
        {
            var name = application.GetAppication(Text);
            return this.Json(name, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetRelease(int ID = 0, string Text = null)
        {
            if (ID != 0 && Text == null)
            {
                var release = application.GetRelease(ID,null);
                return this.Json(release);
            }
            else
            {
                var release = application.GetRelease(0,Text);
                return this.Json(release);
            }
        }

        public JsonResult GetChanges()
        {
            var changes = application.GetChanges();
            return this.Json(changes, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetEnvironment(int ID=0,string Text = null)
        {
            if (ID != 0 && Text == null)
            {
                var environment = application.GetEnvironment(ID,null);
                return this.Json(environment);
            }
            else
            {
                var environment = application.GetEnvironment(0,Text);
                return this.Json(environment);
            }
        }

        public JsonResult GetServer(int ID=0, string Text=null)
        {
            if (ID != 0 && Text == null)
            {
                var server = application.GetServer(ID,null);
                return this.Json(server);
            }
            else
            {
                var server = application.GetServer(0,Text);
                return this.Json(server);
            }
        }

        public class SelectedID
        {
            [JsonProperty("Application_ID")]
            public int Application_ID { get; set; }
            [JsonProperty("Release_ID")]
            public int Release_ID { get; set; }
            [JsonProperty("Change_ID")]
            public int Change_ID { get; set; }
            [JsonProperty("Server_ID")]
            public int Server_ID { get; set; }
            [JsonProperty("Environment_ID")]
            public int Environment_ID { get; set; }
            [JsonProperty("User_ID")]
            public int User_ID { get; set; }
        }

        [HttpPost]
        public void SaveDetails(SelectedID x)
        {
            application.SaveLogs(x.Application_ID, x.Release_ID, x.Change_ID, x.Environment_ID, x.Server_ID, x.User_ID);
        }

        public ActionResult RefreshGrid()
        {
            Projects model = new Projects();
            model.logs = Table.GetLogData(10, 10);
            return PartialView("_Grid", model);
        }

        public class DeleteID
        {
            [JsonProperty("ID")]
            public int ID { get; set; }
        }

        [HttpPost]
        public bool DeleteRecord(DeleteID ID)
        {
            if (ID != null)
            {
                int id = ID.ID;
                Table.DeleteLog(id);
                return true;
            }
            else
                return false;
        }

        public class SelectedNames
        {
            [JsonProperty("Application_ID")]
            public int Application_ID { get; set; }
            [JsonProperty("Release_ID")]
            public int Release_ID { get; set; }
            [JsonProperty("Change_ID")]
            public int Change_ID { get; set; }
            [JsonProperty("Server_ID")]
            public int Server_ID { get; set; }
            [JsonProperty("Environment_ID")]
            public int Environment_ID { get; set; }
            [JsonProperty("User_ID")]
            public int User_ID { get; set; }
        }
    }
}