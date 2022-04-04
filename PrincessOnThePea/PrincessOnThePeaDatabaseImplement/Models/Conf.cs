using PrincessonthepeaBussinesLogic.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrincessOnThePeaDatabaseImplement.Models
{
    public class Conf
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime DateStart { get; set; }
        public DateTime? DateEnd { get; set; }
        [Required]
        public int Sum { get; set; }
        public ConfStatus Status { get; set; }
        public int? PayId { get; set; }
        public Client Client{ get; set; }
        public Payment Payment { get; set; }

       
        public virtual List <Conf_Rooms> Conf_Roomss { get; set; }
        public virtual List<Expenses_Conf> Expenses_Confs { get; set; }
    }
}
