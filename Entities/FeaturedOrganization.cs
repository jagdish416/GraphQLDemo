using System;
using System.Collections.Generic;

namespace GraphQL.Entities
{
    public partial class FeaturedOrganization
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public string? ModifiedBy { get; set; }
        public string CreatedBy { get; set; } = null!;
        public Guid OrganizationId { get; set; }
        public DateTime StartDate { get; set; }

        public virtual Organization Organization { get; set; } = null!;
    }
}
