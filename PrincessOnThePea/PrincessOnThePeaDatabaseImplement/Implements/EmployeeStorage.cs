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
    public class EmployeeStorage : IEmployeeStorage
    {
        public List<EmployeeViewModel> GetFullList()
        {
            using var context = new HotelDatabase();
            return context.Employees
            .Select(CreateModel)
            .ToList();
        }
        public List<EmployeeViewModel> GetFilteredList(EmployeeBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new HotelDatabase();
            return context.Employees
            .Where(rec => rec.EmployeeName.Contains(model.EmployeeName))
            .Select(CreateModel)
            .ToList();
        }
        public EmployeeViewModel GetElement(EmployeeBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new HotelDatabase();
            var employee = context.Employees
            .FirstOrDefault(rec => rec.EmployeeName == model.EmployeeName || rec.Id
           == model.Id);
            return employee != null ? CreateModel(employee) : null;
        }
        public void Insert(EmployeeBindingModel model)
        {
            using var context = new HotelDatabase();
            context.Employees.Add(CreateModel(model, new Employee()));
            context.SaveChanges();
        }
        public void Update(EmployeeBindingModel model)
        {
            using var context = new HotelDatabase();
            var element = context.Employees.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            CreateModel(model, element);
            context.SaveChanges();
        }
        public void Delete(EmployeeBindingModel model)
        {
            using var context = new HotelDatabase();
            Employee element = context.Employees.FirstOrDefault(rec => rec.Id ==
           model.Id);
            if (element != null)
            {
                context.Employees.Remove(element);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
        private static Employee CreateModel(EmployeeBindingModel model, Employee
       employee)
        {
            employee.EmployeeName = model.EmployeeName;
            employee.EmployeeLogin = model.EmployeeLogin;
            employee.EmployeePassword = model.EmployeePassword;
            employee.EmployeeEmail = model.EmployeeEmail;
            
            return employee;
        }
        private static EmployeeViewModel CreateModel(Employee employee)
        {
            return new EmployeeViewModel
            {
                Id = employee.Id,
                EmployeeName = employee.EmployeeName,
               EmployeeLogin = employee.EmployeeLogin,
           EmployeePassword = employee.EmployeePassword,
           EmployeeEmail = employee.EmployeeEmail,
        };
        }
    }
}
