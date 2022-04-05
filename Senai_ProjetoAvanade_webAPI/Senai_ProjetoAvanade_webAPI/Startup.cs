using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Senai_ProjetoAvanade_webAPI.Contexts;
using System;
using System.IO;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using System.Configuration;
using Senai_ProjetoAvanade_webAPI.Interfaces;
using Senai_ProjetoAvanade_webAPI.Repositories;

namespace Senai_ProjetoAvanade_webAPI
{
    public class Startup
    {

        public Startup(IConfiguration _configuration)
        {
            Configuration = _configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()

                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                    options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                });

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = "JwtBearer";
                options.DefaultChallengeScheme = "JwtBearer";
            })

                .AddJwtBearer("JwtBearer", options => {

                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,

                        ValidateAudience = true,

                        ValidateLifetime = true,

                        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("projetoavanade-chave-autenticacao")),

                        ClockSkew = TimeSpan.FromHours(5),

                        ValidIssuer = "ProjetoAvanade_webAPI",

                        ValidAudience = "ProjetoAvanade_webAPI"
                    };

                });

            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "ProjetoAvanade_webAPI",
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            services.AddCors(options =>
            {
                options.AddPolicy("CorPolicy",
                                builder =>
                                {
                                    builder.WithOrigins("*")
                                    .AllowAnyHeader()
                                    .AllowAnyMethod();
                                });
            });

            services.AddDbContext<AvanadeContext>(options =>
                             options.UseSqlServer(Configuration.GetConnectionString("Default"))
                         );


            services.AddTransient<DbContext, AvanadeContext>();
            services.AddTransient<IUsuarioRepository, UsuarioRepository>();
            services.AddTransient<IBicicletarioRepository, BicicletarioRepository>(); //IBicicletarioRepository ta indo pro repository
            services.AddTransient<IReservaRepository, ReservaRepository>();
            services.AddTransient<IVagasRepository, VagasRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseCors("CorPolicy");

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Senai_ProjetoAvanade_webApi");
                c.RoutePrefix = string.Empty;
            });

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}