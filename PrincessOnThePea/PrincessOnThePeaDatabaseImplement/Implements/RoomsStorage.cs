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
    public class RoomsStorage : IRoomsStorage
    {
        public List<RoomsViewModel> GetFullList()
        {
            using var context = new HotelDatabase();
            return context.Roomss
            .Select(CreateModel)
            .ToList();
        }
        public List<RoomsViewModel> GetFilteredList(RoomsBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new HotelDatabase();
            return context.Roomss
            .Where(rec => rec.RoomsFloor.Contains(model.RoomsFloor))
            .Select(CreateModel)
            .ToList();
        }
        public RoomsViewModel GetElement(RoomsBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new HotelDatabase();
            var rooms = context.Roomss
            .FirstOrDefault(rec => rec.RoomsFloor == model.RoomsFloor || rec.Id
           == model.Id);
            return rooms != null ? CreateModel(rooms) : null;
        }
        public void Insert(RoomsBindingModel model)
        {
            using var context = new HotelDatabase();
            context.Roomss.Add(CreateModel(model, new Rooms()));
            context.SaveChanges();
        }
        public void Update(RoomsBindingModel model)
        {
            using var context = new HotelDatabase();
            var element = context.Roomss.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            CreateModel(model, element);
            context.SaveChanges();
        }
        public void Delete(RoomsBindingModel model)
        {
            using var context = new HotelDatabase();
            Rooms element = context.Roomss.FirstOrDefault(rec => rec.Id ==
           model.Id);
            if (element != null)
            {
                context.Roomss.Remove(element);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
        private static Rooms CreateModel(RoomsBindingModel model, Rooms
       rooms)
        {
            rooms.RoomsFloor = model.RoomsFloor;
            rooms.RoomsPrice = model.RoomsPrice;
            return rooms;
        }
        private static RoomsViewModel CreateModel(Rooms rooms)
        {
            return new RoomsViewModel
            {
                Id = rooms.Id,
                RoomsFloor = rooms.RoomsFloor,
                RoomsPrice = rooms.RoomsPrice
            };
        }
    }
}
