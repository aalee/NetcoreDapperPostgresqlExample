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
using aalee.Test.Dapper.PostgreSQL.Contracts;
using aalee.Test.Dapper.PostgreSQL.Repository;
using System.Data;
using Npgsql;
using aalee.Test.Dapper.PostgreSQL.Contracts.Repository;

namespace aalee.Test.Dapper.PostgreSQL.API
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
            services.AddMvc();
            //services.AddScoped<IDbConnection>(new NpgsqlConnection("Server=<ip>; Port=5432; User Id=Admin; Password=postgres.1; Database=Test1") );
            services.AddScoped<IDbConnection>(service => new NpgsqlConnection(Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IAdminAlee, AdminAlee>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
