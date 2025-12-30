
using Microsoft.Extensions.FileProviders;
using Newtonsoft.Json;

namespace WebApp2;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers().AddNewtonsoftJson(options =>
        {
            // Configure Newtonsoft.Json options here
            options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
        });

        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        builder.Services.AddOpenApi();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi("/openapi/v1.json");
        }


        app.UseStaticFiles(); // Enables serving files from wwwroot
        // Configure Static Files Middleware for a custom directory
        // app.UseStaticFiles(new StaticFileOptions
        // {
        //     FileProvider = new PhysicalFileProvider(
        //         Path.Combine(builder.Environment.ContentRootPath, "MyStaticFiles")),
        //     RequestPath = "/" // The URL path to access files (e.g., /StaticFiles/image.png),
        // });


        app.UseRouting();

        //app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.MapGet("/", () => Results.Redirect("/index.html"));

        app.Run();
    }
}
