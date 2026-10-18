using Microsoft.EntityFrameworkCore;

namespace ERegistration.Models
{
    public class ERegistrationDbContext : DbContext
    {
        public ERegistrationDbContext(DbContextOptions<ERegistrationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure the relationships and constraints for the entities
            modelBuilder.Entity<Contractor>(contractor =>
            {
                contractor.ToTable("EReg_Contractors");
            });

            modelBuilder.Entity<BusinessType>().ToTable("LuContractorBusinessType");
            modelBuilder.Entity<PropertyOwner>().ToTable("EReg_PropertyOwners");
            modelBuilder.Entity<TitleCompany>().ToTable("EReg_TitleCompanies");
            modelBuilder.Entity<Lender>().ToTable("EReg_Lenders");
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<PropertyOwner> PropertyOwners { get; set; }
        public DbSet<Contractor> Contractors { get; set; }
        public DbSet<TitleCompany> TitleCompanies { get; set; }
        public DbSet<Lender> Lenders { get; set; }
        public DbSet<BusinessType> BusinessTypes { get; set; }
        public DbSet<LookupValue> LookupValues { get; set; }
        public DbSet<NoticeOfCommencement> NoticesOfCommencements { get; set; }
        public DbSet<NoticeOfCommencementPropertyOwner> NoticesOfCommencementPropertyOwners { get; set; }
    }
}