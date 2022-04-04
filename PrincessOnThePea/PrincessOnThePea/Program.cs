using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using PrincessonthepeaBussinesLogic.BuisnessLogic;
using PrincessonthepeaBussinesLogic.BuisnessLogicI;
using PrincessonthepeaBussinesLogic.BindingModels;
using PrincessonthepeaBussinesLogic.ViewModels;
using PrincessonthepeaBussinesLogic.StorageInterfaces;
using PrincessOnThePeaDatabaseImplement.Implements;
using Unity;
using Unity.Lifetime;

namespace PrincessOnThePea
{
    static class Program
    {
        public static ClientViewModel Client { get; set; }
        private static IUnityContainer container = null;
        public static IUnityContainer Container
        {
            get
            {
                if (container == null)
                {
                    container = BuildUnityContainer();
                }
                return container;
            }
        }
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(Container.Resolve<FormRegistration>());
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var currentContainer = new UnityContainer();
            currentContainer.RegisterType<IClientStorage,
            ClientStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IEmployeeStorage, EmployeeStorage>(new
            HierarchicalLifetimeManager());
            currentContainer.RegisterType<IConfStorage, ConfStorage>(new
            HierarchicalLifetimeManager());
            currentContainer.RegisterType<IExpensesLogic, ExpensesLogic>(new
            HierarchicalLifetimeManager());
            currentContainer.RegisterType<IPaymentLogic, PaymentLogic>(new
            HierarchicalLifetimeManager());
            currentContainer.RegisterType<IRoomsLogic, RoomsLogic>(new
            HierarchicalLifetimeManager());
            return currentContainer;

        }
    }
}