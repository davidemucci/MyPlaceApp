﻿using Microsoft.EntityFrameworkCore;
using MyPlace.BusinessLogic.Contexts;
using Serilog;

namespace MyPlace.MyPlaceApi
{
    internal static class StartUpHelper
    {
        public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .WriteTo.File("Logs/MyPlaceLogs.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();

            builder.Host.UseSerilog();
            var connectionString = builder.Configuration.GetConnectionString("MyPlaceContextDbConnectionString")
                ?? throw new InvalidOperationException("Connection string 'MyPlaceDbContextConnection' not found.");

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            builder.Services.AddDbContext<MyPlaceDbContext>(
                options =>
                {
                    options.UseSqlServer(

                    builder.Configuration["ConnectionStrings:MyPlaceContextDbConnectionString"]);
                });

            return builder.Build();
        }

        public static WebApplication ConfigurePipeline(this WebApplication app)
        {
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            else
            {
                app.UseExceptionHandler(appBuilder =>
                {
                    appBuilder.Run(async context =>
                    {
                        context.Response.StatusCode = 500;
                        await context.Response.WriteAsync("An unexpected fault happened. Try again later");
                    });
                });
            }


            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            return app;
        }
    }
}