using ABC.Domain;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Soft.Data;
using ABC.Domain.Party;
using ABC.Infra;
using ABC.Infra.Initializers;
using ABC.Infra.Party;

namespace Soft
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddRazorPages(options => {
                /*options.Conventions.AuthorizePage("/Countries/Create");
                options.Conventions.AuthorizePage("/Countries/Delete");
                options.Conventions.AuthorizePage("/Countries/Edit");
                options.Conventions.AuthorizePage("/Currencies/Create");
                options.Conventions.AuthorizePage("/Countries/Delete");
                options.Conventions.AuthorizePage("/Countries/Edit");*/
            });

            services.AddDbContext<ABCDb>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            services.AddTransient<IPersonRepo, PersonsRepo>();
            services.AddTransient<IAddressRepo, AddressesRepo>();
            services.AddTransient<ICountriesRepo, CountriesRepo>();
            services.AddTransient<ICurrenciesRepo, CurrenciesRepo>();
            services.AddTransient<ICountryCurrenciesRepo, CountryCurrenciesRepo>();
            services.AddTransient<IPersonAddressesRepo, PersonAddressesRepo>();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
                //app.UseDatabaseErrorPage();
            }else {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            using (var scope = app.ApplicationServices.CreateScope()) {
                GetRepo.SetService(app.ApplicationServices);
                var abcDb = scope.ServiceProvider.GetService<ABCDb>();
                abcDb?.Database?.EnsureCreated();
                if (abcDb != null) AbcInitializer.Init(abcDb);
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => {
                endpoints.MapRazorPages();
            });
        }
    }
}
