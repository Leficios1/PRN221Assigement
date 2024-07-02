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

            //Register Session
            services.AddDistributedMemoryCache();
            services.AddSession(option =>
            {
                option.IdleTimeout = TimeSpan.FromMinutes(30);
                option.Cookie.HttpOnly = true;
                option.Cookie.IsEssential = true;
            });

            //RegisterHttpContext
            services.AddHttpContextAccessor();

            //Register Repository
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IPetRepository, PetRepository>();
            services.AddScoped<IPetRecordRepository, PetRecordRepository>();
            services.AddScoped<IVetRepository, VetRepository>();
            services.AddScoped<IKennelRepository, KennelRepository>();
            services.AddScoped<IKennelRecordRepository, KennelRecordRepository>();
            services.AddScoped<IBookingRepository, BookingRepository>();    
            services.AddScoped<IServicesRepository, ServicesRepository>();

            //Register Services
            services.AddScoped<IUserServices, UserServices>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IPetServices,PetServices>();
            services.AddScoped<IPetRecordServices, PetRecordServices>();
            services.AddScoped<IUserServices, UserServices>();
            services.AddScoped<IPetServices,PetServices>();
            services.AddScoped<IKennelService,KennelService>();
            services.AddScoped<IKennelRecordService, KennelRecordService>();
            services.AddScoped<IBookingServices, BookingServices>();
            services.AddScoped<IVetServices, VetServices>();
            services.AddScoped<IServiceServices, ServiceServices>();
            return services;
        }
    }
}
