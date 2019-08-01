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

        public Task<Admins> GetTasksAsync()
        {
            return restService.RefreshDataAsync();
        }

        public Task SaveTaskAsync(Admins item, bool isNewItem = false)
        {
            return restService.SaveTodoItemAsync(item, isNewItem);
        }
        public Task DeleteTaskAsync(Admins ad)
        {
            return restService.DeleteTodoItemAsync(ad);
        }
    }
}
