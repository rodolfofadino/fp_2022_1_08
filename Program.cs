using fiapweb2022.Middlewares;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

var app = builder.Build();


//app.Use(async (context, next) => 
//{ 

//    //logica aqui

//    await next.Invoke();

//    //logica no final

//});


//app.Map("/admin", myapp => {
//    myapp.Run(async context => {
//        await context.Response.WriteAsync("Area do admin");
//    });
//});

//app.MapWhen(context => context.Request.Query.ContainsKey("aluno") , myapp => {

//    myapp.Run(async context => {
//        await context.Response.WriteAsync("Parametro na url");
//    });
//});



//app.Run(async context =>
//{
//    await context.Response.WriteAsync("Hello from 2nd delegate.");
//});



//app.UseMiddleware<MeuMiddleware>();

app.UseMeuMiddleware();


if (app.Environment.IsDevelopment())
    app.UseDeveloperExceptionPage();

app.UseRouting();

app.MapControllerRoute(name: "default1",
    pattern: "{controller=home}/{action=index}/{id?}"
);

app.MapControllerRoute(
    name: "alunos",
    pattern: "arealogada/{action}/{id?}",
    defaults: new { controller = "alunos", action = "index" }
);

app.MapControllerRoute(
    name: "default2s",
    pattern: "{controller}/{action}/{id?}",
    defaults: new { controller = "home", action = "index" }
);



app.Run();





//app.Run(async (context) => {

//    await context.Response.WriteAsync("teste");
//});
//app.MapGet("/", () => "Ola, boa noite");



