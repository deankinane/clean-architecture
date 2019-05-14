using AutoMapper;
using CleanArchitecture.Application.Activities.Commands.CreateActivity;
using CleanArchitecture.Application.Activities.DTOs;
using CleanArchitecture.Application.Contacts.Commands.CreateContact;
using CleanArchitecture.Application.Contacts.Commands.UpdateCommand;
using CleanArchitecture.Application.Contacts.DTOs;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Infrastructure
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Contact, ContactPreviewDto>();
            CreateMap<Contact, ContactDto>();
            CreateMap<CreateContactCommand, Contact>();
            CreateMap<UpdateContactCommand, Contact>();

            // Activity Mappings
            CreateMap<CreateActivityCommand, Activity>();
            CreateMap<Activity, ActivityPreviewDto>();
            CreateMap<Activity, ActivityDto>();
        }
    }
}
