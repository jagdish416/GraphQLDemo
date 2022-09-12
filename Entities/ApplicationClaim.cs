using System;
using System.Collections.Generic;

namespace GraphQL.Entities
{
    public partial class ApplicationClaim
    {
        public Guid ApplicationId { get; set; }
        public string Key { get; set; } = null!;
        public string Value { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public string? ModifiedBy { get; set; }
        public string CreatedBy { get; set; } = null!;

        public virtual Application Application { get; set; } = null!;
    }
}
