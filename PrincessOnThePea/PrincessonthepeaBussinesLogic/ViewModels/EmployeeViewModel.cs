using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace PrincessonthepeaBussinesLogic.ViewModels
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }
        [DisplayName("Имя сотрудника")]
        public string EmployeeName { get; set; }
        [DisplayName("Логин")]
        public string EmployeeLogin { get; set; }
        [DisplayName("Пароль")]
        public string EmployeePassword { get; set; }
        [DisplayName("Почта")]
        public string EmployeeEmail { get; set; }
        
    }
}
