using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventUPv2
{
   public class UserManager
    {

        IRestServiceUser restService;

        public UserManager(IRestServiceUser service)
        {
            restService = service;
        }

        public Task<List<User>> GetTasksAsync()
        {
            return restService.RefreshDataAsync();
        }

        public Task SaveTaskAsync(User item, bool isNewItem = false)
        {
            return restService.SaveTodoItemAsync(item, isNewItem);
        }
        public Task DeleteTaskAsync(User us)
        {
            return restService.DeleteTodoItemAsync(us);
        }



    }
}
