using Newtonsoft.Json;
using Ponyliga.Models;
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

        public string GetUrlByOtherID(string ext, string id, string data)
        {
            return (apiEndpoint + ext + "/" + id + "/" + data);
        }

        #region User
        public async Task<List<User>> GetAllUser()
        {
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("APIKey", "df5b0f08-a3ae-4bbc-a26f-42b199de266e");

            string uri = GetUrl("user");
            var data = await httpClient.GetAsync(uri);

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

        public async Task<List<User>> GetUserByID(string id)
        {
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("APIKey", "df5b0f08-a3ae-4bbc-a26f-42b199de266e");
            string uri = GetUrlID("user", id);
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

        public async Task<bool> AddUser(User user)
        {
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("APIKey", "df5b0f08-a3ae-4bbc-a26f-42b199de266e");
            string uri = GetUrl("user");

            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault
            };

            string UserSerializer =
                JsonSerializer.Serialize<User>(user, options);

            StringContent content = new StringContent(UserSerializer.ToString(), Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(uri, content);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }

        public async Task<bool> LogInUser(User user)
        {
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("APIKey", "df5b0f08-a3ae-4bbc-a26f-42b199de266e");
            string uri = GetUrl("userlogin");

            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault
            };

            string UserSerializer =
                JsonSerializer.Serialize<User>(user, options);
            
            StringContent content = new StringContent(UserSerializer.ToString(), Encoding.UTF8, "application/json");
            var response =  httpClient.PostAsync(uri, content);
            
            if (response.Result.ToString().Contains("200"))
            {
                return true;
            }
            

            return false;
        }

        public async Task UpdateUser(string id, User user)
        {
            //List<User> users = new List<User>();
            //users.Add(new User { firstName = "Homer", surName = "Simpson", loginName = "HOSIM", passwordHash = "123123", userPrivileges = 1 });

            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("APIKey", "df5b0f08-a3ae-4bbc-a26f-42b199de266e");
            string uri = GetUrlID("user", id);

            var json = JsonConvert.SerializeObject(user);
            StringContent content = new StringContent(json.ToString(), Encoding.UTF8, "application/json");
            var response = await httpClient.PutAsync(uri, content);

        }

        public async Task DeleteUser(string id)
        {
            // wird später gelöscht
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("APIKey", "df5b0f08-a3ae-4bbc-a26f-42b199de266e");
            string uri = GetUrlID("user", id);

            var response = await httpClient.DeleteAsync(uri);


        }
        #endregion User

        #region Group
        public async Task<List<Group>> GetAllGroups()
        {
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("APIKey", "df5b0f08-a3ae-4bbc-a26f-42b199de266e");

            string uri = GetUrl("group");
            var data = await httpClient.GetAsync(uri);

            if (data.IsSuccessStatusCode)
            {
                var respContent = await data.Content.ReadAsStringAsync();
                var settings = new JsonSerializerSettings
                {
                    Formatting = Formatting.Indented
                };

                return await Task.Run(() => JsonConvert.DeserializeObject<List<Group>>(respContent, settings));

            }
            return null;
        }

        public async Task<List<Group>> GetGroupByID(string id)
        {
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("APIKey", "df5b0f08-a3ae-4bbc-a26f-42b199de266e");
            string uri = GetUrlID("group", id);
            var data = await httpClient.GetAsync(uri);

            if (data.IsSuccessStatusCode)
            {
                string respContent = await data.Content.ReadAsStringAsync();
                var settings = new JsonSerializerSettings
                {
                    Formatting = Formatting.Indented
                };

                return await Task.Run(() => JsonConvert.DeserializeObject<List<Group>>(respContent, settings));

            }
            return null;
        }

        public async Task<bool> AddGroup(Group group)
        {
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("APIKey", "df5b0f08-a3ae-4bbc-a26f-42b199de266e");
            string uri = GetUrl("group");

            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault
            };

            string UserSerializer =
                JsonSerializer.Serialize<Group>(group, options);

            StringContent content = new StringContent(UserSerializer.ToString(), Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(uri, content);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }

        public async Task UpdateGroup(string id, Group group)
        {
            //List<User> users = new List<User>();
            //users.Add(new User { firstName = "Homer", surName = "Simpson", loginName = "HOSIM", passwordHash = "123123", userPrivileges = 1 });

            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("APIKey", "df5b0f08-a3ae-4bbc-a26f-42b199de266e");
            string uri = GetUrlID("group", id);

            var json = JsonConvert.SerializeObject(group);
            StringContent content = new StringContent(json.ToString(), Encoding.UTF8, "application/json");


        }

        public async Task DeleteGroup(string id)
        {
            // wird später gelöscht
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("APIKey", "df5b0f08-a3ae-4bbc-a26f-42b199de266e");
            string uri = GetUrlID("group", id);

            var response = await httpClient.DeleteAsync(uri);


        }

        #endregion Group

        #region Team
        public async Task<List<Team>> GetAllTeams()
        {
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("APIKey", "df5b0f08-a3ae-4bbc-a26f-42b199de266e");

            string uri = GetUrl("team");
            var data = await httpClient.GetAsync(uri);

            if (data.IsSuccessStatusCode)
            {
                var respContent = await data.Content.ReadAsStringAsync();
                var settings = new JsonSerializerSettings
                {
                    Formatting = Formatting.Indented
                };

                return await Task.Run(() => JsonConvert.DeserializeObject<List<Team>>(respContent, settings));

            }
            return null;
        }

        public async Task<List<Team>> GetTeamByID(string id)
        {
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("APIKey", "df5b0f08-a3ae-4bbc-a26f-42b199de266e");
            string uri = GetUrlID("team", id);
            var data = await httpClient.GetAsync(uri);

            if (data.IsSuccessStatusCode)
            {
                string respContent = await data.Content.ReadAsStringAsync();
                var settings = new JsonSerializerSettings
                {
                    Formatting = Formatting.Indented
                };

                return await Task.Run(() => JsonConvert.DeserializeObject<List<Team>>(respContent, settings));

            }
            return null;
        }
        
        public async Task<bool> AddTeam(Team team)
        {
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("APIKey", "df5b0f08-a3ae-4bbc-a26f-42b199de266e");
            string uri = GetUrl("team");

            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault
            };

            string UserSerializer =
                JsonSerializer.Serialize<Team>(team, options);

            StringContent content = new StringContent(UserSerializer.ToString(), Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(uri, content);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }

        public async Task<bool> UpdateTeam(string id, Team team)
        {
            //List<User> users = new List<User>();
            //users.Add(new User { firstName = "Homer", surName = "Simpson", loginName = "HOSIM", passwordHash = "123123", userPrivileges = 1 });

            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("APIKey", "df5b0f08-a3ae-4bbc-a26f-42b199de266e");
            string uri = GetUrlID("team", id);

            var json = JsonConvert.SerializeObject(team);
            StringContent content = new StringContent(json.ToString(), Encoding.UTF8, "application/json");
            var response = await httpClient.PutAsync(uri, content);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;

        }

        public async Task DeleteTeam(string id)
        {
            // wird später gelöscht
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("APIKey", "df5b0f08-a3ae-4bbc-a26f-42b199de266e");
            string uri = GetUrlID("team", id);

            var response = await httpClient.DeleteAsync(uri);


        }


        #endregion Team

        #region Pony

        public async Task<List<Pony>> GetAllPonies()
        {
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("APIKey", "df5b0f08-a3ae-4bbc-a26f-42b199de266e");

            string uri = GetUrl("pony");
            var data = await httpClient.GetAsync(uri);

            if (data.IsSuccessStatusCode)
            {
                var respContent = await data.Content.ReadAsStringAsync();
                var settings = new JsonSerializerSettings
                {
                    Formatting = Formatting.Indented
                };

                return await Task.Run(() => JsonConvert.DeserializeObject<List<Pony>>(respContent, settings));

            }
            return null;
        }

        public async Task<List<Pony>> GetPonyByID(string id)
        {
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("APIKey", "df5b0f08-a3ae-4bbc-a26f-42b199de266e");
            string uri = GetUrlID("pony", id);
            var data = await httpClient.GetAsync(uri);

            if (data.IsSuccessStatusCode)
            {
                string respContent = await data.Content.ReadAsStringAsync();
                var settings = new JsonSerializerSettings
                {
                    Formatting = Formatting.Indented
                };

                return await Task.Run(() => JsonConvert.DeserializeObject<List<Pony>>(respContent, settings));

            }
            return null;
        }

        public async Task<bool> AddPony(Pony pony)
        {
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("APIKey", "df5b0f08-a3ae-4bbc-a26f-42b199de266e");
            string uri = GetUrl("pony");

            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault
            };

            string UserSerializer =
                JsonSerializer.Serialize<Pony>(pony, options);

            StringContent content = new StringContent(UserSerializer.ToString(), Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(uri, content);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }

        public async Task UpdatePony(string id, Pony pony)
        {
            //List<User> users = new List<User>();
            //users.Add(new User { firstName = "Homer", surName = "Simpson", loginName = "HOSIM", passwordHash = "123123", userPrivileges = 1 });

            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("APIKey", "df5b0f08-a3ae-4bbc-a26f-42b199de266e");
            string uri = GetUrlID("team", id);

            var json = JsonConvert.SerializeObject(pony);
            StringContent content = new StringContent(json.ToString(), Encoding.UTF8, "application/json");


        }

        public async Task DeletePony(string id)
        {
            // wird später gelöscht
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("APIKey", "df5b0f08-a3ae-4bbc-a26f-42b199de266e");
            string uri = GetUrlID("team", id);

            var response = await httpClient.DeleteAsync(uri);


        }

        #endregion Pony

        #region Result

        public async Task<List<Result>> GetAllResults()
        {
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("APIKey", "df5b0f08-a3ae-4bbc-a26f-42b199de266e");

            string uri = GetUrl("result");
            var data = await httpClient.GetAsync(uri);

            if (data.IsSuccessStatusCode)
            {
                var respContent = await data.Content.ReadAsStringAsync();
                var settings = new JsonSerializerSettings
                {
                    Formatting = Formatting.Indented
                };

                return await Task.Run(() => JsonConvert.DeserializeObject<List<Result>>(respContent, settings));

            }
            return null;
        }

        public async Task<List<Result>> GetResultSummary()
        {
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("APIKey", "df5b0f08-a3ae-4bbc-a26f-42b199de266e");

            string uri = GetUrl("result/summary");
            var data = await httpClient.GetAsync(uri);

            if (data.IsSuccessStatusCode)
            {
                var respContent = await data.Content.ReadAsStringAsync();
                var settings = new JsonSerializerSettings
                {
                    Formatting = Formatting.Indented
                };

                return await Task.Run(() => JsonConvert.DeserializeObject<List<Result>>(respContent, settings));

            }
            return null;
        }

        public async Task<List<Result>> GetResultByID(string id)
        {
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("APIKey", "df5b0f08-a3ae-4bbc-a26f-42b199de266e");
            string uri = GetUrlID("group", id);
            var data = await httpClient.GetAsync(uri);

            if (data.IsSuccessStatusCode)
            {
                string respContent = await data.Content.ReadAsStringAsync();
                var settings = new JsonSerializerSettings
                {
                    Formatting = Formatting.Indented
                };

                return await Task.Run(() => JsonConvert.DeserializeObject<List<Result>>(respContent, settings));

            }
            return null;
        }

        public async Task<bool> AddResult(Result result)
        {
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("APIKey", "df5b0f08-a3ae-4bbc-a26f-42b199de266e");
            string uri = GetUrl("result");

            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault
            };

            string UserSerializer =
                JsonSerializer.Serialize<Result>(result, options);

            StringContent content = new StringContent(UserSerializer.ToString(), Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(uri, content);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }

        public async Task UpdateResult(string id, Result result)
        {
            //List<User> users = new List<User>();
            //users.Add(new User { firstName = "Homer", surName = "Simpson", loginName = "HOSIM", passwordHash = "123123", userPrivileges = 1 });

            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("APIKey", "df5b0f08-a3ae-4bbc-a26f-42b199de266e");
            string uri = GetUrlID("team", id);

            var json = JsonConvert.SerializeObject(result);
            StringContent content = new StringContent(json.ToString(), Encoding.UTF8, "application/json");


        }

        public async Task DeleteResult(string id)
        {
            // wird später gelöscht
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("APIKey", "df5b0f08-a3ae-4bbc-a26f-42b199de266e");
            string uri = GetUrlID("result", id);

            var response = await httpClient.DeleteAsync(uri);


        }

        #endregion Result

        #region TeamMember
        public async Task<List<TeamMember>> GetAllTeamMembers()
        {
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("APIKey", "df5b0f08-a3ae-4bbc-a26f-42b199de266e");

            string uri = GetUrl("teammember");
            var data = await httpClient.GetAsync(uri);

            if (data.IsSuccessStatusCode)
            {
                var respContent = await data.Content.ReadAsStringAsync();
                var settings = new JsonSerializerSettings
                {
                    Formatting = Formatting.Indented
                };

                return await Task.Run(() => JsonConvert.DeserializeObject<List<TeamMember>>(respContent, settings));

            }
            return null;
        }

        public async Task<List<TeamMember>> GetTeamMemberByID(string id)
        {
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("APIKey", "df5b0f08-a3ae-4bbc-a26f-42b199de266e");
            string uri = GetUrlID("teammember", id);
            var data = await httpClient.GetAsync(uri);

            if (data.IsSuccessStatusCode)
            {
                string respContent = await data.Content.ReadAsStringAsync();
                var settings = new JsonSerializerSettings
                {
                    Formatting = Formatting.Indented
                };

                return await Task.Run(() => JsonConvert.DeserializeObject<List<TeamMember>>(respContent, settings));

            }
            return null;
        }

        public async Task<List<TeamMember>> GetTeamMemberByTeamID(string id)
        {
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("APIKey", "df5b0f08-a3ae-4bbc-a26f-42b199de266e");
            string uri = GetUrlID("teammember", id);
            var data = await httpClient.GetAsync(uri);

            if (data.IsSuccessStatusCode)
            {
                string respContent = await data.Content.ReadAsStringAsync();
                var settings = new JsonSerializerSettings
                {
                    Formatting = Formatting.Indented
                };

                return await Task.Run(() => JsonConvert.DeserializeObject<List<TeamMember>>(respContent, settings));

            }
            return null;
        }

        public async Task<bool> AddTeamMember(TeamMember teamMember)
        {
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("APIKey", "df5b0f08-a3ae-4bbc-a26f-42b199de266e");
            string uri = GetUrl("teammember");

            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault
            };

            string UserSerializer =
                JsonSerializer.Serialize<TeamMember>(teamMember, options);

            StringContent content = new StringContent(UserSerializer.ToString(), Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(uri, content);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }

        public async Task UpdateTeamMember(string id, TeamMember teamMember)
        {
            //List<User> users = new List<User>();
            //users.Add(new User { firstName = "Homer", surName = "Simpson", loginName = "HOSIM", passwordHash = "123123", userPrivileges = 1 });

            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("APIKey", "df5b0f08-a3ae-4bbc-a26f-42b199de266e");
            string uri = GetUrlByOtherID("team", id, "teammember");

            var json = JsonConvert.SerializeObject(teamMember);
            StringContent content = new StringContent(json.ToString(), Encoding.UTF8, "application/json");


        }

        public async Task DeleteTeammeber(string id)
        {
            // wird später gelöscht
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("APIKey", "df5b0f08-a3ae-4bbc-a26f-42b199de266e");
            string uri = GetUrlID("teammember", id);

            var response = await httpClient.DeleteAsync(uri);


        }

        #endregion TeamMember


    }


}