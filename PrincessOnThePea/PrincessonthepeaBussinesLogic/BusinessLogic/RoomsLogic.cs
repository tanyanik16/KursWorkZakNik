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
    public class RoomsLogic : IRoomsLogic
    {
        private readonly IRoomsStorage _roomsStorage;
        public RoomsLogic(IRoomsStorage roomsStorage)
        {
            _roomsStorage = roomsStorage;
        }
        public List<RoomsViewModel> Read(RoomsBindingModel model)
        {
            if (model == null)
            {
                return _roomsStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<RoomsViewModel> { _roomsStorage.GetElement(model)
};
            }
            return _roomsStorage.GetFilteredList(model);
        }
        public void CreateOrUpdate(RoomsBindingModel model)
        {
            var element = _roomsStorage.GetElement(new RoomsBindingModel
            {
                RoomsFloor = model.RoomsFloor,
                DateStart = model.DateStart,
                DateEnd = model.DateEnd,
                Status=model.Status,
                RoomsPrice=model.RoomsPrice
            });
            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Уже есть сотрудник с такими данными");
            }
            if (model.Id.HasValue)
            {
                _roomsStorage.Update(model);
            }
            else
            {
                _roomsStorage.Insert(model);
            }
        }
        public void Delete(RoomsBindingModel model)
        {
            var element = _roomsStorage.GetElement(new RoomsBindingModel
            {
                Id =
           model.Id
            });
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            _roomsStorage.Delete(model);
        }
    }
}
