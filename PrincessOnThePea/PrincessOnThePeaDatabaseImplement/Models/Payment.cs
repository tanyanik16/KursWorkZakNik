using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrincessOnThePeaDatabaseImplement.Models
{
    public class Payment
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int Sum { get; set; }
        public Client Client { get; set; }
    }
}
