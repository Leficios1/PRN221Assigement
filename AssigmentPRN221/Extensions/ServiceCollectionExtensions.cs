using DataAccessObject.Repository;
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
            services.AddScoped<IPetRecordRepository, PetRecordRepository>();
            services.AddScoped<IVetRepository, VetRepository>();
            services.AddScoped<IKennelRepository, KennelRepository>();
            services.AddScoped<IKennelRecordRepository, KennelRecordRepository>();
            services.AddScoped<IServiceSevices, ServiceServices>();

            //Register Services
            services.AddScoped<IUserServices, UserServices>();
            services.AddScoped<IPetServices,PetServices>();
            services.AddScoped<IPetRecordServices, PetRecordServices>();
            services.AddScoped<IUserServices, UserServices>();
            services.AddScoped<IPetServices,PetServices>();
            services.AddScoped<IKennelService,KennelService>();
            services.AddScoped<IKennelRecordService, KennelRecordService>();
            services.AddScoped<IServiceRepository, ServiceRepository>();
            return services;
        }
    }
}
