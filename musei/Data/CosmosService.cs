using System;
using System.Net.Http.Json;
using System.Text.Json;
using musei.Data;

namespace musei.Data
{
    public class CosmosService
    {
        HttpClient client;
        public Dictionary<string, Event> events = new Dictionary<string, Event>();
        public Dictionary<string, Museum> museums = new Dictionary<string, Museum>();


        public CosmosService()
        {
            client = new HttpClient();
        }

        public async Task<Dictionary<string, Event>> GetEvents()
        {

            Uri uri = new Uri("https://musei-functions.azurewebsites.net/api/GetAllEvents?code=ruiMdMkpBn_iVAb7qk_uls9E3gWyPcI--GKyw5MF_xbDAzFuQpK4OA==");
            try
            {
                HttpResponseMessage response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    events = JsonSerializer.Deserialize<Dictionary<string, Event>>(content);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return events;
        }

        public async Task<Dictionary<string, Museum>> GetMuseums()
        {

            Uri uri = new Uri("https://musei-functions.azurewebsites.net/api/GetAllMuseums?code=b7LSMQPt4lh_vfqdo9LBNRXJnWcCEP5JR0TCzTMbhB1IAzFu9NEwwA==");
            try
            {
                HttpResponseMessage response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    museums = JsonSerializer.Deserialize<Dictionary<string, Museum>>(content);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return museums;
        }

        public async Task<User> UpsertUser(User upsertedUser)
        {
            string uri = "https://musei-functions.azurewebsites.net/api/UpsertUser?code=QEF_lod90xw1LLfoPXXAIO7Rhx_DbP_fyXEnlB5L6crtAzFue08TdQ==";
            try
            {
                HttpResponseMessage response = await client.PostAsJsonAsync(uri, upsertedUser);
                if (response.IsSuccessStatusCode)
                {
                    return upsertedUser;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return null;
        }

        public async Task<User> LoginUser(string email, string password)
        {
            string uri = $"https://musei-functions.azurewebsites.net/api/login/{email}/{email}?code=A0wog4aBVSCpLG4wLQgwfMAmVSvhqzqWztx6_gUCO9nZAzFumUR9OQ==";
            try
            {
                HttpResponseMessage response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    User user = JsonSerializer.Deserialize<User>(content);
                    if (user.password != password)
                    {
                        return null;
                    }
                    return user;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return null;
        }

        public async Task<Event> UploadEvent(Event newEvent)
        {
            string uri = "https://musei-functions.azurewebsites.net/api/UploadEvent?code=9Ypvvv03Ya2ay5jxV2NRFAc-TDl5-AwpqOToGUkc1k2nAzFu4CzGag==";
            try
            {
                HttpResponseMessage response = await client.PostAsJsonAsync(uri, newEvent);
                if (response.IsSuccessStatusCode)
                {
                    return newEvent;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return null;
        }

        public async Task<Museum> UpdateMuseum(Museum updatedMuseum)
        {
            string uri = "https://musei-functions.azurewebsites.net/api/UpdateMuseum?code=Z5zeu9EOmGL8kzr7NcnG_wUbXSc4cgSUggquUUCYFQ6xAzFuB7L8WA==";
            try
            {
                HttpResponseMessage response = await client.PostAsJsonAsync(uri, updatedMuseum);
                if (response.IsSuccessStatusCode)
                {
                    return updatedMuseum;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return null;
        }
    }
}
