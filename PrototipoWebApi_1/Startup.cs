using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PrototipoWebApi_1.Interfaces;
using PrototipoWebApi_1.Profilles;
using PrototipoWebApi_1.Repositorios;
using PrototipoWebApi_1.Services;
using Microsoft.AspNet.OData.Extensions;
using Swashbuckle.AspNetCore.Swagger;

namespace PrototipoWebApi_1
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddDbContext<RepositoryBase>(option => option.UseSqlServer(Configuration.GetConnectionString("DevConnection")));
            services.AddTransient<IDepartamentoServices, DepartamentoServices>();
            services.AddTransient<IColaboradoreServices, ColaboradorServices>();

            services.AddSwaggerGen(swagger =>
            {
                swagger.DescribeAllEnumsAsStrings();
                swagger.DescribeAllParametersInCamelCase();
                swagger.SwaggerDoc("v1", new Info { Title = "Prototipo Ing Soft 2" });
            });

            //services.AddOData();
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        //public void ConfigureServices(IServiceCollection services)
        //{
        //    services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        //    services.AddDbContext<RepositoryBase>(option => option.UseSqlServer(Configuration.GetConnectionString("DevConnection")));
        //    services.AddTransient<IDepartamentoServices, DepartamentoServices>();
        //    services.AddTransient<IColaboradoreServices, ColaboradorServices>();
        //    services.AddOData();


        //    services.AddMvc();

        //    services.AddSwaggerGen(swagger =>
        //    {
        //        swagger.DescribeAllEnumsAsStrings();
        //        swagger.DescribeAllParametersInCamelCase();
        //        swagger.SwaggerDoc("v1", new Info { Title = "My First Swagger" });
        //    });
        //    // Agregando Auto Mapper
        //    var config = new AutoMapper.MapperConfiguration(cfg => {
        //        cfg.AddProfile(new ColaboradorProfile());
        //     });

        //    var mapper = config.CreateMapper();
        //    services.AddSingleton(mapper);


        //}



        public void Configure(IApplicationBuilder app)
        {
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseMvc();
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        //public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        //{

        //    if (env.IsDevelopment())


        //    {
        //        app.UseDeveloperExceptionPage();
        //        app.UseSwagger();
        //        app.UseSwaggerUI(c =>
        //        {
        //            c.SwaggerEndpoint("swagger/v1/swagger.json", "My First Swagger");
        //            c.RoutePrefix = string.Empty;

        //        });
        //    }
        //    else
        //    {
        //        app.UseHsts();
        //    }

        //    // Agregando OData en el Application Builder
        //    app.UseMvc(FryannBuilder =>
        //   {
        //       FryannBuilder.EnableDependencyInjection();
        //       FryannBuilder.Expand().Filter().Select().MaxTop(200);
        //   });
        //    // Enable middleware to serve generated Swagger as a JSON endpoint.

        //    // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
        //    // specifying the Swagger JSON endpoint.
        //    app.UseHttpsRedirection();

        //    app.UseMvc();




        //}
    }
}
