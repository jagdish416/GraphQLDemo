using System;
using System.Collections.Generic;

namespace GraphQL.Entities
{
    public partial class RpxRole
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public string? ModifiedBy { get; set; }
        public string CreatedBy { get; set; } = null!;
        public string ShortName { get; set; } = null!;
        public string DisplayName { get; set; } = null!;
        public string? Description { get; set; }
        public bool IsInternal { get; set; }
    }
}
