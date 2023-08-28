using VanyaTeach.User.Data.EntityFramework;
using VanyaTeach.User.Repositories;

namespace VanyaTeach.User;

internal static class UserServicesExtensions
{
    public static void ConfigureUserServices(this IServiceCollection services)
    {
        services.AddSingleton<UserContext>();
        services.AddSingleton<IStudentRepository, StudentRepository>();
    }
}