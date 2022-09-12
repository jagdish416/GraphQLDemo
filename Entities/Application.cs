using System;
using System.Collections.Generic;

namespace GraphQL.Entities
{
    public partial class Application
    {
        public Application()
        {
            ApplicationBlackBookSources = new HashSet<ApplicationBlackBookSource>();
            ApplicationClaims = new HashSet<ApplicationClaim>();
            ApplicationExclusions = new HashSet<ApplicationExclusion>();
            ApplicationRequiredProductCenters = new HashSet<ApplicationRequiredProductCenter>();
            RealpageProducts = new HashSet<RealpageProduct>();
        }

        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public string? ModifiedBy { get; set; }
        public string CreatedBy { get; set; } = null!;
        public Guid OrganizationId { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public bool ShowInMarketplace { get; set; }
        public int ServiceOfferingId { get; set; }
        public bool Active { get; set; }
        public bool? Certified { get; set; }
        public string? CertifiedBy { get; set; }
        public DateTime? CertifiedDate { get; set; }
        public int? ApplicationTypeId { get; set; }

        public virtual ApplicationType? ApplicationType { get; set; }
        public virtual Organization Organization { get; set; } = null!;
        public virtual ServiceOffering ServiceOffering { get; set; } = null!;
        public virtual ICollection<ApplicationBlackBookSource> ApplicationBlackBookSources { get; set; }
        public virtual ICollection<ApplicationClaim> ApplicationClaims { get; set; }
        public virtual ICollection<ApplicationExclusion> ApplicationExclusions { get; set; }
        public virtual ICollection<ApplicationRequiredProductCenter> ApplicationRequiredProductCenters { get; set; }

        public virtual ICollection<RealpageProduct> RealpageProducts { get; set; }
    }
}
