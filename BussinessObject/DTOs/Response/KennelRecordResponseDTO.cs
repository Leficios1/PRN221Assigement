using BussinessObject.Model.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject.DTOs.Response
{
    public class KennelRecordResponseDTO
    {
        public int Id { get; set; }
        public int PetId { get; set; }
        public string PetName { get; set; }
        public int KennelId { get; set; }
        public string KennelName { get; set; }
        public int kennelRoom {  get; set; }
        public DateTime? CheckInDate { get; set; }
        public DateTime? CheckOutDate { get; set; }
        public string Treatment { get; set; }
        public bool status { get; set; }
    }
}
