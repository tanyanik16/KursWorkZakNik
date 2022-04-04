using PrincessonthepeaBussinesLogic.BindingModels;
using PrincessonthepeaBussinesLogic.ViewModels;
using System.Collections.Generic;

namespace PrincessonthepeaBussinesLogic.BuisnessLogicI
{
    public interface IConfLogic
    {
        List<ConfViewModel> Read(ConfBindingModel model);
        void CreateOrUpdate(ConfBindingModel model);
        void Delete(ConfBindingModel model);
    }
}
