using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject.Model.Entities
{
    public class BookingDetails : IBaseEntities
    {
        public int Id { get; set; }
        public int PetId { get; set; }
        public int VetId {  get; set; }
        public int BookingId { get; set; }
        public int ServiceId { get; set; }
        public decimal Price { get; set; }
        public int Status { get; set; }

        //Navigation
        [ForeignKey("PetId")]
        public Pet Pet { get; set; }
        [ForeignKey("VetId")]
        public Vet vet {  get; set; }
        public Booking booking { get; set; }
        [ForeignKey("ServiceId")]
        public Service service { get; set; }
    }
}
