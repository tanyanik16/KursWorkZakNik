using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrincessonthepeaBussinesLogic.BindingModels
{
    public class EmployeeBindingModel
    {
        public int? Id { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeLogin { get; set; }
        public string EmployeePassword { get; set; }
        public string EmployeeEmail { get; set; }
    }
}
