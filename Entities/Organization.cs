using System;
using System.Collections.Generic;

namespace GraphQL.Entities
{
    public partial class Organization
    {
        public Organization()
        {
            Applications = new HashSet<Application>();
            FeaturedOrganizations = new HashSet<FeaturedOrganization>();
            Feedbacks = new HashSet<Feedback>();
            OrganizationClaims = new HashSet<OrganizationClaim>();
            OrganizationContacts = new HashSet<OrganizationContact>();
            OrganizationExclusions = new HashSet<OrganizationExclusion>();
            BusinessTypes = new HashSet<BusinessType>();
        }

        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public string? ModifiedBy { get; set; }
        public string CreatedBy { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? ServiceDescription { get; set; }
        public string? WebsiteUrl { get; set; }
        public string? InternalNotes { get; set; }
        public bool Active { get; set; }
        public int OrganizationTypeId { get; set; }

        public virtual OrganizationType OrganizationType { get; set; } = null!;
        public virtual OrganizationProfile? OrganizationProfile { get; set; }
        public virtual ICollection<Application> Applications { get; set; }
        public virtual ICollection<FeaturedOrganization> FeaturedOrganizations { get; set; }
        public virtual ICollection<Feedback> Feedbacks { get; set; }
        public virtual ICollection<OrganizationClaim> OrganizationClaims { get; set; }
        public virtual ICollection<OrganizationContact> OrganizationContacts { get; set; }
        public virtual ICollection<OrganizationExclusion> OrganizationExclusions { get; set; }

        public virtual ICollection<BusinessType> BusinessTypes { get; set; }
    }
}
