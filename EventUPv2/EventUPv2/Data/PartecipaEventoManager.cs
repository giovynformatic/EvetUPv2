using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventUPv2

{
   public class PartecipaEventoManager
    {
        IRestServicePartecipaEvento restService;

        public PartecipaEventoManager(IRestServicePartecipaEvento service)
        {
            restService = service;
        }

        public Task<List<String[]>> GetTasksAsync(String Evento)
        {
            return restService.RefreshDataAsync(Evento);
        }

        public Task SaveTaskAsync(String item, bool isNewItem = false)
        {
            return restService.SaveTodoItemAsync(item, isNewItem);
        }
        public Task DeleteTaskAsync(String us)
        {
            return restService.DeleteTodoItemAsync(us);
        }

    }
}
