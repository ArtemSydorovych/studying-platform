using Microsoft.AspNetCore.Identity;
using VanyaTeach.User.Data.EntityFramework;
using VanyaTeach.User.Data.Models;
using VanyaTeach.User.Repositories;

namespace VanyaTeach.User;

internal static class UserServicesExtensions
{
    public static async void ConfigureUserServices(this IServiceCollection services)
    {
        services.AddSingleton<UserContext>();
        services.AddSingleton<IStudentRepository, StudentRepository>();
        
        services.AddIdentity<Data.Models.User, IdentityRole<Guid>>()
            .AddEntityFrameworkStores<UserContext>()
            .AddDefaultTokenProviders();

    }


    internal static async Task InitializeRoles(IServiceProvider serviceProvider)
    {
        var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole<Guid>>>();
        foreach (var role in Enum.GetValues(typeof(UserRole)))
        {
            if (!await roleManager.RoleExistsAsync(role.ToString()!))
            {
                await roleManager.CreateAsync(new IdentityRole<Guid>(role.ToString()!));
            }
        }
    }
}