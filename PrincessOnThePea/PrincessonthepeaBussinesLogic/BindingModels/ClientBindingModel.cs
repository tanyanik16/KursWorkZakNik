using PrincessonthepeaBussinesLogic.Enums;
namespace PrincessonthepeaBussinesLogic.BindingModels
{
    public class ClientBindingModel
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public RoleStatus Status { get; set; }
        public string Email { get; set; }
    }
}
