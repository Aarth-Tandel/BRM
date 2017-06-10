using System.ComponentModel.DataAnnotations;

namespace EntityLayer
{
    public class LogData
    {
        [Key]
        public int ID { get; set; }
        public string Application { get; set; }
        public string Release { get; set; }
        public string Changes { get; set; }
        public string Environment { get; set; }
        public string Server { get; set; }
        public string Username { get; set; }
        public string CompleteDate { get; set; }
    }
}
