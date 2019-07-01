using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace EventUPv2
{
    public interface IRestServiceInteressi
    {
        Task<List<Interessi>> RefreshDataAsync();

        Task SaveTodoItemAsync(Interessi item, bool isNewItem);
        Task DeleteTodoItemAsync(Interessi ev);
    }
}