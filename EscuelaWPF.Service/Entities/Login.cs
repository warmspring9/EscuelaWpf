using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace EscuelaWPF.Service
{
    public class Login
    {
        public string Username { get; set; }

        public string Password { get; set; }
        public Login(string user, string pass)
        {
            Username = user;
            Password = pass;
        }
    }
}
