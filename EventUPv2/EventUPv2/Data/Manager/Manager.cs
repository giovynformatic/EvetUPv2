using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using EventUPv2.IRestService;

namespace EventUPv2.Manager
{
    

        public class Manager<T, P, S>
        {

            IRestService<T, P, S> restService;

            public Manager(IRestService<T, P, S> service)
            {
                restService = service;
            }

            public Task<T> GetTasksAsync(String link)
            {
                return restService.RefreshDataAsync(link);
            }
            public Task<T> GetTasksAsync(String link, P parametri)
            {
                return restService.RefreshDataAsync(link, parametri);
            }
            public Task<T> GetTasksAsyncnotoken(String link, P parametri)
            {
                return restService.RefreshDataAsyncnotoken(link, parametri);
            }

            public Task<HttpResponseMessage> SaveTaskAsync(P item, String link, bool isNewItem = true)
            {
                return restService.SaveTodoItemAsync(item, link, isNewItem);
            }
            public Task<HttpResponseMessage> ModifyTodoItemAsync(S item, String link, bool isNewItem = false)
            {
                return restService.ModifyTodoItemAsync(item, link, isNewItem);
            }
            public Task<HttpResponseMessage> ModifyTodoItemAsyncnotoken(S item, String link, bool isNewItem = false)
            {
                return restService.ModifyTodoItemAsyncnotoken(item, link, isNewItem);
            }


        }
    }

