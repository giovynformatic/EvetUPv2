using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace EventUPv2
{
    public interface IRestServiceNews
    {
        Task<List<News>> RefreshDataAsync();

        Task SaveTodoItemAsync(News item, bool isNewItem);
        Task DeleteTodoItemAsync(News ev);
    }
}