using PrincessonthepeaBussinesLogic.BindingModels;
using PrincessonthepeaBussinesLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrincessonthepeaBussinesLogic.StorageInterfaces
{
    public interface IRoomsStorage
    {
        List<RoomsViewModel> GetFullList();
        List<RoomsViewModel> GetFilteredList(RoomsBindingModel model);
        RoomsViewModel GetElement(RoomsBindingModel model);
        void Insert(RoomsBindingModel model);
        void Update(RoomsBindingModel model);
        void Delete(RoomsBindingModel model);
    }
}
