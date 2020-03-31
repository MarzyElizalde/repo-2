using Business;
using Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace APICaja
{
    public class Startup
    {
        private const string API_CONNECTION = "MyWebApiConection";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            //Configuración para JsonResult
            services.AddMvc().AddJsonOptions(options =>
            {
                options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                options.SerializerSettings.DefaultValueHandling = DefaultValueHandling.Include;
                options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
            });

            string apiConnStr = Configuration.GetConnectionString(API_CONNECTION);
            if (string.IsNullOrEmpty(apiConnStr))
            {
                string message = $"ERROR: No se encontró la cadena de conexión {API_CONNECTION}";
            }

            services.AddDbContext<ApiDBContext>(opt =>
                               opt.UseNpgsql(Configuration.GetConnectionString(API_CONNECTION)));

            services.AddScoped<IBsTurno, BsTurno>();
            services.AddScoped<IBsUsuario, BsUsuario>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            //app.UseHttpsRedirection();
             app.UseMvc();
        }
    }
}
