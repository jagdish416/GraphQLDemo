using System;
using System.Collections.Generic;

namespace GraphQL.Entities
{
    public partial class Service
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string ShortDescription { get; set; } = null!;
        public string? Image { get; set; }
        public string Icon { get; set; } = null!;
        public bool? Active { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public string? ModifiedBy { get; set; }
        public string CreatedBy { get; set; } = null!;
    }
}
