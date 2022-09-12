namespace GraphQL.Models
{
    public class OrganizationContactViewModel
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public string? ModifiedBy { get; set; }
        public string CreatedBy { get; set; } = null!;
        public Guid OrganizationId { get; set; }
        public int ContactTypeId { get; set; }
        public string? Name { get; set; }
        public string? EmailAddress { get; set; }
        public string? PhoneNumber { get; set; }
        public bool Primary { get; set; }
        public bool Active { get; set; }
    }
}
