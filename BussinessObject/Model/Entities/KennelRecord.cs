using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject.Model.Entities
{
    [Table("KennelRecord")]
    public class KennelRecord : IBaseEntities
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("PetId")]
        public int PetId {  get; set; }
        public Pet Pet { get; set; } = null!;
        [ForeignKey("KennelId")]
        public int KennelId {  get; set; }
        public Kennel Kennel { get; set; } = null!;
        public DateTime? CheckInDate { get; set; }
        public DateTime? CheckOutDate { get; set; }
        public string Treatment { get; set; }
        public bool status { get; set; }
    }
}
