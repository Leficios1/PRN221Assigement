using DataAccessObject.Database;
using Microsoft.EntityFrameworkCore;

namespace AssigmentPRN221
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            Extensions.ServiceCollectionExtensions.Register(builder.Services);

            //Conntect With DB
            builder.Services.AddDbContext<PetManagementContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("PetHealthCareSystem"));
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}