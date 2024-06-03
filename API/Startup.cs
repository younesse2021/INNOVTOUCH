using API.Controllers.Helper;
using BLL.InnovTouch.Contrat.Entite;
using BLL.InnovTouch.Contrat.Oracle;
using BLL.InnovTouch.Contrat.Produits;
using BLL.InnovTouch.Contrat.Role;
using BLL.InnovTouch.Implementation.Entite;
using BLL.InnovTouch.Implementation.Oracle;
using BLL.InnovTouch.Implementation.Produits;
using BLL.InnovTouch.Implementation.Role;
using BLL.Services.Contrat;
using BLL.Services.Implementation;
using DAL.InnovTouch.DAL;
using DAL.InnovTouch.DAL.DOMAIN.IRepositories;
using DAL.InnovTouch.DAL.DOMAIN.Repositories;
using DAL.InnovTouch.DAL.Repositories;
using DAL.InnovTouch.DOMAIN.IRepositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
 using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Wkhtmltopdf.NetCore;

namespace API
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
            services.AddDbContext<InnovTouchDbContext>(options => options.UseSqlServer(
                Configuration.GetValue<string>("ENV:SQLSERVER_InnovTouch"),
            b => b.MigrationsAssembly("API")
            ));
            services.AddControllers();
            //For blazor InnovTouch BO to use API
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });

            services.AddWkhtmltopdf();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddControllersWithViews()
                .AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
            });

            //injection des services InnovTouch
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUnitOfWorkOracle, UnitOfWorkOracle>();
            services.AddScoped<IFamilleProduitService, FamilleProduitService>();
            services.AddScoped<IProduitService, ProduitService>();
            services.AddScoped<IAlerteProduitService, AlerteProduitService>();
            services.AddScoped<IInnovTouchProduitService, InnovTouchProduitService>();
            services.AddScoped<IEnseigneService, EnseigneService>();
            services.AddScoped<IMagasinService, MagasinService>();
            services.AddScoped<IService, Service>();
            services.AddScoped<IUtilisateurService, UtilisateurService>();
            services.AddScoped<IProfileService, ProfileService>();
            services.AddScoped<IInentaireServicecs, AddInventaireService>();
            services.AddScoped<IExportService, ExportService>();
            services.AddScoped<IEmplacementService, EmplacementService>();
 
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // for blazor InnovTouch bo to use API
            app.UseCors();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1"));

            app.UseHttpsRedirection();

            var supportedCultures = new List<CultureInfo> {
                new CultureInfo("en-GB"),
            };

            app.UseRequestLocalization(options =>
            {
                options.DefaultRequestCulture = new RequestCulture("en-GB");
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
                options.RequestCultureProviders = new List<IRequestCultureProvider>
                {
                    new QueryStringRequestCultureProvider(),
                    new CookieRequestCultureProvider()
                };
            });

            app.UseRouting();
            app.UseAuthorization();
            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
