using System;
using System.Collections.Generic;

namespace GraphQL.Entities
{
    public partial class Feedback
    {
        public int Id { get; set; }
        public string Role { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Testimonial { get; set; } = null!;
        public bool Active { get; set; }
        public Guid OrganizationId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public string? ModifiedBy { get; set; }
        public string CreatedBy { get; set; } = null!;

        public virtual Organization Organization { get; set; } = null!;
    }
}
