using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace PrincessonthepeaBussinesLogic.ViewModels
{
    public class ExpensesViewModel
    {
        public int Id { get; set; }
        [DisplayName("Название затраты")]
        public string ExpName { get; set; }
        public int ExpCount { get; set; }
        public int ExpSum { get; set; }
        public int EmployeeId { get; set; }
    }
}
