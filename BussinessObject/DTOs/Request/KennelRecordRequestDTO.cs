using BussinessObject.Model.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject.DTOs.Request
{
    public class KennelRecordRequestDTO
    {
        public int Id { get; set; }
        public int PetId { get; set; }
        public int KennelId { get; set; }
        public string Treatment { get; set; }
    }
}
