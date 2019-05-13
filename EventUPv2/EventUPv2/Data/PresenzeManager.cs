using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace EventUPv2

{
  public  class PresenzeManager
    {
        IRestServicePresenze restService;

        public PresenzeManager(IRestServicePresenze service)
        {
            restService = service;
        }

        public Task<List<String>> GetTasksAsync()
        {
            return restService.RefreshDataAsync();
        }

        public Task SaveTaskAsync(String item, bool isNewItem = false)
        {
            return restService.SaveTodoItemAsync(item, isNewItem);
        }
        public Task DeleteTaskAsync(String ad)
        {
            return restService.DeleteTodoItemAsync(ad);
        }
    }
}