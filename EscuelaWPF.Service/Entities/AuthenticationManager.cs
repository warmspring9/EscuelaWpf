using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscuelaWPF.Service
{
    public static class AuthenticationManager
    {
        public static string Auth { get; set; }

        public static void SetAuth(string auth)
        {
            Auth = auth;
        }
    }
}
