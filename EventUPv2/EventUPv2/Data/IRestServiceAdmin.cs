using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EventUPv2
{
   public interface IRestServiceAdmin
    {

        Task<Admins> RefreshDataAsync();

        Task SaveTodoItemAsync(Admins item, bool isNewItem);
        Task DeleteTodoItemAsync(Admins ad);
    }
}
