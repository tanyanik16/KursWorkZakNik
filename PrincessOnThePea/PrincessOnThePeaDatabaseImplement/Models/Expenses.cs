using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrincessOnThePeaDatabaseImplement.Models
{
    public class Expenses
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string ExpName { get; set; }
        [Required]
        public int ExpCount { get; set; }
        public int ExpSum { get; set; }
        public Employee Employee { get; set; }
        public virtual List<Expenses_Conf> Expenses_Confs { get; set; }
    }
}
