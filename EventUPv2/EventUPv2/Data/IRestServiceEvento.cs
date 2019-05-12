using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EventUPv2
{
    public interface IRestServiceEvento
    {
        Task<List<Evento>> RefreshDataAsync(int tipo);

        Task SaveTodoItemAsync(Evento item, bool isNewItem);
        Task DeleteTodoItemAsync(Evento ev);
    }
}
