using ClientPatientManagement.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FrontDesk.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration) => _configuration = configuration;

        private readonly IConfiguration _configuration;

        public void ConfigureServices(IServiceCollection services) =>
            services
                //.AddEntityFrameworkNpgsql()
                .AddDbContext<CrudContext>(options =>
                    options.UseNpgsql(_configuration.GetConnectionString("VetClinicDatabase")))
                .AddRazorPages();

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
