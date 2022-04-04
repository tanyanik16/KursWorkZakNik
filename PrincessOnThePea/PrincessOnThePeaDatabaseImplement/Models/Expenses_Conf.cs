using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace PrincessOnThePeaDatabaseImplement.Models
{
   public class Expenses_Conf
    {
        [ForeignKey("Id")]
        public virtual Conf Conf { get; set; }

        [ForeignKey("Id")]
        public virtual Expenses Expenses { get; set; }
    }
}
