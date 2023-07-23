using _2C_API.Data;
using _2C_API.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();


        builder.Services.AddDbContext<DatabaseContext>(options =>
                        options.UseNpgsql(builder.Configuration.GetConnectionString(nameof(DatabaseContext))));

        builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<DatabaseContext>();

        builder.Services.AddDistributedMemoryCache(); 
        builder.Services.AddSession(options =>
        {
            options.Cookie.Name = "UserSession";
            options.IdleTimeout = TimeSpan.FromMinutes(360); // Adjust the session timeout as needed
        });

        builder.Services.AddCors(policyBuilder =>
            policyBuilder.AddDefaultPolicy(policy =>
                policy.WithOrigins("*")
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowAnyOrigin()
            )
        );

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}