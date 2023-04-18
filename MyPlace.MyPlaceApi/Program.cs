
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

            var app = builder
                   .ConfigureServices()
                   .ConfigurePipeline();


            app.Run();
        }
    }


}


