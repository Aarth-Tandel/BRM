using System.Data.Entity;
using EntityLayer;
using System.Data.SqlClient;
using System.Data;

namespace DatabaseLayer
{
    public class BRMContext : DbContext
    {
        public BRMContext() : base("BRMContext")
        {
        }

        public DbSet<UserDetails> UserContext { get; set; }
        public DbSet<Server> ServerContext { get; set; }
        public DbSet<Release> ReleaseContext { get; set; }
        public DbSet<Logs> LogsContext { get; set; }
        public DbSet<Environments> EnvironmentContext { get; set; }
        public DbSet<Changes> ChangesContext { get; set; }
        public DbSet<Application> ApplicationContext { get; set; }
        public DbSet<LogData> LogDataContext { get; set;  }
    }

}
