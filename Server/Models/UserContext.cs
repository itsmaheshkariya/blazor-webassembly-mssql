using Microsoft.EntityFrameworkCore;
using BlazorSql.Shared;
namespace BlazorSql.Server.Models {
    public class UserContext : DbContext {
        public UserContext (DbContextOptions<UserContext> options) : base (options) { }
        public DbSet<User> Users { get; set; }
    }
}
