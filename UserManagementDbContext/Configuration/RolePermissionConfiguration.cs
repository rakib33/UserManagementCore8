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
    public class RolePermissionConfiguration : IEntityTypeConfiguration<RolePermission>
    {
        public void Configure(EntityTypeBuilder<RolePermission> builder)
        {
            builder.ToTable("RolePermission");
            builder.HasKey(t => t.Id);

            builder.HasIndex(t => t.Id);
            builder.HasIndex(t => t.RoleId);
            builder.HasIndex(t => t.CompanyId);
            builder.HasIndex(t => t.ApplicationMenuId);
        }
    }
}
