using PrincessonthepeaBussinesLogic.BindingModels;
using PrincessonthepeaBussinesLogic.BuisnessLogicI;
using PrincessonthepeaBussinesLogic.StorageInterfaces;
using PrincessonthepeaBussinesLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrincessonthepeaBussinesLogic.BuisnessLogic
{
    public class EmployeeLogic : IEmployeeLogic
    {
        private readonly IEmployeeStorage _employeeStorage;
        public EmployeeLogic(IEmployeeStorage employeeStorage)
        {
            _employeeStorage = employeeStorage;
        }
        public List<EmployeeViewModel> Read(EmployeeBindingModel model)
        {
            if (model == null)
            {
                return _employeeStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<EmployeeViewModel> { _employeeStorage.GetElement(model)
};
            }
            return _employeeStorage.GetFilteredList(model);
        }
        public void CreateOrUpdate(EmployeeBindingModel model)
        {
            var element = _employeeStorage.GetElement(new EmployeeBindingModel
            {
                EmployeeName = model.EmployeeName,
                EmployeeLogin = model.EmployeeLogin,
                EmployeePassword = model.EmployeePassword,
                EmployeeEmail = model.EmployeeEmail
            
            }) ;
            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Уже есть сотрудник с такими данными");
            }
            if (model.Id.HasValue)
            {
                _employeeStorage.Update(model);
            }
            else
            {
                _employeeStorage.Insert(model);
            }
        }
        public void Delete(EmployeeBindingModel model)
        {
            var element = _employeeStorage.GetElement(new EmployeeBindingModel
            {
                Id =
           model.Id
            });
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            _employeeStorage.Delete(model);
        }
    }
}
