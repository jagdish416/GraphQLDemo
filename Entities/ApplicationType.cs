using System;
using System.Collections.Generic;

namespace GraphQL.Entities
{
    public partial class ApplicationType
    {
        public ApplicationType()
        {
            Applications = new HashSet<Application>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public string? ModifiedBy { get; set; }
        public string CreatedBy { get; set; } = null!;

        public virtual ICollection<Application> Applications { get; set; }
    }
}
