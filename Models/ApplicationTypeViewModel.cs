namespace GraphQL.Models
{
    [GraphQLDescription("This displays applicationType data.")]
    public class ApplicationTypeViewModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public string? ModifiedBy { get; set; }
        public string CreatedBy { get; set; }
    }
}
