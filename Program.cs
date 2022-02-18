

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();


var app = builder.Build();


app.UseRouting();

//app.MapControllerRoute(name: "default1",
//    pattern: "{controller=home}/{action=index}/{id?}"
//);

//app.MapControllerRoute(
//    name: "alunos",
//    pattern: "arealogada/{action}/{id?}",
//    defaults: new { controller = "alunos", action = "index" }
//);

app.MapControllerRoute(
    name: "default2s",
    pattern: "{controller}/{action}/{id?}",
    defaults: new { controller ="home", action = "index"}
);



app.Run();





//app.Run(async (context) => {

//    await context.Response.WriteAsync("teste");
//});
//app.MapGet("/", () => "Ola, boa noite");



