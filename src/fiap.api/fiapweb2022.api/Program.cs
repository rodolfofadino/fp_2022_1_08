using fiapweb2022.core.Contexts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

builder.Services.AddDbContext<CopaContext>(
    o => o.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
    );

var app = builder.Build();

app.UseRouting();
app.UseEndpoints(endpoints => { endpoints.MapControllers(); });


//app.MapGet("/",() => new { Nome = "Rodolfo" });
//app.MapPost("/",async (Time time, CopaContext context) => { return new { Nome = "Rodolfo" }});

app.Run();