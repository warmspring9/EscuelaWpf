using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace EscuelaWPF.Service
{
    public class LoginService
    {
        readonly HttpClient client = new();
        public async Task<bool> MakeLogin(Login login)
        {
            string conString = "https://localhost:44321/api/login/authenticate";

            try
            {
                HttpResponseMessage response = await client.PostAsJsonAsync(
                conString, login);
                response.EnsureSuccessStatusCode();

                var result = response.Content.ReadAsStringAsync();
                AuthenticationManager.Auth = result.Result.Trim('"');
                response.Dispose();
                return true;
            }
            catch
            {
                return false;
            }
            

        }

    }
}
