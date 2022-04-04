using PrincessonthepeaBussinesLogic.Enums;
namespace PrincessonthepeaBussinesLogic.ViewModels
{
    public class ClientViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public RoleStatus Status { get; set; }
    }
}
