using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using WiProLocadora.Domain.Entity;
using WiProLocadora.Domain.Mapping;
using WiProLocadora.Domain.Services;
using WiProLocadora.Domain.UseCases.DTO;
using WiProLocadora.Domain.UseCases.Repository;
using WiProLocadora.Domain.UseCases.Service;
using WiProLocadora.Infrastructure.Data.SQLServer;
using WiProLocadora.Infrastructure.Repository;

namespace WiProLocadora
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
            services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo { Title = "WiProLocadoraAPI", Version = "v1" });});
            services.AddDbContext<SQLServerDataContext>(options => { options.UseInMemoryDatabase("WiProLocadoraDB");});
            services.AddSingleton(MappingProfile.InitializeAutomapper().CreateMapper());

            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<ILocacaoService, LocacaoService>();
            services.AddScoped<IFilmeService, FilmeService>();

            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IClienteLocacaoRepository, ClienteLocacaoRepository>();
            services.AddScoped<IElencoRepository, ElencoRepository>();
            services.AddScoped<IFilmeRepository, FilmeRepository>();
            services.AddScoped<IFilmeCategoriaRepository, FilmeCategoriaRepository>();
            services.AddScoped<IFilmeElencoRepository, FilmeElencoRepository>();
            services.AddScoped<IFilmeEstoqueRepository, FilmeEstoqueRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();

            app.UseSwaggerUI(opt =>
            {
                opt.SwaggerEndpoint("/swagger/v1/swagger.json", "WiProLocadoraAPI v1");
            });
        }
    }
}
