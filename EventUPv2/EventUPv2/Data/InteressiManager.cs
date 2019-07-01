using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventUPv2
{
    public class InteressiManager
    {

        IRestServiceInteressi restService;

        public InteressiManager(IRestServiceInteressi service)
        {
            restService = service;
        }

        public Task<List<Interessi>> GetTasksAsync()
        {
            return restService.RefreshDataAsync();
        }

        public Task SaveTaskAsync(Interessi item, bool isNewItem = false)
        {
            return restService.SaveTodoItemAsync(item, isNewItem);
        }
        public Task DeleteTaskAsync(Interessi ad)
        {
            return restService.DeleteTodoItemAsync(ad);
        }
    }
}