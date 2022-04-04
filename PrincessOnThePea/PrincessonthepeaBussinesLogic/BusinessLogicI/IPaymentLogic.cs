using PrincessonthepeaBussinesLogic.BindingModels;
using PrincessonthepeaBussinesLogic.ViewModels;
using System.Collections.Generic;

namespace PrincessonthepeaBussinesLogic.BuisnessLogicI
{
    public interface IPaymentLogic
    {
        List<PaymentViewModel> Read(PaymentBindingModel model);
        void CreateOrUpdate(PaymentBindingModel model);
        void Delete(PaymentBindingModel model);
    }
}
