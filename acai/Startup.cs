using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using acai.Context;
using acai.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace acai
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
            
            //services.AddControllers();
            services.AddMvc();

            var connection = Configuration["ConexaoSqlite:SqliteConnectionString"];

            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlite(connection);
            });

            services.AddScoped<PedidoRepository, PedidoRepository>();
            services.AddScoped<SaborRepository, SaborRepository>();
            services.AddScoped<TamanhoRepository, TamanhoRepository>();
            services.AddScoped<AdicionalRepository, AdicionalRepository>();

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
