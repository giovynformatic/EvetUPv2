using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
namespace EventUPv2
{
    public interface IRestServiceUser
    {
        Task<List<UserToBack>> RefreshDataAsync();

        Task SaveTodoItemAsync(UserToBack item, bool isNewItem);
        Task DeleteTodoItemAsync(UserToBack us);

    }
}
