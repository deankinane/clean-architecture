using CleanArchitecture.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using CleanArchitecture.Application.Activities.Commands.CreateActivity;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Application.Contacts.DTOs;
using CleanArchitecture.Application.Contacts.Commands.CreateContact;
using CleanArchitecture.Application.Contacts.Commands.UpdateCommand;
using CleanArchitecture.Application.Activities.DTOs;
using CleanArchitecture.Persistence.DbAccess;

namespace CleanArchitecture.Application.Infrastructure
{
    public static class ConfigureDependencyInjection
    {
        public static void ConfigureAutoMapper(this IServiceCollection services)
        {
            Mapper.Initialize(cfg =>
            {
                // Contact Mappings
                cfg.CreateMap<Contact, ContactPreviewDto>();
                cfg.CreateMap<Contact, ContactDto>();
                cfg.CreateMap<CreateContactCommand, Contact>();
                cfg.CreateMap<UpdateContactCommand, Contact>();

                // Activity Mappings
                cfg.CreateMap<CreateActivityCommand, Activity>();
                cfg.CreateMap<Activity, ActivityPreviewDto>();
                cfg.CreateMap<Activity, ActivityDto>();
            });
        }
    }
}
