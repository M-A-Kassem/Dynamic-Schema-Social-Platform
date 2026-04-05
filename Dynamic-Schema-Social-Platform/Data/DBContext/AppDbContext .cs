using Dynamic_Schema_Social_Platform.Enteties;
using Microsoft.EntityFrameworkCore;

namespace Dynamic_Schema_Social_Platform.Data.DBContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<TalentType> TalentTypes { get; set; }
        public DbSet<UserTalent> UserTalents { get; set; }
        public DbSet<TalentAttribute> TalentAttributes { get; set; }
        public DbSet<UserTalentData> UserTalentData { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<UserTalent>()
                .HasKey(ut => new { ut.UserId, ut.TalentTypeId });

            modelBuilder.Entity<UserTalentData>()
                .HasKey(ud => new { ud.UserId, ud.AttributeId });
        }
    }
}
