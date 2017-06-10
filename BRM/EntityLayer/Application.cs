using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityLayer
{
    [Table("BRM.Application")]
    public class Application
    {
        [Key]
        public int ID { get; set; }
        public string application { get; set; }
        public string Username { get; set; }
        public string password { get; set; }
    }
}
