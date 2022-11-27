using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityLayer
{
    public class AccountData
    {
        public int AccountID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Nullable<int> AddedBy { get; set; }
        public string AddedOn { get; set; }
        public int userid { get; set; }
    }
}
