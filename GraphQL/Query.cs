using AutoMapper;
using AutoMapper.QueryableExtensions;
using GraphQL.Entities;
using GraphQL.Models;

namespace GraphQL.GraphQL
{
    public class Query
    {
        [UseDbContext(typeof(OrganizationManagementContext))]
        [UsePaging(IncludeTotalCount = true)]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<OrganizationContactViewModel> GetOrganziationContact([ScopedService] OrganizationManagementContext context, [Service] IMapper mapper)
        {
            return context.OrganizationContacts
                 .ProjectTo<OrganizationContactViewModel>(mapper.ConfigurationProvider); ;
        }

        [UseDbContext(typeof(OrganizationManagementContext))]
        [UsePaging(IncludeTotalCount = true)]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<OrganziationViewModel> GetOrganizations([ScopedService] OrganizationManagementContext context, [Service] IMapper mapper)
        {
            return context.Organizations
                .ProjectTo<OrganziationViewModel>(mapper.ConfigurationProvider);
        }

        [UseDbContext(typeof(OrganizationManagementContext))]
        [UsePaging(IncludeTotalCount = true)]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<ApplicationViewModel> GetApplications([ScopedService] OrganizationManagementContext context, [Service] IMapper mapper)
        {
            return context.Applications
            .ProjectTo<ApplicationViewModel>(mapper.ConfigurationProvider);
        }

        [UseDbContext(typeof(OrganizationManagementContext))]
        [UsePaging(IncludeTotalCount = true)]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<ApplicationTypeViewModel> GetApplicationTypes([ScopedService] OrganizationManagementContext context, [Service] IMapper mapper)
        {
            return context.ApplicationTypes
                 .ProjectTo<ApplicationTypeViewModel>(mapper.ConfigurationProvider); ;
        }

        [UseDbContext(typeof(OrganizationManagementContext))]
        [UsePaging(IncludeTotalCount = true)]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<OrganizationProfileViewModel> GetOrganizationProfile([ScopedService] OrganizationManagementContext context, [Service] IMapper mapper)
        {
            return context.OrganizationProfiles
            .ProjectTo<OrganizationProfileViewModel>(mapper.ConfigurationProvider);
        }

    }
}
