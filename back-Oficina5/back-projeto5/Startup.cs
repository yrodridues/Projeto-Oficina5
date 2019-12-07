using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Swashbuckle.AspNetCore.Swagger;
using back_projeto5.DAL.Model;
using back_projeto5.DAL.DAO;
using back_projeto5.BLL;
using back_projeto5.Controllers;

namespace back_projeto5
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
            services.Configure<Configuracoes>(
                Options =>
                {
                    Options.ConnectionString = 
                            Configuration.GetSection("MongoDb:ConnectionString").Value;
                    Options.Database = Configuration.GetSection("MongoDb:Database").Value;
                }
            );
            services.AddSingleton<IMongoClient, MongoClient>(
                _ => new MongoClient(Configuration.GetSection("MongoDb:ConnectionString").Value)
            );
            
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddSwaggerGen(Options =>{
                Options.SwaggerDoc("v1",
                    new Info{
                        Title = "Projeto Oficina5",
                        Version = "v1",
                        Description = "Sistema de envio de Mensagens e Gerencia de Usuarios",
                        Contact = new Contact
                        {
                            Name = "Yuri Rodrigues de Sousa"
                        }
                    });
            });
            services.AddScoped<IMongoContext, MongoContext>();

            services.AddScoped<IServicoDAO, ServicoDAO>();
            services.AddScoped<IServicoBLL, ServicoBLL>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseCors(x => x
                            .AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader()
                            .AllowCredentials());

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.RoutePrefix = "swagger";
                    c.SwaggerEndpoint("/swagger/v1/swagger.json","Projeto Oficina5");
                });
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
