using System;

namespace EscuelaWPF.Service
{
    public class Access
    {
        public string Id { get; set; }

        public string Username { get; set; } = "default";

        public string Password { get; set; }

        public int State_id { get; set; }

        public Access() { }

        public override string ToString()
        {
            return Username;
        }
    }
}
