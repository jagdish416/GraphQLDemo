namespace GraphQL.Models
{
    [GraphQLName("Application")]
    [GraphQLDescription("This displays application data.")]
    public class ApplicationViewModel
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public string? ModifiedBy { get; set; }
        public string CreatedBy { get; set; } = null!;
        public Guid OrganizationId { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public bool ShowInMarketplace { get; set; }
        public int ServiceOfferingId { get; set; }
        public bool Active { get; set; }
        public bool? Certified { get; set; }
        public string? CertifiedBy { get; set; }
        public DateTime? CertifiedDate { get; set; }
        public int? ApplicationTypeId { get; set; }
    }
}
