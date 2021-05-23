using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using Project_X_API.DataBase;
using Project_X_API.DataBase.Repositories;
using Project_X_API.Properties;
using Project_X_API.Services;
using System;

namespace Project_X_API
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
            //For AWS production deployment, change will be needed
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.WithOrigins("http://localhost:3000").SetIsOriginAllowed((host) => "http://localhost:3000"
                        .Equals(host, StringComparison.InvariantCultureIgnoreCase)).AllowAnyMethod().AllowAnyHeader());
            });

            services.AddControllers();
            services.AddTransient<RolesRepository>();
            services.AddTransient<EmailServices>();
            services.AddTransient<UserServices>();
            services.AddTransient<TokenValidationRepository>();
            services.AddTransient<UserRepository>();
            services.AddTransient<ExplosivesDataServices>();
            services.AddTransient<ExplosivesRepository>();
            //Adding DataBaseContext with MySQL options
            services.AddDbContextPool<DataBaseContext>(dbContextOptions =>
                dbContextOptions.UseMySql(Resources.ConnectionString, new MySqlServerVersion(new Version(8, 0, 24)), mySqlOptions => mySqlOptions
                      .CharSetBehavior(CharSetBehavior.NeverAppend)));

            services.AddSingleton(_ => Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseCors("CorsPolicy");

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}