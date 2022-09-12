using AutoMapper;
using GraphQL.Entities;
using GraphQL.Models;

namespace GraphQL.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Organization, OrganziationViewModel>();
            CreateMap<Application, ApplicationViewModel>();
            CreateMap<OrganizationType, OrganizationTypeViewModel>();
            CreateMap<OrganizationProfile, OrganizationProfileViewModel>();
            CreateMap<ApplicationType, ApplicationTypeViewModel>();
            CreateMap<OrganizationContact, OrganizationContactViewModel>();
        }

    }
}
