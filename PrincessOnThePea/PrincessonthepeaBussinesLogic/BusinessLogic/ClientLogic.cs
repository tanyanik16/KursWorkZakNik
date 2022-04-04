using PrincessonthepeaBussinesLogic.BindingModels;
using PrincessonthepeaBussinesLogic.BuisnessLogicI;
using PrincessonthepeaBussinesLogic.StorageInterfaces;
using PrincessonthepeaBussinesLogic.ViewModels;
using System;
using System.Collections.Generic;

namespace PrincessonthepeaBussinesLogic.BuisnessLogic
{
    public class ClientLogic : IClientLogic
    {
        private IClientStorage clientStorage;
        public ClientLogic(IClientStorage clientS)
        {
            clientStorage = clientS;
        }
        public void CreateOrUpdate(ClientBindingModel model)
        {
            var element = clientStorage.GetElement(new ClientBindingModel
            {
                Email = model.Email
            });
            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Уже есть пользователь с такой почтой");
            }
            if (model.Id.HasValue)
            {
                clientStorage.Update(model);
            }
            else
            {
                clientStorage.Insert(model);
            }
        }

        public void Delete(ClientBindingModel model)
        {
            var element = clientStorage.GetElement(new ClientBindingModel
            {
                Id =
        model.Id
            });
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            clientStorage.Delete(model);
        }

        public List<ClientViewModel> Read(ClientBindingModel model)
        {
            if (model == null)
            {
                return clientStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<ClientViewModel> { clientStorage.GetElement(model)
};
            }
            return clientStorage.GetFilteredList(model);
        }
    }
}
