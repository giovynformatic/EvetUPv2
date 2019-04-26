using System;
using System.Threading.Tasks;
namespace EventUPv2.Services
{
    public interface IQrScanningService
    {
        Task<string> ScanAsync();
    }
}
