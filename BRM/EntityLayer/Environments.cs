using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityLayer
{
    [Table("BRM.Environment")]
    public class Environments
    {
        [Key]
        public int ID { get; set; }
        public string Environment { get; set; }
        public int Release_ID { get; set; }
    }
}
