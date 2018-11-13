using Janus.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Janus.Persistence.Configurations
{
    class CategoriesConfiguration : IEntityTypeConfiguration<Categories>
    {
        
        public void Configure(EntityTypeBuilder<Categories> builder)
        {
            

            builder.HasKey(x => x.ID);
        }
    }
}
