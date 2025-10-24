using Social.Domain.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.Domain.Entities
{
    public class PostInteraction
    {
        public int Id { get; set; }

        public int PostId { get; set; }

        [ForeignKey ("PostId")]
        public Posts Posts { get; set; }

        public int UserId { get; set; }

        public User User { get; set;}

        public int InteractionType {  get; set; }  // Enum
    }

    public enum InteractionType
    {
        Like = 1,
        Love = 2,
        love = 3,
        cry = 4,
        Angry = 5
    }
}
