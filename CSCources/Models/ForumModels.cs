using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
/// <summary>
/// есть три понятия
/// 1 - поток ( он же форум )
/// 2 - тема ( Message, IsTop = true )
/// 3 - сообщение ( Message, IsTop = false)
/// </summary>


namespace CSCources.Models
{

    /// <summary>
    /// поток сообщений, например поток сообщений в статье, 
    /// или поток сообщений к группе курса, 
    /// или поток сообщений на форуме ( один форум соответсвует одному потоку )
    /// </summary>
    public class Thread
    {
        public int Id { get; set; }

        public string Title { get; set; }

        /// <summary>
        /// краткое описание потока
        /// </summary>
        public string Promo { get; set; }

        public virtual ICollection<Message> Messages { get; set; } = new List<Message>();

        public bool IsBlocked { get; set; } = false;

        public bool IsPined { get; set; } = false;

        /// <summary>
        /// автор потока
        /// </summary>
        public ApplicationUser User { get; set; }

        public DateTime PublishDate { get; set; }

        /// <summary>
        /// определяет номер потока в общем порядке, то есть на каком месте находится данный поток внутри родителского потока
        /// это поле необходимо для сортировки потоков по порядку, по сути это порядковый номер
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// те метки которые присоединяются к сообщениям по умолчанию
        /// </summary>
        public virtual ICollection<Label> Labels { get; set; } = new List<Label>();
    }

    /// <summary>
    /// на уровне отображения у нас структура сообщений - двухуровневая, верхнее сообщение в дереве 
    /// помечается как IsTop = true, у всех ответов на него IsTop = false
    /// по сути IsTop сообщение это тема, а все его дочерние сообщения это ответы
    /// </summary>
    public class Message
    {
        public int Id { get; set; }

        public int ThreadId { get; set; }

        public virtual Thread Thread { get; set; }


        public int? ParentMessageId { get; set; }

        /// <summary>
        /// родительское сообщение, то есть то сообщение на кого идет ответ
        /// необходимо для выстраивания цепочек общения и для отсылки писем тем на чье сообщение получен ответ
        /// </summary>
        public virtual Message ParentMessage { get; set; }

        //public virtual ICollection<Message>  ChildMessages

        public int? TopMessageId { get; set; }

        /// <summary>
        /// к какой теме идет сообщение
        /// </summary>
        public virtual Message TopMessage { get; set; }

        public virtual ICollection<Message> ChildFromTopMessage { get; set; } = new List<Message>();

        public string Text { get; set; }

        /// <summary>
        /// является ли сообщения темой
        /// </summary>
        public bool IsTop { get; set; }

        public DateTime PublishDate { get; set; }

        public DateTime EditDate { get; set; }

        /// <summary>
        /// автор сообщения
        /// </summary>
        public ApplicationUser User { get; set; }

        /// <summary>
        /// метки
        /// </summary>
        public virtual ICollection<Label> Labels { get; set; } = new List<Label>();
    }
}