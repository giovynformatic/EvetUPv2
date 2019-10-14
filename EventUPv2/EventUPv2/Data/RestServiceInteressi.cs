﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace EventUPv2
{
    public class RestServiceInteressi : IRestServiceInteressi

    {

        HttpClient _client;

        public Interessi Items { get; private set; }

        public RestServiceInteressi()
        {
            _client = new HttpClient();
        }

        public async Task<Interessi> RefreshDataAsync()
        {
            Items = new Interessi();

            var uri = new Uri(string.Format(Constants.InteressiUrl, string.Empty));
            try
            {
                var response = _client.GetAsync(uri).Result;
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Items = JsonConvert.DeserializeObject<Interessi>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return Items;
        }

      /*  public async Task SaveTodoItemAsync(Interessi item, bool isNewItem = false)
        {
            var uri = new Uri(string.Format(Constants.InteressiUrl, string.Empty));

            try
            {
                var json = JsonConvert.SerializeObject(item);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;
                if (isNewItem)
                {
                    response = await _client.PostAsync(uri, content);
                }
                else
                {
                    response = await _client.PutAsync(uri, content);
                }

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"\tTodoItem successfully saved.");
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
        }
        public async Task DeleteTodoItemAsync(Interessi ad)
        {
            var uri = new Uri(string.Format(Constants.InteressiUrl, ad));

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
        }*/
    }
}