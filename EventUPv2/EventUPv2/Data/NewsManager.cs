using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace EventUPv2

{
  public  class NewsManager
    {
        IRestServiceNews restService;

        public NewsManager(IRestServiceNews service)
        {
            restService = service;
        }

        public Task<List<News>> GetTasksAsync()
        {
            return restService.RefreshDataAsync();
        }

        public Task SaveTaskAsync(News item, bool isNewItem = false)
        {
            return restService.SaveTodoItemAsync(item, isNewItem);
        }
        public Task DeleteTaskAsync(News ad)
        {
            return restService.DeleteTodoItemAsync(ad);
        }
    }
}