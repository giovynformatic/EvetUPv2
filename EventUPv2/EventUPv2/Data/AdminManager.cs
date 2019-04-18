using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventUPv2
{
   public  class AdminManager
    {
        IRestServiceAdmin restService;

        public AdminManager(IRestServiceAdmin service)
        {
            restService = service;
        }

        public Task<List<Admin>> GetTasksAsync()
        {
            return restService.RefreshDataAsync();
        }

        public Task SaveTaskAsync(Admin item, bool isNewItem = false)
        {
            return restService.SaveTodoItemAsync(item, isNewItem);
        }
        public Task DeleteTaskAsync(Admin ad)
        {
            return restService.DeleteTodoItemAsync(ad);
        }
    }
}
