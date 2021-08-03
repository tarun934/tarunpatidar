using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models
{
    public partial class Fees
    {
        public int FeeID { get; set; }
        public int? UserId { get; set; }
        public string FeeType { get; set; }
        public string FeeDescription { get; set; }

        public virtual AppUser User { get; set; }
    }
}
