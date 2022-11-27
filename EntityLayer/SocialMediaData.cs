using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityLayer
{
    public class SocialMediaData
    {
        public int SocialMediaID { get; set; }
        public int Type { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Savedon { get; set; }
        public string Createdon { get; set; }
        public int UserID { get; set; }
    }
}
