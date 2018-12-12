using System.Threading.Tasks;

namespace SignalRDirect.Services
{
    public interface ICallCenterService
    {
        Task<bool> SaveUser(string name);
    }
}
