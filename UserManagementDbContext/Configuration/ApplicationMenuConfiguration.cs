using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagementModel.EntityModels;

namespace UserManagementDbContext.Configuration
{
    public class ApplicationMenuConfiguration : IEntityTypeConfiguration<ApplicationMenu>
    {
        public void Configure(EntityTypeBuilder<ApplicationMenu> builder)
        {
            builder.ToTable("ApplicationMenu");
            builder.HasKey(l => l.Id);

            builder.HasIndex(l => l.Id);
            builder.HasIndex(l => l.IsActive);
            builder.HasIndex(l => l.IsRootMenu);
            builder.HasIndex(l => l.IsSubMenu);
        }
    }
}
