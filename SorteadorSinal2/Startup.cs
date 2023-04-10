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
using Microsoft.OpenApi.Models;
using SorteadorSinal2.repositorios;
using SorteadorSinal2.repositorios.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SorteadorSinal2
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      var configContrutor = new ConfigurationBuilder();
      configContrutor.AddJsonFile("config.json", optional: false, reloadOnChange: true);
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      var connectionString = "server=localhost;uid=root;pwd=2443;database=Sinal2Sorteador_Des";
      services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
      services.AddControllers();

      services.AddDbContext<Contexto>(
          x => x.UseLazyLoadingProxies()
          .UseMySql(connectionString, m => m.MigrationsAssembly("SorteadorSinal2")));

      //DI
      #region Repositórios
      services.AddScoped<IContexto, Contexto>();
      services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
      services.AddScoped<IClienteRepositorio, ClienteRepositorio>();
      services.AddScoped<IParticipantesRepositorio, ParticipantesRepositorio>();
      services.AddScoped<IPromocoesRepositorio, PromocoesRepositorio>();
      services.AddScoped<IVencedoresRepositorio, VencedoresRepositorio>();
      #endregion

      services.AddSwaggerGen(c =>
            {
              c.SwaggerDoc("v1", new OpenApiInfo { Title = "SorteadorSinal2", Version = "v1" });
            });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SorteadorSinal2 v1"));
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
