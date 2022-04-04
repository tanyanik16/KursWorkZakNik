using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrincessonthepeaBussinesLogic.BindingModels
{
    public class ExpensesBindingModel
    {
        public int? Id { get; set; }
        public string ExpName { get; set; }
        public int ExpCount { get; set; }
        public int ExpSum { get; set; }
        public int EmployeeId { get; set; }
    }
}
