using BussinessObject.Model.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObject.Model.Entities
{
    [Table("Service")]
    public class Service : IBaseEntities
    {
        public int Id { get; set; }
        public string ServiceName { get; set; } = null!;
        public decimal ServiceCharge { get; set; }
        public ICollection<BookingDetails> BookingDetails { get; set; }

    }
}
