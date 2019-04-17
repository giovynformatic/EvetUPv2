using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EventUPv2
{
   public interface IRestServiceAdmin
    {

        Task<List<Admin>> RefreshDataAsync();

        Task SaveTodoItemAsync(Admin item, bool isNewItem);
    }
}
