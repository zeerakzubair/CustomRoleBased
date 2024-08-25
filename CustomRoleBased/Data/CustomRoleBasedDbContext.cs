using CustomRoleBased.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace CustomRoleBased.Data
{
    public class CustomRoleBasedDbContext : DbContext
    {
        public CustomRoleBasedDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Page> Pages { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }

    }
}
