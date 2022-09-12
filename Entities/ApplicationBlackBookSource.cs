using System;
using System.Collections.Generic;

namespace GraphQL.Entities
{
    public partial class ApplicationBlackBookSource
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public string? ModifiedBy { get; set; }
        public string CreatedBy { get; set; } = null!;
        public string BlackBookSourceId { get; set; } = null!;
        public Guid ApplicationId { get; set; }

        public virtual Application Application { get; set; } = null!;
    }
}
