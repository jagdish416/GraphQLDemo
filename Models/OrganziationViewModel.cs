namespace GraphQL.Models
{
    [GraphQLName("Organziation")]
    [GraphQLDescription("This displays organziation data.")]
    public class OrganziationViewModel
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public string? ModifiedBy { get; set; }
        public string CreatedBy { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? ServiceDescription { get; set; }
        public string? WebsiteUrl { get; set; }
        public string? InternalNotes { get; set; }
        public bool Active { get; set; }
        public int OrganizationTypeId { get; set; }
        public ICollection<ApplicationViewModel> Applications { get; set; }
        public OrganizationTypeViewModel OrganizationType { get; set; } = null!;
        public OrganizationProfileViewModel? OrganizationProfile { get; set; }
    }
}
