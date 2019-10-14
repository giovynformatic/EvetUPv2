using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace EventUPv2
{

    public class RestServiceUser : IRestServiceUser
    {
        HttpClient _client;

        public List<UserToBack> Items { get; private set; }

        public RestServiceUser()
        {
            _client = new HttpClient();
        }

        public async Task<List<UserToBack>> RefreshDataAsync()
        {
            Items = new List<UserToBack>();

            var uri = new Uri(string.Format(Constants.UserUrl, string.Empty));
            try
            {
                var response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Items = JsonConvert.DeserializeObject<List<UserToBack>>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return Items;
        }

        public async Task<HttpResponseMessage> SaveTodoItemAsync(UserToBack item, bool isNewItem)
        {
            var uri = new Uri(string.Format(Constants.RegisterUserUrl, string.Empty));

            try
            {
                var json = JsonConvert.SerializeObject(item);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;
                if (isNewItem)
                {
                    response =  _client.PostAsync(uri, content).Result;
                    return response;
                }
                else
                {
                    response = _client.PutAsync(uri, content).Result;
                    return response;
                }

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"\tTodoItem successfully saved.");
                }
                else { Debug.WriteLine("registraione fallita"); }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
                return null ;
            }
        }

        public async Task DeleteTodoItemAsync(UserToBack us)
        {
            var uri = new Uri(string.Format(Constants.UserUrl, us));

            try
            {
                var response = await _client.DeleteAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"\tTodoItem successfully deleted.");
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
        }

    }
}
