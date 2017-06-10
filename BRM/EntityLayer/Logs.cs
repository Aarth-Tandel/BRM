using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityLayer
{
    [Table("BRM.Logs")]
    public class Logs
    {
        [Key]
        public int ID { get; set; }
        public int Application_ID { get; set; }
        public int Release_ID { get; set; }
        public int Environment_ID { get; set; }
        public int Server_ID { get; set; }
        public int Change_ID { get; set; }
        public int Users_ID { get; set; }
        public string StartDate { get; set; }
        public string CompleteDate { get; set; }
    }
}
