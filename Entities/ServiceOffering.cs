using System;
using System.Collections.Generic;

namespace GraphQL.Entities
{
    public partial class ServiceOffering
    {
        public ServiceOffering()
        {
            Applications = new HashSet<Application>();
        }

        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public string? ModifiedBy { get; set; }
        public string CreatedBy { get; set; } = null!;
        public string? Name { get; set; }
        public bool? Active { get; set; }
        public bool? Restricted { get; set; }

        public virtual ICollection<Application> Applications { get; set; }
    }
}
