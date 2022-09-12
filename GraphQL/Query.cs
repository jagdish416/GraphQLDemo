using GraphQL.Entities;

namespace GraphQL.GraphQL
{
    public class Query
    {
        public IQueryable<OrganizationContact> GetOrganziationContact([Service] OrganizationManagementContext context)
        {
            return context.OrganizationContacts;
        }

        public string Hello(string name = "World") => $"Hello, {name}";
    }
}
