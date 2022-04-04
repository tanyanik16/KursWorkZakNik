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
    public class ExpensesStorage : IExpensesStorage
    {
        public List<ExpensesViewModel> GetFullList()
        {
            using var context = new HotelDatabase();
            return context.Expensess
            .Select(CreateModel)
            .ToList();
        }
        public List<ExpensesViewModel> GetFilteredList(ExpensesBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new HotelDatabase();
            return context.Expensess
            .Where(rec => rec.ExpName.Contains(model.ExpName))
            .Select(CreateModel)
            .ToList();
        }
        public ExpensesViewModel GetElement(ExpensesBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new HotelDatabase();
            var expenses = context.Expensess
            .FirstOrDefault(rec => rec.ExpName == model.ExpName || rec.Id
           == model.Id);
            return expenses != null ? CreateModel(expenses) : null;
        }
        public void Insert(ExpensesBindingModel model)
        {
            using var context = new HotelDatabase();
            context.Expensess.Add(CreateModel(model, new Expenses()));
            context.SaveChanges();
        }
        public void Update(ExpensesBindingModel model)
        {
            using var context = new HotelDatabase();
            var element = context.Expensess.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            CreateModel(model, element);
            context.SaveChanges();
        }
        public void Delete(ExpensesBindingModel model)
        {
            using var context = new HotelDatabase();
            Expenses element = context.Expensess.FirstOrDefault(rec => rec.Id ==
           model.Id);
            if (element != null)
            {
                context.Expensess.Remove(element);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
        private static Expenses CreateModel(ExpensesBindingModel model, Expenses
       expenses)
        {
            expenses.ExpName = model.ExpName;
            expenses.ExpSum = model.ExpSum;
            expenses.ExpCount = model.ExpCount;
            return expenses;
        }
        private static ExpensesViewModel CreateModel(Expenses expenses)
        {
            return new ExpensesViewModel
            {
                Id = expenses.Id,
                ExpName = expenses.ExpName,
                ExpSum = expenses.ExpSum,
                ExpCount=expenses.ExpCount,
            };
        }
    }
}
