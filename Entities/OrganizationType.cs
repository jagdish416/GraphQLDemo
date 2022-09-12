using System;
using System.Collections.Generic;

namespace GraphQL.Entities
{
    public partial class OrganizationType
    {
        public OrganizationType()
        {
            Organizations = new HashSet<Organization>();
        }

        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public string? ModifiedBy { get; set; }
        public string CreatedBy { get; set; } = null!;
        public string? Name { get; set; }

        public virtual ICollection<Organization> Organizations { get; set; }
    }
}
