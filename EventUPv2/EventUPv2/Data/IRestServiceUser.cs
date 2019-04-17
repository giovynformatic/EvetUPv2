using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
namespace EventUPv2
{
    public interface IRestServiceUser
    {
        Task<List<User>> RefreshDataAsync();

        Task SaveTodoItemAsync(User item, bool isNewItem);

        
    }
}
