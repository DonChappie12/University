using Microsoft.EntityFrameworkCore;

namespace UniversityApp.Models
{
    public class UserContext : DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<Class> Class { get; set; }
        public DbSet<Grades> Grade { get; set; }
        public DbSet<Post> Post { get; set; }
        public DbSet<Message> Message { get; set; }
        public DbSet<Attendant> Attendant { get; set; }
        public UserContext(DbContextOptions<UserContext> options) : base(options) { }
    }
}