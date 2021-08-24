using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;

namespace EscuelaWPF.Service
{
    public class AttendanceService : Service<Attendance>
    {
        static HttpClient client = new HttpClient();
        public AttendanceService()
        {
            connectionString += "/attendance";
        }
        public override async Task<Attendance> Delete(string id)
        {
            var client = new RestClient(connectionString+"/"+id);
            client.Timeout = -1;
            var request = new RestRequest(Method.DELETE);
            request.AddHeader("Authorization", "Bearer " + AuthenticationManager.Auth);
            IRestResponse response = client.Execute(request);

            return new Attendance();

        }

        public override async Task<List<Attendance>> GetAllAsync()
        {
            List<Attendance> Items = new();
            if (AuthenticationManager.Auth != null)
            {
                try
                {
                    var client = new RestClient(connectionString);
                    client.Timeout = -1;
                    var request = new RestRequest(Method.GET);
                    request.AddHeader("Authorization", "Bearer " + AuthenticationManager.Auth);
                    
                    IRestResponse response = client.Execute(request);
                    Console.WriteLine(response.Content);
                    if (response.IsSuccessful)
                    {
                        Items = JsonConvert.DeserializeObject<List<Attendance>>(response.Content);
                        return Items;
                    }
                }
                catch
                {
                    return Items;
                }

            }
            return Items;
        }

        public override async Task<Attendance> GetbyId(string id)
        {
            try
            {
                var client = new RestClient(connectionString + "/" + id);
                client.Timeout = -1;
                var request = new RestRequest(Method.GET);
                request.AddHeader("Authorization", "Bearer " + AuthenticationManager.Auth);

                IRestResponse response = client.Execute(request);
                Console.WriteLine(response.Content);
                if (response.IsSuccessful)
                {
                    return JsonConvert.DeserializeObject<Attendance>(response.Content);
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }

        public override async Task<Attendance> Post(Attendance value)
        {
            var client = new RestClient(connectionString);
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", "Bearer " + AuthenticationManager.Auth);
            request.AddHeader("Content-Type", "application/json");
            List<Attendance> input = new();
            input.Add(value);
            
            var body = JsonConvert.SerializeObject(input);
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            return JsonConvert.DeserializeObject<Attendance>(response.Content);
        }

        public override async Task<Attendance> Put(Attendance value)
        {
            var client = new RestClient(connectionString);
            client.Timeout = -1;
            var request = new RestRequest(Method.PUT);
            request.AddHeader("Authorization", "Bearer " + AuthenticationManager.Auth);
            request.AddHeader("Content-Type", "application/json");
            List<Attendance> input = new();
            input.Add(value);

            var body = JsonConvert.SerializeObject(input);
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            IRestResponse response =  client.Execute(request);

            return JsonConvert.DeserializeObject<Attendance>(response.Content);
        }
    }
}
