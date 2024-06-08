using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject.DTOs.Response
{
    public class PetResponseDTO
    {
        public int Id { get; set; }
        public string PetName { get; set; } = null!;
        public string PetType { get; set; } = null!;
        public DateTime BirthDate { get; set; }
        public string? PetGender { get; set; }
        public string? PetSecialFeatures { get; set; }
        public short Status { get; set; }
        public string UserName { get; set; }
    }
}
