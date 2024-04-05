using demo1.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;
using Vehical_config_1.Repository;
using Vehicle.Models;

namespace Vehicle
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidIssuer = builder.Configuration["Jwt:Issuer"],
                ValidAudience = builder.Configuration["Jwt:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
            };
            });

            builder.Services.AddControllers();
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("MyAllowSpecificOrigins",
                    builder =>
                    {
                        builder.WithOrigins("*")
                               .AllowAnyHeader()
                               .AllowAnyMethod();
                    });
            });
            builder.Services.AddTransient<IVehicleDetail,SqlVehicleDetailRepository>(); 
            builder.Services.AddTransient<ISegmentRepository,SQLSegmentRepository>();
            builder.Services.AddTransient<IAlternateComponent, SqlAlternateComponentRepo>();
            builder.Services.AddTransient<IManufacturerRepository,SQLManufacturerRepository>();
            builder.Services.AddTransient<IVariantRepository,SQLVariantRepository>();
            builder.Services.AddTransient<IUserRepository, SQLUserRepository>();


            builder.Services.AddDbContextPool<ApplicationDbContext>((options, context) =>
            {
                var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
                context.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));

            });

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();
            app.UseCors("MyAllowSpecificOrigins");

            app.Run();
        }
    }
}