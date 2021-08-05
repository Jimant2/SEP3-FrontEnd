using SEP3_FrontEndWEAPI.Models;
using SEP3_FrontEndWEBAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEP3_FrontEndWEBAPI.Data.Impl
{
    public class ChatService : IChatService
    {
        private IList<User> UsersFromRooms;
        private IList<ChatRoom> ChatRooms;

        public ChatService()
        {
            UsersFromRooms = new List<User>();
        }

        public async Task AddMessage(Message message, int chatRoomId)
        {
            ChatRoom room = ChatRooms.FirstOrDefault(u => u.Id.Equals(chatRoomId));
            room.Messages.Add(message);
        }

        public async Task ConnectToChat(int userId, string name)
        {
            User user = new User();
            user.Id = userId;
            user.SecurityLevel = 2;
            user.UserName = name;
            UsersFromRooms.Add(user);
        }

        public async Task<ChatRoom> DisconnectUser(int userId)
        {
            User userToDisconnect = await GetUserById(userId);
            ChatRoom roomToDisconnectFrom = await GetRoom(userToDisconnect.CurrentRoom);
            UsersFromRooms.Remove(userToDisconnect);

            return roomToDisconnectFrom;
        }

        public async Task<ChatRoom> GetRoom(string roomId)
        {
            ChatRoom find = ChatRooms.FirstOrDefault(r => r.Id.Equals(roomId));
            return find;
        }

        public async Task<User> GetUserById(int userId)
        {
            User find = UsersFromRooms.FirstOrDefault(r => r.Id.Equals(userId));
            if (find != null)
            {
                return find;
            }

            return null;
        }
    }
}
