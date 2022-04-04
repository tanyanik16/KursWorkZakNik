
using PrincessonthepeaBussinesLogic.BindingModels;
using PrincessonthepeaBussinesLogic.ViewModels;
using System.Collections.Generic;

namespace PrincessonthepeaBussinesLogic.StorageInterfaces
{
    public interface IConfStorage
    {
        List<ConfViewModel> GetFullList();
        List<ConfViewModel> GetFilteredList(ConfBindingModel model);
        ConfViewModel GetElement(ConfBindingModel model);
        void Insert(ConfBindingModel model);
        void Update(ConfBindingModel model);
        void Delete(ConfBindingModel model);
    }
}
