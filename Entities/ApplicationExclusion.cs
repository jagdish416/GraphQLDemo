using System;
using System.Collections.Generic;

namespace GraphQL.Entities
{
    public partial class ApplicationExclusion
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public string? ModifiedBy { get; set; }
        public string CreatedBy { get; set; } = null!;
        public Guid ApplicationId { get; set; }
        public string CompanyInstanceSourceId { get; set; } = null!;
        public string BookSource { get; set; } = null!;

        public virtual Application Application { get; set; } = null!;
    }
}
