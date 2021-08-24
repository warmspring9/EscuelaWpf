using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;

namespace EscuelaWPF.Service
{
    public class AccessService : Service<Access>
    {
        static HttpClient client = new HttpClient();
        public AccessService()
        {
            connectionString += "/access";
        }
        public override async Task<Access> Delete(string id)
        {
            var client = new RestClient(connectionString+"/"+id);
            client.Timeout = -1;
            var request = new RestRequest(Method.DELETE);
            request.AddHeader("Authorization", "Bearer " + AuthenticationManager.Auth);
            IRestResponse response = client.Execute(request);

            return new Access();

        }

        public override async Task<List<Access>> GetAllAsync()
        {
            List<Access> Items = new();
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
                        Items = JsonConvert.DeserializeObject<List<Access>>(response.Content);
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

        public override async Task<Access> GetbyId(string id)
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
                    return JsonConvert.DeserializeObject<Access>(response.Content);
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

        public override async Task<Access> Post(Access value)
        {
            var client = new RestClient(connectionString);
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", "Bearer " + AuthenticationManager.Auth);
            request.AddHeader("Content-Type", "application/json");
            List<Access> input = new();
            input.Add(value);
            
            var body = JsonConvert.SerializeObject(input);
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            return JsonConvert.DeserializeObject<Access>(response.Content);
        }

        public override async Task<Access> Put(Access value)
        {
            var client = new RestClient(connectionString);
            client.Timeout = -1;
            var request = new RestRequest(Method.PUT);
            request.AddHeader("Authorization", "Bearer " + AuthenticationManager.Auth);
            request.AddHeader("Content-Type", "application/json");
            List<Access> input = new();
            input.Add(value);

            var body = JsonConvert.SerializeObject(input);
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            IRestResponse response =  client.Execute(request);

            return JsonConvert.DeserializeObject<Access>(response.Content);
        }
    }
}
