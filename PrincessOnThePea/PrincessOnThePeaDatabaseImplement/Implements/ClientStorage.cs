using PrincessonthepeaBussinesLogic.BindingModels;
using PrincessonthepeaBussinesLogic.StorageInterfaces;
using PrincessonthepeaBussinesLogic.ViewModels;
using PrincessOnThePeaDatabaseImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrincessOnThePeaDatabaseImplement.Implements
{
    public class ClientStorage : IClientStorage
    {
        public List<ClientViewModel> GetFullList()
        {
            using var context = new HotelDatabase();
            return context.Clients
            .Select(CreateModel)
            .ToList();
        }
        public List<ClientViewModel> GetFilteredList(ClientBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new HotelDatabase();
            return context.Clients
            .Where(rec => rec.Email.Contains(model.Email))
            .Select(CreateModel)
            .ToList();
        }
        public ClientViewModel GetElement(ClientBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new HotelDatabase();
            var client = context.Clients
            .FirstOrDefault(rec => rec.Email == model.Email || rec.Id
           == model.Id);
            return client != null ? CreateModel(client) : null;
        }
        public void Insert(ClientBindingModel model)
        {
            using var context = new HotelDatabase();
            context.Clients.Add(CreateModel(model, new Client()));
            context.SaveChanges();
        }
        public void Update(ClientBindingModel model)
        {
            using var context = new HotelDatabase();
            var element = context.Clients.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            CreateModel(model, element);
            context.SaveChanges();
        }
        public void Delete(ClientBindingModel model)
        {
            using var context = new HotelDatabase();
            Client element = context.Clients.FirstOrDefault(rec => rec.Id ==
           model.Id);
            if (element != null)
            {
                context.Clients.Remove(element);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
        private static Client CreateModel(ClientBindingModel model, Client
       client)
        {
       
            client.Name = model.Name;
          
            client.Password = model.Password;
            client.Login = model.Login;
            client.Email = model.Email;
            client.Status =model.Status;
            return client;
        }
        private static ClientViewModel CreateModel(Client client)
        {
            return new ClientViewModel
            {
                Id = client.Id,
                Name = client.Name,
                Password = client.Password,
                Login = client.Login,
                Email = client.Email,
                Status = client.Status
            };
        }
    }
}
