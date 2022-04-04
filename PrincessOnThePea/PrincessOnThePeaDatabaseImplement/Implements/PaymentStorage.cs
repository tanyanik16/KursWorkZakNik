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
    public class PaymentStorage: IPaymentStorage
    {
        public List<PaymentViewModel> GetFullList()
        {
            using var context = new HotelDatabase();
            return context.Payments
            .Select(CreateModel)
            .ToList();
        }
        public List<PaymentViewModel> GetFilteredList(PaymentBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new HotelDatabase();
            return context.Payments
            .Where(rec => rec.Id == model.Id)
            .Select(CreateModel)
            .ToList();
        }
        public PaymentViewModel GetElement(PaymentBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new HotelDatabase();
            var payment = context.Payments
            .FirstOrDefault(rec => rec.Id == model.Id);
            return payment != null ? CreateModel(payment) : null;
        }
        public void Insert(PaymentBindingModel model)
        {
            using var context = new HotelDatabase();
            context.Payments.Add(CreateModel(model, new Payment()));
            context.SaveChanges();
        }
        public void Update(PaymentBindingModel model)
        {
            using var context = new HotelDatabase();
            var element = context.Payments.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            CreateModel(model, element);
            context.SaveChanges();
        }
        public void Delete(PaymentBindingModel model)
        {
            using var context = new HotelDatabase();
            Payment element = context.Payments.FirstOrDefault(rec => rec.Id ==
           model.Id);
            if (element != null)
            {
                context.Payments.Remove(element);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
        private static Payment CreateModel(PaymentBindingModel model, Payment
       payment)
        {
            payment.Sum = model.Sum;
            return payment;
        }
        private static PaymentViewModel CreateModel(Payment payment)
        {
            return new PaymentViewModel
            {
                Id = (int)payment.Id,
                Sum = payment.Sum
            };
        }
    }
}
