
using Microsoft.AspNetCore.Identity;

using Microsoft.EntityFrameworkCore;
using MyPlace.BusinessLogic.Contexts;

namespace MyPlace.MyPlaceApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connectionString = builder.Configuration.GetConnectionString("MyPlaceDbContextConnection") ?? throw new InvalidOperationException("Connection string 'MyPlaceDbContextConnection' not found.");

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

            //builder.Services.AddDefaultIdentity<IdentityUser>(options =>
            //{
            //    options.Password.RequireDigit = true;
            //    options.Password.RequiredLength = 8;
            //    options.Password.RequireNonAlphanumeric = true;
            //    options.User.RequireUniqueEmail = true;

            //}).AddRoles<IdentityRole>()
            //  .AddEntityFrameworkStores<MyPlaceDbContext>();



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

            app.Run();
        }
    }
}