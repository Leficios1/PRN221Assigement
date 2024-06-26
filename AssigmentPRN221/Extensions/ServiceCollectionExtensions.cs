﻿using DataAccessObject.Repository;
using DataAccessObject.Repository.Interface;
using Services.Services;
using Services.Services.Interface;

namespace AssigmentPRN221.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection Register(this IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddEndpointsApiExplorer();

            //Config AutoMapper
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            //Register Repository
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IPetRepository, PetRepository>();
            //Register Services
            services.AddScoped<IUserServices, UserServices>();
            services.AddScoped<IPetServices,PetServices>();

            return services;
        }
    }
}
