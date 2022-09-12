using System;
using System.Collections.Generic;

namespace GraphQL.Entities
{
    public partial class PricingPlan
    {
        public PricingPlan()
        {
            OrganizationProfiles = new HashSet<OrganizationProfile>();
        }

        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public string? ModifiedBy { get; set; }
        public string CreatedBy { get; set; } = null!;
        public string? Name { get; set; }

        public virtual ICollection<OrganizationProfile> OrganizationProfiles { get; set; }
    }
}
