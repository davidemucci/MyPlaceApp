using Microsoft.EntityFrameworkCore;
using MyPlace.BusinessLogic.Contexts;

internal static class ProgramHelpers
{

    public static void ResetDb(WebApplication app)
    {
        using (var scope = app.Services.CreateScope())
        {
            try
            {
                var context = scope.ServiceProvider.GetService<MyPlaceDbContext>();
                if (context != null)
                {
                    context.Database.EnsureDeletedAsync();
                    context.Database.MigrateAsync();
                }
            }
            catch (Exception ex)
            {
                var logger = scope.ServiceProvider.GetRequiredService<ILogger>();
                logger.LogError(ex, "An error occurred while migrating the database.");
            }
        }
    }
}