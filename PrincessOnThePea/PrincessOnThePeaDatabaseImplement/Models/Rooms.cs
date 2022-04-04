using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PrincessonthepeaBussinesLogic.Enums;

namespace PrincessOnThePeaDatabaseImplement.Models
{
    public class Rooms
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string RoomsFloor { get; set; }
        [Required]
        public int RoomsPrice { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime? DateEnd { get; set; }
        public RoomsStatus Status { get; set; }
        public Employee Employee { get; set; }

        public virtual List<Conf_Rooms> Conf_Roomss { get; set; }
        
    }
}
