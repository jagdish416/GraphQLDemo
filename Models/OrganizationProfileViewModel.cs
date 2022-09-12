namespace GraphQL.Models
{
    [GraphQLName("OrganizationProfile")]
    public class OrganizationProfileViewModel
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public string? ModifiedBy { get; set; }
        public string CreatedBy { get; set; } = null!;
        public string? LogoUri { get; set; }
        public bool Certified { get; set; }
        public int PricingPlanId { get; set; }
        public Guid OrganizationId { get; set; }
        public string? ShortDescription { get; set; }
    }
}
