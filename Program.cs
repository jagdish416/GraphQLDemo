using GraphQL;
using GraphQL.Entities;
using GraphQL.GraphQL;
using GraphQL.Server.Ui.Voyager;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEntityFrameworkSqlServer();

builder.Services
    .ConnectionString(builder.Configuration)
    .AddAutoMapper(typeof(Program))
    .AddHealthChecks();

builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddProjections()
    .AddFiltering()
    .AddSorting()
    .RegisterDbContext<OrganizationManagementContext>();


var app = builder.Build();
app.MapHealthChecks("/health");
app.MapGraphQL();
app.UseGraphQLVoyager("/graphql/ui", new VoyagerOptions
{
    GraphQLEndPoint = "/graphql"
});
app.Run();
