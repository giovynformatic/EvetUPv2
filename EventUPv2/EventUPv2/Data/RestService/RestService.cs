using System; 
using System.Collections.Generic; 
using System.Diagnostics; 
using System.Net.Http; 
using System.Net.Http.Headers;
using System.Text; 
using System.Threading.Tasks;
using EventUPv2.IRestService;
using Newtonsoft.Json;

namespace EventUPv2.RestService

{

    public class RestService<T, P, S> : IRestService<T, P, S>
    {
        HttpClient _client;

        public T Items { get; private set; }

        public RestService()
        {
            _client = new HttpClient();
        }


        public async Task<T> RefreshDataAsync(string link)
        {
            try
            {
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Constants.token);

                var response = await _client.GetAsync(new Uri(string.Format(link, string.Empty)));
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Items = JsonConvert.DeserializeObject<T>(content);
                    return Items;
                }
            }
            catch (Exception ex) { Debug.WriteLine("err" + ex.Message); }
            return default;
        }
        public async Task<T> RefreshDataAsync(String link, P item)
        {

            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Constants.token);
            try
            {
                var json = JsonConvert.SerializeObject(item);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;

                response = _client.PostAsync(new Uri(string.Format(link, string.Empty)), content).Result;



                if (response.IsSuccessStatusCode)
                {
                    var contents = await response.Content.ReadAsStringAsync();
                    Items = JsonConvert.DeserializeObject<T>(contents);

                    return Items;
                }
            }
            catch (Exception ex)
            {

                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return default;


        }
        public async Task<T> RefreshDataAsyncnotoken(String link, P item)
        {
            try
            {
                var json = JsonConvert.SerializeObject(item);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;

                response = _client.PostAsync(new Uri(string.Format(link, string.Empty)), content).Result;



                if (response.IsSuccessStatusCode)
                {
                    var contents = await response.Content.ReadAsStringAsync();
                    Items = JsonConvert.DeserializeObject<T>(contents);

                    return Items;
                }
            }
            catch (Exception ex)
            {

                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return default;


        }



        public async Task<HttpResponseMessage> SaveTodoItemAsync(P item, String link, bool isNewItem)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Constants.token);

            var uri = new Uri(string.Format(link, string.Empty));

            try
            {
                var json = JsonConvert.SerializeObject(item);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;
                if (isNewItem)
                {
                    response = _client.PostAsync(uri, content).Result;
                    return response;
                }
                else if (!isNewItem)
                {
                    response = _client.PutAsync(uri, content).Result;
                    return response;
                }

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"\tTodoItem successfully saved.");
                    return response;
                }
                else { Debug.WriteLine("registraione fallita"); return response; }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
                return null;
            }
        }

        public async Task<HttpResponseMessage> ModifyTodoItemAsync(S item, string link, bool isNewItem)
        {


            try
            {
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Constants.token);

                var json = JsonConvert.SerializeObject(item);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response;

                response = _client.PostAsync(new Uri(string.Format(link, string.Empty)), content).Result;



                if (response.IsSuccessStatusCode)
                {
                    return response;

                }
                else if (response != null)
                {
                    return response;
                }
                else return response;

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
                return null;
            }
        }
        public async Task<HttpResponseMessage> ModifyTodoItemAsyncnotoken(S item, string link, bool isNewItem)
        {


            try
            {


                var json = JsonConvert.SerializeObject(item);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response;

                response = _client.PostAsync(new Uri(string.Format(link, string.Empty)), content).Result;



                if (response.IsSuccessStatusCode)
                {
                    return response;

                }
                else if (response != null)
                {
                    return response;
                }
                else return response;

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
                return null;
            }
        }


    }
}
