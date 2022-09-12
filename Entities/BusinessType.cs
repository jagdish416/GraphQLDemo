using System;
using System.Collections.Generic;

namespace GraphQL.Entities
{
    public partial class BusinessType
    {
        public BusinessType()
        {
            Organizations = new HashSet<Organization>();
        }

        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public string? ModifiedBy { get; set; }
        public string CreatedBy { get; set; } = null!;
        public string Name { get; set; } = null!;

        public virtual ICollection<Organization> Organizations { get; set; }
    }
}
