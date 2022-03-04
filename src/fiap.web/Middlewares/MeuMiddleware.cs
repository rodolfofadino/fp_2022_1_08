using Newtonsoft.Json;
using Serilog;
using System.Text;
using System.Text.Json.Serialization;

namespace fiapweb2022.Middlewares
{

    //08e536b5-372b-40d8-a735-6b10c40999f6
    public class MeuMiddleware
    {
        private RequestDelegate _next;

        public MeuMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var request = await FormatRequest(context.Request);

            var log = new LoggerConfiguration()
                .WriteTo
                .Logentries("08e536b5-372b-40d8-a735-6b10c40999f6")
                .CreateLogger();
            log.Information($"request {request}");

            context.Request.Body.Position = 0;

            await _next(context);

        }

        private async Task<string> FormatRequest(HttpRequest request)
        {
            var body = request.Body;
            request.EnableBuffering();

            var buffer = new byte[Convert.ToInt32(request.ContentLength)];
            await request.Body.ReadAsync(buffer, 0, buffer.Length);

            var bodyText = Encoding.UTF8.GetString(buffer);

            var messageObjToLog = new { scheme = request.Scheme, host = request.Host, path = request.Path, queryString = request.Query, requestBody = bodyText };

            return JsonConvert.SerializeObject(messageObjToLog);
        }
    }

    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseMeuMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MeuMiddleware>();
        }
    }
}
