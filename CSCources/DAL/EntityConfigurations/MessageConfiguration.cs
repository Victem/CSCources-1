using CSCources.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace CSCources.DAL.EntityConfigurations
{
    public class MessageConfiguration : EntityTypeConfiguration<Message>
    {
        public MessageConfiguration()
        {
            this.HasOptional(m => m.TopMessage).WithMany(m => m.ChildFromTopMessage).HasForeignKey(m => m.TopMessageId);
        }
    }
}