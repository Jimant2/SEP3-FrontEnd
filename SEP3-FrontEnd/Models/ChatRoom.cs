using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEP3_FrontEnd.Models
{
    public class ChatRoom
    {
        public ChatRoom(string id, IList<Message> messages)
        {
            Id = id;
            Messages = new List<Message>();
        }

        public string Id { get; set; }
        public IList<Message> Messages { get; set; }
    }
}
