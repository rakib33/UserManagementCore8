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
    public class RoleConfiguration : IEntityTypeConfiguration<ApplicationRole>
    {
        public void Configure(EntityTypeBuilder<ApplicationRole> builder)
        {
            builder.HasData(
               new ApplicationRole
               {
                   Name = "Visitor",
                   NormalizedName = "VISITOR",
                   Id = "0"
               },
               new ApplicationRole
               {
                   Name = "Administrator",
                   NormalizedName = "ADMINISTRATOR",
                   Id = "1"
               }
               );
        }
    }
}
