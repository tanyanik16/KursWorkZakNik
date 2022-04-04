using PrincessonthepeaBussinesLogic.BindingModels;
using PrincessonthepeaBussinesLogic.BuisnessLogicI;
using PrincessonthepeaBussinesLogic.StorageInterfaces;
using PrincessonthepeaBussinesLogic.ViewModels;
using System;
using System.Collections.Generic;

namespace PrincessonthepeaBussinesLogic.BuisnessLogic
{
    public class ConfLogic : IConfLogic
    {
        private IConfStorage confStorage;
        public ConfLogic(IConfStorage confsS)
        {
            confStorage = confsS;
        }
        public void CreateOrUpdate(ConfBindingModel model)
        {
            var element = confStorage.GetElement(new ConfBindingModel
            {
                Sum=model.Sum,
                Name = model.Name,
                ClientId = model.ClientId,
                DateStart = model.DateStart,
                DateEnd = model.DateEnd,
                Status = model.Status,
                PayId=model.PayId
            }) ; 
            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Уже есть пользователь с такой почтой");
            }
            if (model.Id.HasValue)
            {
                confStorage.Update(model);
            }
            else
            {
                confStorage.Insert(model);
            }
        }

        public void Delete(ConfBindingModel model)
        {
            var element = confStorage.GetElement(new ConfBindingModel
            {
                Id =
        model.Id
            });
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            confStorage.Delete(model);
        }

        public List<ConfViewModel> Read(ConfBindingModel model)
        {
            if (model == null)
            {
                return confStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<ConfViewModel> { confStorage.GetElement(model)};
            }
            return confStorage.GetFilteredList(model);
        }
    }
}
