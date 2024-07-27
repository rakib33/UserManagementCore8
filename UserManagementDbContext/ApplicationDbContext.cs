using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using UserManagementDbContext.Configuration;
using UserManagementModel.EntityModels;

namespace UserManagementDbContext
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser,ApplicationRole,string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
        : base(options)
        { 
        
        }
        public DbSet<Company> companies { get; set; }      
        public DbSet<RolePermission> rolePermissions { get; set; }
        public DbSet<ApplicationMenu> applicationMenus { get; set; }
        public DbSet<Language> languages { get; set; }
        public DbSet<Page> pages { get; set; }
        public DbSet<PageContentOnLanguage> pageContents {  get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {           
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<ApplicationUser>(b =>
            {
                b.ToTable("ApplicationUsers");   
            });

            builder.Entity<IdentityUserClaim<string>>(b =>
            {
                b.ToTable("ApplicationUserClaims");
            });
            //IdentityUserLogin<string>
            builder.Entity<IdentityUserLogin<string>>(b =>
            {
                b.HasKey(l => new { l.LoginProvider, l.ProviderKey });         
                b.ToTable("ApplicationUserLogins");
            });
            //IdentityUserToken<string>
            builder.Entity<IdentityUserToken<string>>(b =>
            {
                b.HasKey(l => new { l.UserId, l.LoginProvider, l.Name });
                b.ToTable("ApplicationUserTokens");
            });

            builder.Entity<ApplicationRole>(b =>
            {
                b.ToTable("ApplicationRoles");               
            });
            //IdentityRoleClaim<string>
            builder.Entity<IdentityRoleClaim<string>>(b =>
            {
                b.ToTable("ApplicationRoleClaims");
            });

            //IdentityUserRole<string>
            builder.Entity<IdentityUserRole<string>>(b =>
            {
                b.HasKey(l => new { l.UserId, l.RoleId });
                b.ToTable("ApplicationUserRoles");
            });

            builder.ApplyConfiguration(new RolePermissionConfiguration());
            builder.ApplyConfiguration(new ApplicationMenuConfiguration());
            builder.ApplyConfiguration(new RoleConfiguration());
        }
    }
}
