using PrincessOnThePeaDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace PrincessOnThePeaDatabaseImplement
{
    public class HotelDatabase : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=HotelDatabase;Trusted_Connection=True");
            }
            base.OnConfiguring(optionsBuilder);

        }
        public virtual DbSet<Client> Clients { set; get; }
        public virtual DbSet<Employee> Employees { set; get; }
        public virtual DbSet<Payment> Payments { set; get; }
        public virtual DbSet<Conf>Confs { set; get; }
        public virtual DbSet<Expenses> Expensess { set; get; }
        public virtual DbSet<Rooms> Roomss { set; get; }
    }
}
