using System;
using System.Collections.Generic;
using System.Net.Http;
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

        public Task<List<UserToBack>> GetTasksAsync()
        {
            return restService.RefreshDataAsync();
        }

        public Task<HttpResponseMessage> SaveTaskAsync(UserToBack item, bool isNewItem = true)
        {
            return restService.SaveTodoItemAsync(item, isNewItem);
        }
        public Task DeleteTaskAsync(UserToBack us)
        {
            return restService.DeleteTodoItemAsync(us);
        }



    }
}
