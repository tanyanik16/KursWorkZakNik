using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrincessonthepeaBussinesLogic.ViewModels;
using PrincessonthepeaBussinesLogic.BindingModels;

namespace PrincessonthepeaBussinesLogic.BuisnessLogicI
{
     public interface IRoomsLogic
    {
        List<RoomsViewModel> Read(RoomsBindingModel model);
        void CreateOrUpdate(RoomsBindingModel model);
        void Delete(RoomsBindingModel model);
    }
}
