using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrincessOnThePeaDatabaseImplement.Models
{
    public class Conf_Rooms
    {
        [ForeignKey("Id")]
        public virtual Conf Conf { get; set; }
        [ForeignKey("Id")]
        public virtual Rooms Rooms { get; set; }

    }
}
