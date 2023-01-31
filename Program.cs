namespace ASPWelcomeWebApplication
{
    public class Program
    {
        static async Task HandleRequest(HttpContext context)
        {
            await context.Response.WriteAsync("Hello Run");
        }
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();

            //app.MapGet("/", () => "Hello World!");
            //app.MapGet("/about", () => "About World!");
            //app.UseWelcomePage();

            //int count = 5;

            // dynamic primitive html doc
            //string str = "Hello world";
            //string htmlDoc = $"<h1>{str}</h1>";
            //string[] items = new string[] { "item 1", "item 2" };

            //string list = "<ul>";
            //foreach (var item in items)
            //    list += $"<li>{item}</li>";
            //list += "</ul>";

            //htmlDoc += list;

            //app.Run(async (context) => {
            //    //count += 10;
            //    var response = context.Response;
            //    response.Headers.ContentLanguage = "ru-RU";
            //    response.Headers.ContentType = "text/html; charset=utf-8";
            //    //response.Headers.Append("my-data", "max efimov");
            //    await response.WriteAsync($"{htmlDoc}");
            //});

            //app.Run(async (context) =>
            //{
            //    var response = context.Response;
            //    var htmlBuilder = new System.Text.StringBuilder("<ul>");
            //    foreach(var header in context.Request.Headers)
            //        htmlBuilder.Append($"<li>{header.Key}: {header.Value}</li>");
            //    htmlBuilder.Append($"<li>Path: {context.Request.Path}");
            //    htmlBuilder.Append("</ul>");


            //    response.Headers.ContentType = "text/html; charset=utf-8";
            //    await response.WriteAsync(htmlBuilder.ToString());
            //});

            app.Run(async (context) => {
                var path = context.Request.Path;
                var response = context.Response;

                if (path == "/")
                    await response.WriteAsync("Hello People");
                else if (path == "/bob")
                    await response.WriteAsync("Hello Bob");
                else if(path == "/joe")
                    await response.WriteAsync("Hello Joe");
                else
                {
                    response.StatusCode = 404;
                    await response.WriteAsync("Invalid url");
                }
            });

            app.Run();
        }
    }
}