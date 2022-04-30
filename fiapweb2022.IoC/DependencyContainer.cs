using fiapweb2022.Application.Interfaces;
using fiapweb2022.Application.Services;
using fiapweb2022.Application.Validations;
using fiapweb2022.Domain.Models;
using fiapweb2022.Infrastructure.Clients;
using fiapweb2022.Persistence.Contexts;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace fiapweb2022.IoC
{
    public class DependencyContainer
    {
       public static void RegisterServices(IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddDataProtection()
            .SetApplicationName("fiap")
            .PersistKeysToFileSystem(new DirectoryInfo("C:\\Users\\rodolfofadino\\source\\repos\\fiap-web-2022\\src\\fiap.web"));

            services.AddAuthentication("app").AddCookie("app",
                 o =>
                 {
                     o.LoginPath = "/account/index";
                     o.AccessDeniedPath = "/account/denied";
                 });
            services.AddMemoryCache();


            services.AddTransient<IValidator<Aluno>, AlunoValidation>();
            services.AddTransient<INoticiaService, NoticiaService>();
            services.AddTransient<IRssClient, RssGloboClient>();

            services.AddControllersWithViews().AddFluentValidation();

            services.AddDbContext<CopaContext>(

                 o => o.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
                 );

            services.Configure<GzipCompressionProviderOptions>(o => o.Level = System.IO.Compression.CompressionLevel.Optimal);
            services.AddResponseCompression(o => { o.Providers.Add<GzipCompressionProvider>(); });
        }
    }
}