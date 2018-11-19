using Janus.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Janus.Persistence.Configurations
{
    class ComputerConfiguration : IEntityTypeConfiguration<ComputerID>
    {
        public void Configure(EntityTypeBuilder<ComputerID> builder)
        {
            builder.HasKey(x => x.ID);

            builder.ToTable("ComputerID");

            builder.Property(x => x.HardDriveID)
                .HasColumnName("HardDriveID");

            builder.HasMany(x => x.Tickets)
                .WithOne(x => x.Computer);

            builder.HasMany(x => x.HardDrives)
                .WithOne(x => x.Computer);

            builder.HasMany(x => x.Network)
                .WithOne(x => x.Computer);

            builder.HasMany(x => x.WindowsUpdates)
                .WithOne(x => x.Computer);
        }
    }
}
