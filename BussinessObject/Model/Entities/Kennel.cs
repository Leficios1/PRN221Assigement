using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObject.Model.Entities
{
    [Table("Kennel")]
    public class Kennel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int KennelId { get; set; }
        public string Name { get; set; }
        public int RoomNumber { get; set; }
        public int Capacity { get; set; }
        public ICollection<KennelRecord> KennelRecords { get; set; }
    }
}
