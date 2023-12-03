using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChampManage.MAUI.Models
{
    public class Championship
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Location { get; set; }
        public DateTime DateTime { get; set; }
        public decimal RegistrationFee { get; set; }
        public DateTime RegistrationDeadline { get; set; }
        public string Description { get; set; }
    }
}
