using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject.DTOs.Response
{
    public class PetRecordResponseDTO
    {
        public int Id { get; set; }
        public string PetName { get; set; } = null!;
        public string PetType { get; set; } = null!;
        public DateTime BirthDate { get; set; }
        public string? PetGender { get; set; }
        public string? PetSecialFeatures { get; set; }
        public short Status { get; set; }
        public string UserName { get; set; }
        public List<PetRecordDTO>? petRecordDTOs { get; set; }
    }

    public class PetRecordDTO
    {
        public int Id { get; set; }
        public int PetId { get; set; }
        public int VetId { get; set; }
        public DateTime Date { get; set; }
        public string? Diagnosis { get; set; }
        public string? Treatment { get; set; }
    }
}
