using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityLayer
{
    public class User
    {
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string UserType { get; set; }
        public string oldPassword { get; set; }
    }
}
