using fiapweb2022.core.Contexts;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);


builder.Services.Configure<RouteOptions>(
    opt => {
    opt.LowercaseUrls = true;
    opt.LowercaseQueryStrings = true;
    });


builder.Services.AddSwaggerGen(options => {

    options.SwaggerDoc("v1", new OpenApiInfo { Title = "Api de times", Version = "v1" });

});


builder.Services.AddCors(
    options =>
    {
        options.AddPolicy("Default", o =>
        {
            o.AllowAnyOrigin();
            o.AllowAnyHeader();
            o.AllowAnyMethod();

        });

    });




builder.Services.AddControllers(
    options =>
    {
        options.RespectBrowserAcceptHeader = true;

    }).AddXmlSerializerFormatters();

builder.Services.AddDbContext<CopaContext>(
    o => o.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
    );

builder.Services.AddApiVersioning(o =>
    {
        o.AssumeDefaultVersionWhenUnspecified = true;
        o.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(2, 0);
    });

var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api de times"));


app.UseCors("Default");

app.UseRouting();
app.UseEndpoints(endpoints => { endpoints.MapControllers(); });


//app.MapGet("/",() => new { Nome = "Rodolfo" });
//app.MapPost("/",async (Time time, CopaContext context) => { return new { Nome = "Rodolfo" }});

app.Run();