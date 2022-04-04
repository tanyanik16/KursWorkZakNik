using PrincessonthepeaBussinesLogic.BindingModels;
using PrincessonthepeaBussinesLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrincessonthepeaBussinesLogic.StorageInterfaces
{
    public interface IExpensesStorage
    {
        List<ExpensesViewModel> GetFullList();
        List<ExpensesViewModel> GetFilteredList(ExpensesBindingModel model);
        ExpensesViewModel GetElement(ExpensesBindingModel model);
        void Insert(ExpensesBindingModel model);
        void Update(ExpensesBindingModel model);
        void Delete(ExpensesBindingModel model);
    }
}
