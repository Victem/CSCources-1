using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CSCources.Models
{
    public class LabelGroup
    {
        public int Id { get; set; }
        public string Text { get; set; }

        public ICollection<Label> Labels { get; set; } = new List<Label>();
    }

    public class Label
    {
        public int Id { get; set; }
        public string Text { get; set; }

        public int? GroupId { get; set; }
        public virtual LabelGroup Group { get; set; }
    }
}