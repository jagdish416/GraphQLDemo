namespace GraphQL.Models
{
    [GraphQLName("OrganizationType")]
    public class OrganizationTypeViewModel
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public string? ModifiedBy { get; set; }
        public string CreatedBy { get; set; } = null!;
        public string? Name { get; set; }
    }
}
