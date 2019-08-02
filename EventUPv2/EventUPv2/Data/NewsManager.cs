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

        public Task<BackNews> GetTasksAsync()
        {
            return restService.RefreshDataAsync();
        }

        public Task SaveTaskAsync(BackNews item, bool isNewItem = false)
        {
            return restService.SaveTodoItemAsync(item, isNewItem);
        }
        public Task DeleteTaskAsync(BackNews ad)
        {
            return restService.DeleteTodoItemAsync(ad);
        }
    }
}