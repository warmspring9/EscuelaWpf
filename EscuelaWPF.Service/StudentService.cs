using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;

namespace EscuelaWPF.Service
{
    public class StudentService : Service<Student>
    {
        static HttpClient client = new HttpClient();
        public StudentService()
        {
            connectionString += "/student";
        }
        public override async Task<Student> Delete(string id)
        {
            var client = new RestClient(connectionString+"/"+id);
            client.Timeout = -1;
            var request = new RestRequest(Method.DELETE);
            request.AddHeader("Authorization", "Bearer " + AuthenticationManager.Auth);
            IRestResponse response = client.Execute(request);

            return new Student();

        }

        public override async Task<List<Student>> GetAllAsync()
        {
            List<Student> Items = new();
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
                        Items = JsonConvert.DeserializeObject<List<Student>>(response.Content);
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

        public override async Task<Student> GetbyId(string id)
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
                    return JsonConvert.DeserializeObject<Student>(response.Content);
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

        public override async Task<Student> Post(Student value)
        {
            var client = new RestClient(connectionString);
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", "Bearer " + AuthenticationManager.Auth);
            request.AddHeader("Content-Type", "application/json");
            List<Student> input = new();
            input.Add(value);
            
            var body = JsonConvert.SerializeObject(input);
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            return JsonConvert.DeserializeObject<Student>(response.Content);
        }

        public override async Task<Student> Put(Student value)
        {
            var client = new RestClient(connectionString);
            client.Timeout = -1;
            var request = new RestRequest(Method.PUT);
            request.AddHeader("Authorization", "Bearer " + AuthenticationManager.Auth);
            request.AddHeader("Content-Type", "application/json");
            List<Student> input = new();
            input.Add(value);

            var body = JsonConvert.SerializeObject(input);
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            IRestResponse response =  client.Execute(request);

            return JsonConvert.DeserializeObject<Student>(response.Content);
        }

        public async Task<List<Guardian>> GetGuardians(long id)
        {
            List<Guardian> Items = new();
            var client = new RestClient("https://localhost:44321/api/mobilguardian/bystudent/"+id.ToString());
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
            if (response.IsSuccessful)
            {
                Items = JsonConvert.DeserializeObject<List<Guardian>>(response.Content);
                return Items;
            } else
            {
                return Items;
            }
        }
    }
}
