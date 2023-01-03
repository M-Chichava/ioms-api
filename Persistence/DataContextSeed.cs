using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Persistence
{
   
    public class DataContextSeed
    {
        public DataContextSeed()
        {
        }
       
        public static async Task SeedAsync(DataContext context, ILoggerFactory loggerFactory, 
            UserManager<AppUser> userManager, IConfiguration configuration, RoleManager<IdentityRole> roleManager)
        {
            try
            {
                if (!context.ApplicationPermissions.Any())
                {
                    var permissionData = await File.ReadAllTextAsync($"../Persistence/SeedData/permissionsSeed.json");
                    var permissions = JsonSerializer.Deserialize<List<ApplicationPermission>>(permissionData);

                    foreach (var permission in permissions)
                    {
                        await context.AddAsync(permission);
                    }
                    
                    await context.SaveChangesAsync();
                }

                if (!context.ApplicationRoles.Any())
                {
                    var rolesData = await File.ReadAllTextAsync($"../Persistence/SeedData/rolesSeed.json");
                    var roles = JsonSerializer.Deserialize<List<ApplicationRole>>(rolesData);

                    foreach (var role in roles)
                    {
                        await context.AddAsync(role);
                    }
                    
                    await context.SaveChangesAsync();
                }
                
                if (!context.ApplicationRolePermissions.Any())
                {
                    var rolesPermissionsData =
                        await File.ReadAllTextAsync($"../Persistence/SeedData/rolePermissionsSeed.json");
                    var rolesPermissions =
                        JsonSerializer.Deserialize<List<ApplicationRolePermissionsAux>>(rolesPermissionsData);

                    foreach (var rolePermission in rolesPermissions)
                    {
                        var role = await context.ApplicationRoles.Where(x => x.Name == rolePermission.Role)
                            .FirstOrDefaultAsync();

                        foreach (var permission in rolePermission.Permissions)
                        {
                            var appPermission = await context.ApplicationPermissions.Where(x => x.Name == permission)
                                .FirstOrDefaultAsync();

                            
                                var appRolePermissions = new ApplicationRolePermission
                                {
                                    ApplicationRole = role,
                                    ApplicationPermission = appPermission
                                }; 
                                await context.AddAsync(appRolePermissions);
                        }
                    }
                }
                if (!userManager.Users.Any())
                {
                        var adminData = await File.ReadAllTextAsync("../Persistence/SeedData/adminSeed.json");
                    var adminUsers = JsonSerializer.Deserialize<List<AppUser>>(adminData);
                    
                    var managerData = await File.ReadAllTextAsync("../Persistence/SeedData/managerSeed.json");
                    var managerUsers = JsonSerializer.Deserialize<List<AppUser>>(managerData);
                    
                    var roleAdmin =
                        await context.ApplicationRoles.FirstOrDefaultAsync(x => x.Name == "Administrator");
                    var roleUserManager =
                        await context.ApplicationRoles.FirstOrDefaultAsync(x => x.Name == "Manager");

                    foreach (var item in adminUsers)
                    {
                        
                        item.ApplicationRole = roleAdmin;
                        await userManager.CreateAsync(item, "Pa55w.rd@2021@2021");
                    }
                    
                    foreach (var item in managerUsers)
                    {
                        item.ApplicationRole = roleUserManager;
                        await userManager.CreateAsync(item, "Pa55w.rdM@2021@2022");
                    }

                        await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                var logger = loggerFactory.CreateLogger<DataContext>();
                logger.LogError(ex, ex.Message);
            }
        }
    }
}