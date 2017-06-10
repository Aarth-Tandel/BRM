using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityLayer
{
    [Table("BRM.Changes")]
    public class Changes
    {   
        [Key]
        public int ID { get; set; }
        public string changes { get; set; }
    }
}
