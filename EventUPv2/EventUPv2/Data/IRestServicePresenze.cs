using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EventUPv2
{
    public interface IRestServicePresenze
    {

        Task<List<String>> RefreshDataAsync();

        Task SaveTodoItemAsync(String item, bool isNewItem);
        Task DeleteTodoItemAsync(String ad);
    }
}