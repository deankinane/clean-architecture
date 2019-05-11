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

namespace CleanArchitecture.Application
{
    public static class ServiceExtensions
    {
        public static void ConfigureDBContext(this IServiceCollection services, IConfiguration config)
        {
            var connString = config["ConnectionString"];
            services.AddDbContext<DatabaseDbContext>(o => o.UseSqlServer(connString));
        }

        public static void ConfigureAutoMapper(this IServiceCollection services)
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<CreateActivityCommand, Activity>();

                cfg.CreateMap<Contact, ContactPreviewDto>()
                .ForMember(dto => dto.DisplayName, opt => opt.MapFrom(c => $"{c.FirstName} {c.LastName}"))
                .ForMember(dto => dto.NumActivities, opt => opt.MapFrom(c => c.Activities.Count));

                cfg.CreateMap<Contact, ContactDto>();
                cfg.CreateMap<CreateContactCommand, Contact>();
                cfg.CreateMap<UpdateContactCommand, Contact>();
            });
        }
    }
}
