using CleanArchitecture.Application.Interfaces.SmsService;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Adapters
{
    public static class Configuration
    {
        public static void RegisterAdapters(this IServiceCollection services)
        {
            services.AddTransient<ISmsService, SmsService.SmsService>();
        }
    }
}
