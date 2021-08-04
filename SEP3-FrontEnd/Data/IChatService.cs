using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEP3_FrontEnd.Models
{
   public interface IChatService
    {
        Task<User> GetUserById(int userId);
        Task AddMessage(Message message, int chatRoomId);
        Task ConnectToChat(int userId, string name);
        Task<ChatRoom> DisconnectUser(int userId);
        Task<ChatRoom> GetRoom(string roomId);
        
    }
}
