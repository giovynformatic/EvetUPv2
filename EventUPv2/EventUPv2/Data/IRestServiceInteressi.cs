using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace EventUPv2
{
    public interface IRestServiceInteressi
    {
        Task<Interessi> RefreshDataAsync();

       /* Task SaveTodoItemAsync(Interessi item, bool isNewItem);
        Task DeleteTodoItemAsync(Interessi ev);*/
    }
}