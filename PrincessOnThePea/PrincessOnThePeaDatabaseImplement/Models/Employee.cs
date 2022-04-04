using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace PrincessOnThePeaDatabaseImplement.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string EmployeeName { get; set; }
        [Required]
        public string EmployeeLogin{ get; set; }
        [Required]
        public string EmployeePassword { get; set; }
        [Required]
        public string EmployeeEmail { get; set; }
    }
}
