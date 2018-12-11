namespace SignalRDirect.Services
{
    public interface ICallCenterService
    {
        void Call();
        string GetCallStatus(); 
    }
}
