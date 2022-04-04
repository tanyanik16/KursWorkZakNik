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
    public class ConfStorage:IConfStorage
    {
        public List<ConfViewModel> GetFullList()
        {
            using var context = new HotelDatabase();
            return context.Confs
            .Select(CreateModel)
            .ToList();
        }
        public List<ConfViewModel> GetFilteredList(ConfBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new HotelDatabase();
            return context.Confs
            .Where(rec => rec.Name.Contains(model.Name))
            .Select(CreateModel)
            .ToList();
        }
        public ConfViewModel GetElement(ConfBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new HotelDatabase();
            var conf = context.Confs
            .FirstOrDefault(rec => rec.Name == model.Name || rec.Id
           == model.Id);
            return conf != null ? CreateModel(conf) : null;
        }
        public void Insert(ConfBindingModel model)
        {
            using var context = new HotelDatabase();
            context.Confs.Add(CreateModel(model, new Conf()));
            context.SaveChanges();
        }
        public void Update(ConfBindingModel model)
        {
            using var context = new HotelDatabase();
            var element = context.Confs.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            CreateModel(model, element);
            context.SaveChanges();
        }
        public void Delete(ConfBindingModel model)
        {
            using var context = new HotelDatabase();
            Conf element = context.Confs.FirstOrDefault(rec => rec.Id ==
           model.Id);
            if (element != null)
            {
                context.Confs.Remove(element);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
        private static Conf CreateModel(ConfBindingModel model, Conf
       conf)
        {
            conf.Name = model.Name;
            conf.Status = model.Status;
            conf.Sum = model.Sum;
            conf.DateStart = model.DateStart;
            conf.DateEnd = model.DateEnd;
            conf.PayId = model.PayId;
            return conf;
        }
        private static ConfViewModel CreateModel(Conf conf)
        {
            return new ConfViewModel
            {
            Name = conf.Name,      
            Status = conf.Status,
            Sum = conf.Sum,
            DateStart = conf.DateStart,
            DateEnd = conf.DateEnd,
                PayId = conf.PayId,
        };
        }
    }
}
