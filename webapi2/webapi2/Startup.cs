using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using webapi2.Models;

namespace webapi2
{
    public class Startup
    {


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());

            });
            string con = "Server=(localdb)\\mssqllocaldb;Database=usersdbstore1;Trusted_Connection=True;";
            services.AddDbContext < UsersContext>(options => options.UseSqlServer(con));
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseCors("CorsPolicy");
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseMvc();
        }
    }
}
