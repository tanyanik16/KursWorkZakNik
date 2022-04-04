using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrincessonthepeaBussinesLogic.Enums;

namespace PrincessonthepeaBussinesLogic.BindingModels
{
    public class RoomsBindingModel
    {
        public int? Id { get; set; }
        public string RoomsFloor { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime? DateEnd { get; set; }
        public RoomsStatus Status { get; set; }
        public int RoomsPrice { get; set; }
    }
}
