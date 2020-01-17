using System; 
using System.Collections.Generic; 
using System.Net.Http; 
using System.Text; 
using System.Threading.Tasks;
namespace EventUPv2.IRestService
{
    public interface IRestService<T, P, S>
    {
        Task<T> RefreshDataAsync(String link);
        Task<T> RefreshDataAsync(String link, P Parametri);
        Task<T> RefreshDataAsyncnotoken(String link, P Parametri);
        Task<HttpResponseMessage> SaveTodoItemAsync(P item, String link, bool isNewItem);
        Task<HttpResponseMessage> ModifyTodoItemAsync(S item, String link, bool isNewItem);
        Task<HttpResponseMessage> ModifyTodoItemAsyncnotoken(S item, String link, bool isNewItem);

    }
}