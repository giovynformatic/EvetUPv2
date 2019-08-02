using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
namespace EventUPv2
{
    public interface IRestServiceUser
    {
        Task<List<UserToBack>> RefreshDataAsync();

        Task<HttpResponseMessage> SaveTodoItemAsync(UserToBack item, bool isNewItem);
        Task DeleteTodoItemAsync(UserToBack us);

    }
}
