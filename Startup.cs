using EmpManagement.Data;
using EmpManagement.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace EmpManagement
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
            // Confifure DBContext with InMemory database
            services.AddDbContext<EmployeeDbContext>(optionsAction: opts =>
              opts.UseInMemoryDatabase(databaseName: Configuration.GetConnectionString(name: "MyDb")));

            // Confifure DBContext with SQL Server database
            //      services.AddDbContext<BookStoreContext>(
            //        options => options.UseSqlServer(Configuration.GetConnectionString("EmployeeDB")));

            //Configure the services
            services.AddSingleton<IEmployeeRepository,EmployeeRepository>();
            services.AddControllers().AddNewtonsoftJson();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "EmpManagement", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "EmpManagement v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            /* To set initial data of employee list */
            EmployeeDbInitializer.Seed(app);
        }
    }
}
