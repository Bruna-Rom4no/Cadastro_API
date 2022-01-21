using AutoMapper;
using Cadastro.API.DependencyInjection;
using Cadastro.API.Mapper;
using Cadastro_API_1.GerenServicos.Interfaces;
using Cadastro_API_1.GerenServicos.Servicos;
using Cadastro_API_1.Infraestrutura.Contexto;
using Cadastro_API_1.Infraestrutura.Interfaces;
using Cadastro_API_1.Infraestrutura.Repositorio;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Cadastro_API_1
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
            services.AddControllers().AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<Startup>());
            services.AddControllers();

            services.AddSingleton(d => Configuration);

            services.RegistrerDependecyInjection();

            services.AddDbContext<GerenciadorContexto>(options => options.UseSqlServer(Configuration["connectionStrings:USER_MANAGER"]), ServiceLifetime.Transient);
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Cadastro_API_1", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Cadastro_API_1 v1"));
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
