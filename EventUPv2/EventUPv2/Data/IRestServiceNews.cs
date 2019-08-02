using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace EventUPv2
{
    public interface IRestServiceNews
    {
        Task<BackNews> RefreshDataAsync();

        Task SaveTodoItemAsync(BackNews item, bool isNewItem);
        Task DeleteTodoItemAsync(BackNews ev);
    }
}