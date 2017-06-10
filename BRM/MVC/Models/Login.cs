using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BRM.Models
{
    public class LoginModel
    {
        public string ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}