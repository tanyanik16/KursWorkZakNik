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
    public class ExpensesLogic : IExpensesLogic
    {
        private readonly IExpensesStorage _expensesStorage;
        public ExpensesLogic(IExpensesStorage expensesStorage)
        {
            _expensesStorage = expensesStorage;
        }
        public List<ExpensesViewModel> Read(ExpensesBindingModel model)
        {
            if (model == null)
            {
                return _expensesStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<ExpensesViewModel> { _expensesStorage.GetElement(model)
};
            }
            return _expensesStorage.GetFilteredList(model);
        }
        public void CreateOrUpdate(ExpensesBindingModel model)
        {
            var element = _expensesStorage.GetElement(new ExpensesBindingModel
            {
                ExpName = model.ExpName,
                ExpCount = model.ExpCount,
                ExpSum = model.ExpSum,
                EmployeeId = model.EmployeeId,
            });
            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Уже есть сотрудник с такими данными");
            }
            if (model.Id.HasValue)
            {
                _expensesStorage.Update(model);
            }
            else
            {
                _expensesStorage.Insert(model);
            }
        }
        public void Delete(ExpensesBindingModel model)
        {
            var element = _expensesStorage.GetElement(new ExpensesBindingModel
            {
                Id =
           model.Id
            });
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            _expensesStorage.Delete(model);
        }
    }
}
