using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cwicz_3.DAL;
using Cwicz_3.Middlewares;
using Cwicz_3.Models2;
using Cwicz_3.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace Cwicz_3
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        // This method gets called by the runtime. Use this method to add services to the tcontainer.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<s19461Context>(options =>
            {
                options.UseSqlServer("Data Source = db-mssql; Initial Catalog = s19461; Integrated Security = True");
            });
           
            services.AddScoped<IStudentsDbService, Entity_SqlServerDbService>();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IStudentsDbService service)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

         //   app.UseMiddleware<LoggingMiddleware>();


            //app.Use(async (context, next) =>
            //{
            //    if (!context.Request.Headers.ContainsKey("Index"))
            //    {
            //        context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            //        await context.Response.WriteAsync("You don't give index");
            //        return;
            //    }
            //    var bodyStream = string.Empty;
            //    using (var reader = new StreamReader(context.Request.Body, Encoding.UTF8, true, 1024, true))
            //    {
            //        bodyStream = await reader.ReadToEndAsync();
            //    }



            //    string index = context.Request.Headers["Index"].ToString();

            //    if (!service.CheckIfExists(index))//connection with database
            //    {
            //        context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            //        await context.Response.WriteAsync("doesn't exist");
            //        return;
            //    }
            //    await next();
            //});


            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}
