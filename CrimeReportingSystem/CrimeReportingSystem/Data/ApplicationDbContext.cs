using Microsoft.EntityFrameworkCore;
using CrimeReportingSystem.Models.Entity;

namespace CrimeReportingSystem.Models.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Incident> Incidents { get; set; }
        public DbSet<Victim> Victims { get; set; }
        public DbSet<Suspect> Suspects { get; set; }
        public DbSet<LawEnforcementAgency> LawEnforcementAgencies { get; set; }
        public DbSet<Officer> Officers { get; set; }
        public DbSet<Evidence> Evidence { get; set; }
        public DbSet<Report> Reports { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Incident>(entity =>
            {
                entity.HasKey(e => e.IncidentID);
                entity.HasOne(i => i.Victim)
                      .WithMany()
                      .HasForeignKey(i => i.VictimID)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(i => i.Suspect)
                      .WithMany()
                      .HasForeignKey(i => i.SuspectID)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(i => i.Agency)
                      .WithMany()
                      .HasForeignKey(i => i.AgencyID)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Officer>(entity =>
            {
                entity.HasKey(e => e.OfficerID);
                entity.HasOne(o => o.Agency)
                      .WithMany(a => a.Officers)
                      .HasForeignKey(o => o.AgencyID)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Evidence>(entity =>
            {
                entity.HasKey(e => e.EvidenceID);
                entity.HasOne(e => e.Incident)
                      .WithMany(i => i.EvidenceList)
                      .HasForeignKey(e => e.IncidentID)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Report>(entity =>
            {
                entity.HasKey(e => e.ReportID);
                entity.HasOne(r => r.Incident)
                      .WithMany(i => i.Reports)
                      .HasForeignKey(r => r.IncidentID)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(r => r.ReportingOfficer)
                      .WithMany()
                      .HasForeignKey(r => r.ReportingOfficerID)
                      .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}