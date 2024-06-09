using BussinessObject.Model.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject.Model.Entities
{
    [Table("Pet")]
    public class Pet : IBaseEntities
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string PetName { get; set; } = null!;
        public string PetType { get; set; } = null!;
        public DateTime BirthDate { get; set; }
        public string? PetGender {  get; set; }
        public string? PetSecialFeatures { get; set; }
        public short Status {  get; set; }
        //Fk
        public int UserId {  get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
        //Navigation
        public ICollection<PetRecord> PetRecords { get; set; }
        public ICollection<BookingDetails> BookingDetails { get; set; }
        public ICollection<KennelRecord> kennelRecord { get; set; }
    }
}
