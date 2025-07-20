using AuditTrailAPI.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace AuditTrailAPI.Data
{
    public class AuditDbContext : DbContext
    {
        public AuditDbContext(DbContextOptions<AuditDbContext> options) : base(options) { }

        public DbSet<AuditEntry> AuditEntries => Set<AuditEntry>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AuditEntry>()
                .Property(e => e.Changes)
                .HasConversion(
                    v => JsonConvert.SerializeObject(v),
                    v => JsonConvert.DeserializeObject<Dictionary<string, (string?, string?)>>(v) ?? new()
                );
        }
    }
}
