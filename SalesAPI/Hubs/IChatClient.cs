using Entities;

namespace SalesAPI.Hubs
{
    public interface IChatClient
    {
       
        Task ReceiveMessage(PublicMessage message);
        Task RecivePrivateMessage(PrivateMessage message);
    }
}
