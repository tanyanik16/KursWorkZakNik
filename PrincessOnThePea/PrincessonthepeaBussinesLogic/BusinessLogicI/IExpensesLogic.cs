using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrincessonthepeaBussinesLogic.ViewModels;
using PrincessonthepeaBussinesLogic.BindingModels;

namespace PrincessonthepeaBussinesLogic.BuisnessLogicI
{
    public interface IExpensesLogic
    {
        List<ExpensesViewModel> Read(ExpensesBindingModel model);
        void CreateOrUpdate(ExpensesBindingModel model);
        void Delete(ExpensesBindingModel model);
    }
}
