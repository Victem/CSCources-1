using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CSCources.Models
{
    #region LabelGroup
    /*
    /// <summary>
    /// Для одинаковых тегов по сути но разных по названию, например: программирование и programming
    /// или ASP.NET и asp.net
    /// или C# и Си Шарп
    /// </summary>
    public class LabelGroup
    {
        public int Id { get; set; }
        public string Text { get; set; }

        public ICollection<Label> Labels { get; set; } = new List<Label>();
    }*/
    #endregion

    public class Label
    {
        public int Id { get; set; }
        public string Text { get; set; }

        // public int? GroupId { get; set; }
        // public virtual LabelGroup Group { get; set; }
    }
}