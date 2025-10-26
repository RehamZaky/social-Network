using Social.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.Application.DTO
{
    public class FriendDTO
    {
        public int UserId { get; set; }
        public int FriendId { get; set; }
        public FriendStatus Status { get; set; } = FriendStatus.pending;
    }
}
