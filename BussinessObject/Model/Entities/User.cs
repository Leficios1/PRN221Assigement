using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObject.Model.Entities
{
    [Table("User")]
    public class User : IBaseEntities
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Address { get; set; } = null!;
        public DateTime? DateOfBirth { get; set; }
        public string? Gender { get; set; }
        public bool Status { get; set; }
        //Fk
        public int RoleId { get; set; }

        //Navigation
        public Role Roles { get; set; }
        public ICollection<Pet> Pets { get; set; }
    }
}
