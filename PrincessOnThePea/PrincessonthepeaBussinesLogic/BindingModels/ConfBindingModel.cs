using PrincessonthepeaBussinesLogic.Enums;
using System;

 namespace PrincessonthepeaBussinesLogic.BindingModels
{
    public class ConfBindingModel
    {
        public int? Id { get; set; }
        public int Sum { get; set; }
        public string Name { get; set; }
        public int ClientId { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime? DateEnd { get; set; }
        public ConfStatus Status { get; set; }
        public int PayId { get; set; }
    }
}
