using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PrincessonthepeaBussinesLogic.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrincessOnThePeaDatabaseImplement.Models
{
    public class Client
    { 
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Login { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public RoleStatus Status { get; set; }

    }
}
