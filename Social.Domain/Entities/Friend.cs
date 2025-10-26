using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.Domain.Entities
{
    public class Friend
    {
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        public int FriendId { get; set; }

        [ForeignKey("FriendId")]
        public User FriendUser { get; set; }

        public FriendStatus Status { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }

    public enum FriendStatus
    {
        pending,
        approved,
        blocked,
        unfriend
    }
}
