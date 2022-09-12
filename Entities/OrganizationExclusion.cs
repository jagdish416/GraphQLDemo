using System;
using System.Collections.Generic;

namespace GraphQL.Entities
{
    public partial class OrganizationExclusion
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public string? ModifiedBy { get; set; }
        public string CreatedBy { get; set; } = null!;
        public Guid OrganizationId { get; set; }
        public string CompanyInstanceSourceId { get; set; } = null!;
        public string BookSource { get; set; } = null!;

        public virtual Organization Organization { get; set; } = null!;
    }
}
