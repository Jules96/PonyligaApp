
using Newtonsoft.Json;
using Ponyliga.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Ponyliga.Services
{
    public class ApiService
    {
        public HttpClient httpClient;
        private string apiEndpoint = "https://ponyliga.azurewebsites.net/api/";


        public ApiService()
        {
            Instance = this;
        }

        public static ApiService Instance { get; private set; }
        public void APIClient()
        {
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("APIKey", "df5b0f08-a3ae-4bbc-a26f-42b199de266e");
        }

        //URL für POST, GET
        public string GetUrl(string ext)
        {
            return (apiEndpoint + ext);
        }

        //URL für POST, DELETE, GET..BYID
        public string GetUrlID(string ext, string id)
        {
            return (apiEndpoint + ext + "/" + id);
        }

        /*public async Task<object> GetFromApiHttpResponse(string ext)
        {

            var uri = GetUrl(ext);
            var data = await httpClient.GetAsync(uri);

            if (data.IsSuccessStatusCode)
            {
                var respContent = await data.Content.ReadAsStringAsync();
                var settings = new JsonSerializerSettings
                {
                    Formatting = Formatting.Indented
                };

                object JsonData = JsonConvert.DeserializeObject(respContent, settings);
                return Task.Run(() => JsonConvert.DeserializeObject(respContent, settings));
            }
            return null;

        }*/


        public async Task<List<User>> GetAllData()
        {
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("APIKey", "df5b0f08-a3ae-4bbc-a26f-42b199de266e");
            //  httpClient.
            //  httpClient.BaseAddress = "https://ponyliga.azurewebsites.net/api/user";
            var data = await httpClient.GetAsync("https://ponyliga.azurewebsites.net/api/user");

            if (data.IsSuccessStatusCode)
            {
                var respContent = await data.Content.ReadAsStringAsync();
                var settings = new JsonSerializerSettings
                {
                    Formatting = Formatting.Indented
                };

                return await Task.Run(() => JsonConvert.DeserializeObject<List<User>>(respContent, settings));

            }
            return null;
        }

        public async Task<List<User>> GetDataByID(string id, string ext)
        {
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("APIKey", "df5b0f08-a3ae-4bbc-a26f-42b199de266e");
            string uri = GetUrlID(ext, id);
            var data = await httpClient.GetAsync(uri);

            if (data.IsSuccessStatusCode)
            {
                string respContent = await data.Content.ReadAsStringAsync();
                var settings = new JsonSerializerSettings
                {
                    Formatting = Formatting.Indented
                };

                return await Task.Run(() => JsonConvert.DeserializeObject<List<User>>(respContent, settings));

            }
            return null;
        }

        public async Task<bool> AddData(string ext, User user)
        {
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("APIKey", "df5b0f08-a3ae-4bbc-a26f-42b199de266e");
            string uri = GetUrl(ext);

            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault
            };

            string UserSerializer =
                JsonSerializer.Serialize<User>(user, options);
                        
            StringContent content = new StringContent(UserSerializer.ToString(), Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(uri, content);
            Debug.WriteLine("Answer: " + response.StatusCode);

            if (response.IsSuccessStatusCode)
            {
                bool bTask = response.IsSuccessStatusCode;
                Debug.WriteLine("Answer: " + response.StatusCode);
                Console.WriteLine("response.StatusCode");
                return bTask;
            }
            else
            {
                Console.WriteLine("response.StatusCode");
                Debug.WriteLine("Answer: " + response.StatusCode);
            }
            return false;




            }

        public async Task UpdateData(string ext, string id, User user)
        {
            //List<User> users = new List<User>();
            //users.Add(new User { firstName = "Homer", surName = "Simpson", loginName = "HOSIM", passwordHash = "123123", userPrivileges = 1 });
            
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("APIKey", "df5b0f08-a3ae-4bbc-a26f-42b199de266e");
            string uri = GetUrlID(ext, id);

            /*var settings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented
            };*/

            //foreach (var data in users)
                
            var json = JsonConvert.SerializeObject(user);
            StringContent content = new StringContent(json.ToString(), Encoding.UTF8, "application/json");
            var response = await httpClient.PutAsync(uri, content);
            

        }

        public async Task DeleteData(string id, string ext)
        {
            // wird später gelöscht
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("APIKey", "df5b0f08-a3ae-4bbc-a26f-42b199de266e");
            string uri = GetUrlID(ext, id);

            try
            {
                var response = await httpClient.DeleteAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"Item successfully deleted.");
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

        }




    }


}