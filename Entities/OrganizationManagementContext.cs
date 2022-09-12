using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace GraphQL.Entities
{
    public partial class OrganizationManagementContext : DbContext
    {
        //public OrganizationManagementContext()
        //{
        //}

        public OrganizationManagementContext(DbContextOptions<OrganizationManagementContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AcceptedTermOfUse> AcceptedTermOfUses { get; set; } = null!;
        public virtual DbSet<Application> Applications { get; set; } = null!;
        public virtual DbSet<ApplicationBlackBookSource> ApplicationBlackBookSources { get; set; } = null!;
        public virtual DbSet<ApplicationClaim> ApplicationClaims { get; set; } = null!;
        public virtual DbSet<ApplicationExclusion> ApplicationExclusions { get; set; } = null!;
        public virtual DbSet<ApplicationRequiredProductCenter> ApplicationRequiredProductCenters { get; set; } = null!;
        public virtual DbSet<ApplicationType> ApplicationTypes { get; set; } = null!;
        public virtual DbSet<BusinessType> BusinessTypes { get; set; } = null!;
        public virtual DbSet<ContactType> ContactTypes { get; set; } = null!;
        public virtual DbSet<FeaturedOrganization> FeaturedOrganizations { get; set; } = null!;
        public virtual DbSet<Feedback> Feedbacks { get; set; } = null!;
        public virtual DbSet<Organization> Organizations { get; set; } = null!;
        public virtual DbSet<OrganizationClaim> OrganizationClaims { get; set; } = null!;
        public virtual DbSet<OrganizationContact> OrganizationContacts { get; set; } = null!;
        public virtual DbSet<OrganizationExclusion> OrganizationExclusions { get; set; } = null!;
        public virtual DbSet<OrganizationProfile> OrganizationProfiles { get; set; } = null!;
        public virtual DbSet<OrganizationType> OrganizationTypes { get; set; } = null!;
        public virtual DbSet<PricingPlan> PricingPlans { get; set; } = null!;
        public virtual DbSet<RealpageProduct> RealpageProducts { get; set; } = null!;
        public virtual DbSet<RpxRole> RpxRoles { get; set; } = null!;
        public virtual DbSet<Service> Services { get; set; } = null!;
        public virtual DbSet<ServiceOffering> ServiceOfferings { get; set; } = null!;

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Data Source=RCDONERPXSQL101; Initial Catalog=OrganizationManagement; user id=stest; password=stest; TrustServerCertificate=True");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AcceptedTermOfUse>(entity =>
            {
                entity.ToTable("AcceptedTermOfUse");

                entity.HasIndex(e => new { e.Version, e.UserId, e.AcceptanceDate }, "IX_AcceptedTermOfUse_Version_UserId_AcceptanceDate")
                    .IsUnique();

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.OrgMasterId).HasMaxLength(50);

                entity.Property(e => e.UserId).HasMaxLength(50);

                entity.Property(e => e.Version).HasMaxLength(50);
            });

            modelBuilder.Entity<Application>(entity =>
            {
                entity.ToTable("Application");

                entity.HasIndex(e => e.ApplicationTypeId, "IX_Application_ApplicationTypeId");

                entity.HasIndex(e => e.OrganizationId, "IX_Application_OrganizationId");

                entity.HasIndex(e => e.ServiceOfferingId, "IX_Application_ServiceOfferingId");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Certified)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.Name).HasMaxLength(200);

                entity.HasOne(d => d.ApplicationType)
                    .WithMany(p => p.Applications)
                    .HasForeignKey(d => d.ApplicationTypeId);

                entity.HasOne(d => d.Organization)
                    .WithMany(p => p.Applications)
                    .HasForeignKey(d => d.OrganizationId);

                entity.HasOne(d => d.ServiceOffering)
                    .WithMany(p => p.Applications)
                    .HasForeignKey(d => d.ServiceOfferingId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasMany(d => d.RealpageProducts)
                    .WithMany(p => p.Applications)
                    .UsingEntity<Dictionary<string, object>>(
                        "ApplicationRealpageProduct",
                        l => l.HasOne<RealpageProduct>().WithMany().HasForeignKey("RealpageProductId"),
                        r => r.HasOne<Application>().WithMany().HasForeignKey("ApplicationId"),
                        j =>
                        {
                            j.HasKey("ApplicationId", "RealpageProductId");

                            j.ToTable("ApplicationRealpageProduct");

                            j.HasIndex(new[] { "RealpageProductId" }, "IX_ApplicationRealpageProduct_RealpageProductId");
                        });
            });

            modelBuilder.Entity<ApplicationBlackBookSource>(entity =>
            {
                entity.ToTable("ApplicationBlackBookSource");

                entity.HasIndex(e => new { e.ApplicationId, e.BlackBookSourceId }, "IX_ApplicationBlackBookSource_ApplicationId_BlackBookSourceId")
                    .IsUnique();

                entity.Property(e => e.BlackBookSourceId).HasMaxLength(100);

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getutcdate())");

                entity.HasOne(d => d.Application)
                    .WithMany(p => p.ApplicationBlackBookSources)
                    .HasForeignKey(d => d.ApplicationId);
            });

            modelBuilder.Entity<ApplicationClaim>(entity =>
            {
                entity.HasKey(e => new { e.Key, e.ApplicationId });

                entity.ToTable("ApplicationClaim");

                entity.Property(e => e.Key).HasMaxLength(414);

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.Value).IsUnicode(false);

                entity.HasOne(d => d.Application)
                    .WithMany(p => p.ApplicationClaims)
                    .HasForeignKey(d => d.ApplicationId);
            });

            modelBuilder.Entity<ApplicationExclusion>(entity =>
            {
                entity.ToTable("ApplicationExclusion");

                entity.HasIndex(e => new { e.ApplicationId, e.CompanyInstanceSourceId, e.BookSource }, "IX_ApplicationExclusion_ApplicationId_CompanyInstanceSourceId_BookSource");

                entity.Property(e => e.BookSource).HasMaxLength(50);

                entity.Property(e => e.CompanyInstanceSourceId).HasMaxLength(500);

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getutcdate())");

                entity.HasOne(d => d.Application)
                    .WithMany(p => p.ApplicationExclusions)
                    .HasForeignKey(d => d.ApplicationId);
            });

            modelBuilder.Entity<ApplicationRequiredProductCenter>(entity =>
            {
                entity.HasKey(e => new { e.ProductCenterId, e.ApplicationId });

                entity.ToTable("ApplicationRequiredProductCenter");

                entity.HasIndex(e => new { e.ApplicationId, e.ProductCenterId }, "IX_ApplicationRequiredProductCenter_ApplicationId_ProductCenterId")
                    .IsUnique();

                entity.HasOne(d => d.Application)
                    .WithMany(p => p.ApplicationRequiredProductCenters)
                    .HasForeignKey(d => d.ApplicationId);
            });

            modelBuilder.Entity<ApplicationType>(entity =>
            {
                entity.ToTable("ApplicationType");

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<BusinessType>(entity =>
            {
                entity.ToTable("BusinessType");

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<ContactType>(entity =>
            {
                entity.ToTable("ContactType");

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<FeaturedOrganization>(entity =>
            {
                entity.HasIndex(e => e.OrganizationId, "IX_FeaturedOrganizations_OrganizationId");

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getutcdate())");

                entity.HasOne(d => d.Organization)
                    .WithMany(p => p.FeaturedOrganizations)
                    .HasForeignKey(d => d.OrganizationId);
            });

            modelBuilder.Entity<Feedback>(entity =>
            {
                entity.ToTable("Feedback");

                entity.HasIndex(e => e.OrganizationId, "IX_Feedback_OrganizationId");

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.Role).HasMaxLength(100);

                entity.Property(e => e.Testimonial).IsUnicode(false);

                entity.HasOne(d => d.Organization)
                    .WithMany(p => p.Feedbacks)
                    .HasForeignKey(d => d.OrganizationId);
            });

            modelBuilder.Entity<Organization>(entity =>
            {
                entity.ToTable("Organization");

                entity.HasIndex(e => e.OrganizationTypeId, "IX_Organization_OrganizationTypeId");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.InternalNotes).IsUnicode(false);

                entity.Property(e => e.Name).HasMaxLength(500);

                entity.Property(e => e.ServiceDescription).IsUnicode(false);

                entity.Property(e => e.WebsiteUrl)
                    .IsUnicode(false)
                    .HasColumnName("WebsiteURL");

                entity.HasOne(d => d.OrganizationType)
                    .WithMany(p => p.Organizations)
                    .HasForeignKey(d => d.OrganizationTypeId);

                entity.HasMany(d => d.BusinessTypes)
                    .WithMany(p => p.Organizations)
                    .UsingEntity<Dictionary<string, object>>(
                        "OrganizationBusinessType",
                        l => l.HasOne<BusinessType>().WithMany().HasForeignKey("BusinessTypeId"),
                        r => r.HasOne<Organization>().WithMany().HasForeignKey("OrganizationId"),
                        j =>
                        {
                            j.HasKey("OrganizationId", "BusinessTypeId");

                            j.ToTable("OrganizationBusinessType");

                            j.HasIndex(new[] { "BusinessTypeId" }, "IX_OrganizationBusinessType_BusinessTypeId");
                        });
            });

            modelBuilder.Entity<OrganizationClaim>(entity =>
            {
                entity.HasKey(e => new { e.Key, e.OrganizationId });

                entity.ToTable("OrganizationClaim");

                entity.Property(e => e.Key).HasMaxLength(414);

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.Value).IsUnicode(false);

                entity.HasOne(d => d.Organization)
                    .WithMany(p => p.OrganizationClaims)
                    .HasForeignKey(d => d.OrganizationId);
            });

            modelBuilder.Entity<OrganizationContact>(entity =>
            {
                entity.ToTable("OrganizationContact");

                entity.HasIndex(e => e.ContactTypeId, "IX_OrganizationContact_ContactTypeId");

                entity.HasIndex(e => e.OrganizationId, "IX_OrganizationContact_OrganizationId");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.EmailAddress).HasMaxLength(256);

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.PhoneNumber).HasMaxLength(15);

                entity.HasOne(d => d.ContactType)
                    .WithMany(p => p.OrganizationContacts)
                    .HasForeignKey(d => d.ContactTypeId);

                entity.HasOne(d => d.Organization)
                    .WithMany(p => p.OrganizationContacts)
                    .HasForeignKey(d => d.OrganizationId);
            });

            modelBuilder.Entity<OrganizationExclusion>(entity =>
            {
                entity.ToTable("OrganizationExclusion");

                entity.HasIndex(e => new { e.OrganizationId, e.CompanyInstanceSourceId, e.BookSource }, "IX_OrganizationExclusion_OrganizationId_CompanyInstanceSourceId_BookSource");

                entity.Property(e => e.BookSource)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(N'')");

                entity.Property(e => e.CompanyInstanceSourceId).HasMaxLength(500);

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getutcdate())");

                entity.HasOne(d => d.Organization)
                    .WithMany(p => p.OrganizationExclusions)
                    .HasForeignKey(d => d.OrganizationId);
            });

            modelBuilder.Entity<OrganizationProfile>(entity =>
            {
                entity.ToTable("OrganizationProfile");

                entity.HasIndex(e => e.OrganizationId, "IX_OrganizationProfile_OrganizationId")
                    .IsUnique();

                entity.HasIndex(e => e.PricingPlanId, "IX_OrganizationProfile_PricingPlanId");

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.LogoUri).IsUnicode(false);

                entity.Property(e => e.ShortDescription)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.Organization)
                    .WithOne(p => p.OrganizationProfile)
                    .HasForeignKey<OrganizationProfile>(d => d.OrganizationId);

                entity.HasOne(d => d.PricingPlan)
                    .WithMany(p => p.OrganizationProfiles)
                    .HasForeignKey(d => d.PricingPlanId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<OrganizationType>(entity =>
            {
                entity.ToTable("OrganizationType");

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<PricingPlan>(entity =>
            {
                entity.ToTable("PricingPlan");

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<RealpageProduct>(entity =>
            {
                entity.ToTable("RealpageProduct");

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.Name).HasMaxLength(200);

                entity.Property(e => e.WebsiteUrl)
                    .IsUnicode(false)
                    .HasColumnName("WebsiteURL");
            });

            modelBuilder.Entity<RpxRole>(entity =>
            {
                entity.ToTable("RpxRole");

                entity.HasIndex(e => e.ShortName, "IX_RpxRole_ShortName")
                    .IsUnique();

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.DisplayName).HasMaxLength(256);

                entity.Property(e => e.ShortName).HasMaxLength(20);
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.ToTable("Service");

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(1)))");

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.ShortDescription).HasMaxLength(200);
            });

            modelBuilder.Entity<ServiceOffering>(entity =>
            {
                entity.ToTable("ServiceOffering");

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.Restricted)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
