using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CSCources.Models
{
    public class Thread
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public virtual ICollection<Message> Messages { get; set; } = new List<Message>();

        public bool IsBlocked { get; set; } = false;

        public bool IsPined { get; set; } = false;

        public ApplicationUser User { get; set; }

        public DateTime PublishDate { get; set; }
    }

    public class Message
    {
        public int Id { get; set; }

        public int ThreadId { get; set; }

        public virtual Thread Thread { get; set; }



        public string Text { get; set; }

        public DateTime PublishDate { get; set; }

        public DateTime EditDate { get; set; }

        public ApplicationUser User { get; set; }
    }
}