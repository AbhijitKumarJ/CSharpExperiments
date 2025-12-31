
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Newtonsoft.Json;
using WebApp3.Data;

namespace WebApp3;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers().AddNewtonsoftJson(options =>
        {
            options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
        });

        // Configure EF Core with Postgres connection string in appsettings.json
        builder.Services.AddDbContext<DvdRentalContext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("DvdRental")));

        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        builder.Services.AddOpenApi();

        var app = builder.Build();

        // Ensure database exists
        // using (var scope = app.Services.CreateScope())
        // {
        //     var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        //     db.Database.EnsureCreated();
        // }

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi("/openapi/v1.json");
        }

        app.UseStaticFiles();

        app.UseRouting();

        //app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.MapGet("/", () => Results.Redirect("/index.html"));

        app.Run();
    }
}
