using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Status
{
    class Program
    {
        static void Main(string[] args)
        {
            int JobID = 0;
            string Status = args[1];          
            Int32.TryParse(args[0], out JobID);
            Update result = new Update();
            result.SaveStatus(Status, JobID);
        }
    }
}
