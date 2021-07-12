using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ResourcePlacementAPI.Context;
using ResourcePlacementAPI.Repositories.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResourcePlacementAPI
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
            services.AddControllers();
            services.AddDbContext<MyContext>(options => options.UseLazyLoadingProxies().UseSqlServer(Configuration.GetConnectionString("APIContext")));

            services.AddScoped<AccountRepository>();
            services.AddScoped<AccountRoleRepository>();
            services.AddScoped<CustomerUserRepository>();
            services.AddScoped<EmployeeRepository>();
            services.AddScoped<ParticipantRepository>();
            services.AddScoped<ParticipantSkillRepository>();
            services.AddScoped<ProjectRepository>();
            services.AddScoped<ProjectSkillRepository>();
            services.AddScoped<RoleRepository>();
            services.AddScoped<SkillRepository>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
