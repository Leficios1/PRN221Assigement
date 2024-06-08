using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject.DTOs.Request
{
    public class PetRequestDTO
    {
        public int Id { get; set; }
        public string PetName { get; set; } = null!;
        public string PetType { get; set; } = null!;
        public DateTime BirthDate { get; set; }
        public string? PetGender { get; set; }
        public string? PetSecialFeatures { get; set; }
        public int UserId { get; set; }
    }
}
