using System.Data.Entity;

namespace GymManagement.Models
{
    public class GymDbContext : DbContext
    {
        public GymDbContext() : base("GymConnection") { }

        public DbSet<Member> Members { get; set; }

        public DbSet<Trainer> Trainers { get; set; }

        public DbSet<Package> Packages { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<TrialRegistration> TrialRegistrations { get; set; }



    }
}
