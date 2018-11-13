using Janus.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Janus.Persistence.Configurations
{
    class TicketConfiguration : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            // Defines Key
            builder.HasKey(x => x.ID);
            
            // Defines column type
            builder.Property(x => x.DateTimeCreated).HasColumnType("datetime");
            builder.Property(x => x.DateTimeEdited).HasColumnType("datetime");
            builder.Property(x => x.CreatedBy);
            builder.Property(x => x.TicketOwner);
            builder.Property(x => x.SubmittedBy);                      

        }
    }
}
