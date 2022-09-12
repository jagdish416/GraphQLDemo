using System;
using System.Collections.Generic;

namespace GraphQL.Entities
{
    public partial class ApplicationRequiredProductCenter
    {
        public string ProductCenterId { get; set; } = null!;
        public Guid ApplicationId { get; set; }

        public virtual Application Application { get; set; } = null!;
    }
}
