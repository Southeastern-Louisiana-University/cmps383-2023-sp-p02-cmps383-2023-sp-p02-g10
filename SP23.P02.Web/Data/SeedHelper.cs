using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SP23.P02.Web.Features.Authorization;
using SP23.P02.Web.Features.TrainStations;

namespace SP23.P02.Web.Data;

public static class SeedHelper
{

    public static async Task Initialize(IServiceProvider services)
    {
        var dataContext = services.GetRequiredService<DataContext>();
        await dataContext.Database.MigrateAsync();


        AddTrainStations(dataContext);
        await AddRoles(services);
        await AddUsers(services);
        await MigrateAndSeed(dataContext);

    }

    private static void AddTrainStations(DataContext dataContext)
    {
        var stations = dataContext.Set<TrainStation>();
        if (stations.Any())
        {
            return;
        }

        stations.Add(new TrainStation
        {
            Name = "Hammond Trainstation,",
            Address = "123 Hammond Street",
        });

        stations.Add(new TrainStation
        {
            Name = "Hammond Trainstation,",
            Address = "123 Hammond Street",
        });

        stations.Add(new TrainStation
        {
            Name = "Hammond Trainstation,",
            Address = "123 Hammond Street",
        });

        dataContext.SaveChanges();
    }

    public static async Task MigrateAndSeed(DataContext dataContext)
    {
        await dataContext.Database.MigrateAsync();

        var trainStations = dataContext.Set<TrainStation>();

        if (!await trainStations.AnyAsync())
        {
            for (int i = 0; i < 3; i++)
            {
                dataContext.Set<TrainStation>()
                    .Add(new TrainStation
                    {
                        Name = "Hammond",
                        Address = "1234 Place st"
                    });
            }

            await dataContext.SaveChangesAsync();
        }
    }

    private static async Task AddRoles(IServiceProvider services)
    {
        var roleManager = services.GetRequiredService<RoleManager<Role>>();
        if (roleManager.Roles.Any())
        {
            return;
        }

        await roleManager.CreateAsync(new Role
        {
            Name = RoleNames.Admin
        });

        await roleManager.CreateAsync(new Role
        {
            Name = RoleNames.User
        });
    }

    private static async Task AddUsers(IServiceProvider services)
    {
        const string defaultPassword = "Password123!";

        var userManager = services.GetRequiredService<UserManager<User>>();
        if (userManager.Users.Any())
        {
            return;
        }

        var adminUser = new User
        {
            UserName = "galkadi"
        };
        await userManager.CreateAsync(adminUser, defaultPassword);
        await userManager.AddToRoleAsync(adminUser, RoleNames.Admin);

        var bobUser = new User
        {
            UserName = "bob"
        };
        await userManager.CreateAsync(bobUser, defaultPassword);
        await userManager.AddToRoleAsync(bobUser, RoleNames.User);

        var sueUser = new User
        {
            UserName = "sue"
        };
        await userManager.CreateAsync(sueUser, defaultPassword);
        await userManager.AddToRoleAsync(sueUser, RoleNames.User);

        await services.GetRequiredService<DataContext>().SaveChangesAsync();
    }


}