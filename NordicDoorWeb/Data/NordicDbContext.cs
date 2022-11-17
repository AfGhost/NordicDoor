using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using NordicDoorWeb.Models;

namespace NordicDoorWeb.Data
{
    public class NordicDbContext : DbContext
    {
        public NordicDbContext(DbContextOptions<NordicDbContext> options) : base(options)
            /*: base("NordicDbContext")*/
        {
        }

        public DbSet<Ansatt> GetAnsatts { get; set; }
        public DbSet<Forslag> GetForslags { get; set; }
        public DbSet<Fremdrift> GetFremdrifts { get; set; }
        public DbSet<Godkjenning> GetGodkjennings { get; set; }
        public DbSet<Kostnad> GetKostnads { get; set; }
        public DbSet<Navn> GetNavns { get; set; }
        public DbSet<RapporterProblem> GetRapporterProblems { get; set; }
        public DbSet<Roller> GetRollers { get; set; }
        public DbSet<Status> GetStatus { get; set; }
        public DbSet<T_medlemmer> GetT_medlemmer { get; set; }
        public DbSet<Teams> GetTeams { get; set; }
        public DbSet<Tidsperiode> GetTidsperiode { get; set; }


        /*
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
        */
    }
}
