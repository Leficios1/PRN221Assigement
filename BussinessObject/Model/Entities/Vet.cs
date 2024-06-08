using BussinessObject.Model.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject.Model.Entities
{
    [Table("Vet")]
    public class Vet : IBaseEntities
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Specialty { get; set; }
        public ICollection<PetRecord> PetRecords { get; set; }
        public ICollection<BookingDetails> BookingDetails { get; set; }
    }
}
