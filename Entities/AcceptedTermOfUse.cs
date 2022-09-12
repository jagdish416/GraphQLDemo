using System;
using System.Collections.Generic;

namespace GraphQL.Entities
{
    public partial class AcceptedTermOfUse
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public string? ModifiedBy { get; set; }
        public string CreatedBy { get; set; } = null!;
        public string Version { get; set; } = null!;
        public string UserId { get; set; } = null!;
        public string OrgMasterId { get; set; } = null!;
        public DateTime AcceptanceDate { get; set; }
    }
}
