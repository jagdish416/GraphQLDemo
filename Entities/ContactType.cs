using System;
using System.Collections.Generic;

namespace GraphQL.Entities
{
    public partial class ContactType
    {
        public ContactType()
        {
            OrganizationContacts = new HashSet<OrganizationContact>();
        }

        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public string? ModifiedBy { get; set; }
        public string CreatedBy { get; set; } = null!;
        public string Name { get; set; } = null!;

        public virtual ICollection<OrganizationContact> OrganizationContacts { get; set; }
    }
}
