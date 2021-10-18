using System;
using System.Collections.Generic;
#nullable enable

namespace Librabobus.Database.Models
{
    public class Subscription
    {
        public Guid UserFromId { get; set; }
        public Guid UserToId { get; set; }

        public User? UserFrom { get; set; }
        public User? UserTo { get; set; }

        public Subscription(Guid userFromId, 
            Guid userToId)
        {
            UserFromId = userFromId;
            UserToId = userToId;
        }
    }
}