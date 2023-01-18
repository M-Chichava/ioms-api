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
                    await context.AddAsync(
                        new ApplicationPermission
                        {
                            Name = "AddRole",
                            Description = "Add Role"
                        }
                    );
                    await context.AddAsync(
                        new ApplicationPermission
                        {
                            Name = "ListRoles",
                            Description = "List Roles"
                        }
                    );
                    await context.AddAsync(
                        new ApplicationPermission
                        {
                            Name = "EditRole",
                            Description = "Edit Role"
                        }
                    );
                    await context.AddAsync(
                        new ApplicationPermission
                        {
                            Name = "RemoveRole",
                            Description = "Remove Role"
                        }
                    );
                    await context.AddAsync(
                        new ApplicationPermission
                        {
                            Name = "ListPermissions",
                            Description = "List Permissions"
                        }
                    );
                    await context.AddAsync(
                        new ApplicationPermission
                        {
                            Name = "CreateRolePermissions",
                            Description = "Create Role Permissions"
                        }
                    );
                    await context.AddAsync(
                        new ApplicationPermission
                        {
                            Name = "ListRolePermissions",
                            Description = "List Role Permissions"
                        }
                    );
                    await context.AddAsync(
                        new ApplicationPermission
                        {
                            Name = "RemoveRolePermissions",
                            Description = "Remove Role Permissions"
                        }
                    );
                    await context.AddAsync(
                        new ApplicationPermission
                        {
                            Name = "CreateUser",
                            Description = "Create User"
                        }
                    );
                    await context.AddAsync(
                        new ApplicationPermission
                        {
                            Name = "ListUsers",
                            Description = "List Users"
                        }
                    );
                    await context.AddAsync(
                        new ApplicationPermission
                        {
                            Name = "RemoveUser",
                            Description = "Remove User"
                        }
                    );
                    await context.AddAsync(
                        new ApplicationPermission
                        {
                            Name = "EditUser",
                            Description = "Edit User"
                        }
                    );
                    await context.AddAsync(
                        new ApplicationPermission
                        {
                            Name = "ListPayments",
                            Description = "List Payments"
                        }
                    );
                    await context.AddAsync(
                        new ApplicationPermission
                        {
                            Name = "RemovePayment",
                            Description = "Remove Payment"
                        }
                    );
                    await context.AddAsync(
                        new ApplicationPermission
                        {
                            Name = "ListReinforcements",
                            Description = "List Reinforcements"
                        }
                    );
                    await context.AddAsync(
                        new ApplicationPermission
                        {
                            Name = "RemoveReinforcement",
                            Description = "Remove Reinforcement"
                        }
                    );
                    await context.AddAsync(
                        new ApplicationPermission
                        {
                            Name = "ListLateInterests",
                            Description = "List Late Interests"
                        }
                    );
                    await context.AddAsync(
                        new ApplicationPermission
                        {
                            Name = "RemoveLateInterest",
                            Description = "Remove Late Interest"
                        }
                    );
                    await context.AddAsync(
                        new ApplicationPermission
                        {
                            Name = "EditExpenditure",
                            Description = "Edit Expenditure"
                        }
                    );
                    await context.AddAsync(
                        new ApplicationPermission
                        {
                            Name = "RemoveExpenditure",
                            Description = "Remove Expenditure"
                        }
                    );
                    await context.AddAsync(
                        new ApplicationPermission
                        {
                            Name = "ListDisbursements",
                            Description = "List Disbursements"
                        }
                    );
                    await context.AddAsync(
                        new ApplicationPermission
                        {
                            Name = "EditDisbursement",
                            Description = "Edit Disbursement"
                        }
                    );
                    await context.AddAsync(
                        new ApplicationPermission
                        {
                            Name = "RemoveDisbursement",
                            Description = "Remove Disbursement"
                        }
                    );
                    await context.AddAsync(
                        new ApplicationPermission
                        {
                            Name = "ListDeposits",
                            Description = "List Deposits"
                        }
                    );
                    await context.AddAsync(
                        new ApplicationPermission
                        {
                            Name = "RemoveDeposit",
                            Description = "Remove Deposit"
                        }
                    );
                    await context.AddAsync(
                        new ApplicationPermission
                        {
                            Name = "AddAccount",
                            Description = "Add Account"
                        }
                    );
                    await context.AddAsync(
                        new ApplicationPermission
                        {
                            Name = "ListAccounts",
                            Description = "List Accounts"
                        }
                    );
                    await context.AddAsync(
                        new ApplicationPermission
                        {
                            Name = "EditAccount",
                            Description = "Edit Account"
                        }
                    );
                    await context.AddAsync(
                        new ApplicationPermission
                        {
                            Name = "RemoveAccount",
                            Description = "Remove Account"
                        }
                    );
                    await context.AddAsync(
                        new ApplicationPermission
                        {
                            Name = "AddOutgoing",
                            Description = "Add Outgoing"
                        }
                    );
                    await context.AddAsync(
                        new ApplicationPermission
                        {
                            Name = "ListOutgoings",
                            Description = "List Outgoings"
                        }
                    );
                    await context.AddAsync(
                        new ApplicationPermission
                        {
                            Name = "EditAdministrativeCost",
                            Description = "Edit AdministrativeCost"
                        }
                    );
                    await context.AddAsync(
                        new ApplicationPermission
                        {
                            Name = "RemoveAdministrativeCost",
                            Description = "Remove AdministrativeCost"
                        }
                    );
                    await context.AddAsync(
                        new ApplicationPermission
                        {
                            Name = "AddAdministrativeCost",
                            Description = "Add AdministrativeCost"
                        }
                    );
                    await context.AddAsync(
                        new ApplicationPermission
                        {
                            Name = "ListAdministrativeCosts",
                            Description = "List AdministrativeCosts"
                        }
                    );
                    await context.AddAsync(
                        new ApplicationPermission
                        {
                            Name = "EditOutgoing",
                            Description = "Edit Outgoing"
                        }
                    );
                    await context.AddAsync(
                        new ApplicationPermission
                        {
                            Name = "RemoveOutgoing",
                            Description = "Remove Outgoing"
                        }
                    );
                    await context.AddAsync(
                        new ApplicationPermission
                        {
                            Name = "AddPayment",
                            Description = "Add Payment"
                        }
                    );
                    await context.AddAsync(
                        new ApplicationPermission
                        {
                            Name = "EditPayment",
                            Description = "Edit Payment"
                        }
                    );
                    await context.AddAsync(
                        new ApplicationPermission
                        {
                            Name = "AddReinforcement",
                            Description = "Add Reinforcement"
                        }
                    );
                    await context.AddAsync(
                        new ApplicationPermission
                        {
                            Name = "EditReinforcement",
                            Description = "Edit Reinforcement"
                        }
                    );
                    await context.AddAsync(
                        new ApplicationPermission
                        {
                            Name = "AddLateInterest",
                            Description = "Add Late Interest"
                        }
                    );
                    await context.AddAsync(
                        new ApplicationPermission
                        {
                            Name = "EditLateInterest",
                            Description = "Edit Late Interest"
                        }
                    );
                    await context.AddAsync(
                        new ApplicationPermission
                        {
                            Name = "AddExpenditure",
                            Description = "Add Expenditure"
                        }
                    );
                    await context.AddAsync(
                        new ApplicationPermission
                        {
                            Name = "ListExpenditures",
                            Description = "List Expenditures"
                        }
                    );
                    await context.AddAsync(
                        new ApplicationPermission
                        {
                            Name = "AddDisbursement",
                            Description = "Add Disbursement"
                        }
                    );
                    await context.AddAsync(
                        new ApplicationPermission
                        {
                            Name = "AddDeposit",
                            Description = "Add Deposit"
                        }
                    );
                    await context.AddAsync(
                        new ApplicationPermission
                        {
                            Name = "EditDeposit",
                            Description = "Edit Deposit"
                        }
                    );
                    
                    await context.SaveChangesAsync();
                }

                if (!context.ApplicationRoles.Any())
                {
                    await context.AddAsync(
                        new ApplicationRole
                        {
                            Name = "Manager",
                            Description = "Manager"
                        }
                    );

                    await context.AddAsync(
                        new ApplicationRole
                        {
                            Name = "Administrator",
                            Description = "Administrator"
                        }
                    );

                    await context.AddAsync(
                        new ApplicationRole
                        {
                            Name = "Assistant",
                            Description = "Assistant"
                        }
                    );
                    
                    await context.SaveChangesAsync();
                }
                
                if (!context.ApplicationRolePermissions.Any())
                {

                    var rolesPermissions = new List<ApplicationRolePermissionsAux>();

                    var adminPermitions = new List<string>();
                    var assistPermitions = new List<string>();
                    var managerPermitions = new List<string>();
                    
                    adminPermitions.Add(new string ("AddRole"));
                    adminPermitions.Add(new string ("ListRoles"));
                    adminPermitions.Add(new string ("EditRole"));
                    adminPermitions.Add(new string ("RemoveRole"));
                    adminPermitions.Add(new string ("ListPermissions"));
                    adminPermitions.Add(new string ("CreateRolePermissions"));
                    adminPermitions.Add(new string ("ListRolePermissions"));
                    adminPermitions.Add(new string ("RemoveRolePermissions"));
                    adminPermitions.Add(new string ("CreateUser"));
                    adminPermitions.Add(new string ("ListUsers"));
                    adminPermitions.Add(new string ("EditUser"));
                    adminPermitions.Add(new string ("RemoveUser"));
                    
                    assistPermitions.Add(new string("AddPayment"));
                    assistPermitions.Add(new string("ListPayments"));
                    assistPermitions.Add(new string("AddReinforcement"));
                    assistPermitions.Add(new string("ListReinforcements"));
                    assistPermitions.Add(new string("AddLateInterest"));
                    assistPermitions.Add(new string("ListLateInterests"));
                    assistPermitions.Add(new string("AddExpenditure"));
                    assistPermitions.Add(new string("ListExpenditures"));
                    assistPermitions.Add(new string("AddDisbursement"));
                    assistPermitions.Add(new string("ListDisbursements"));
                    assistPermitions.Add(new string("AddDeposit"));
                    assistPermitions.Add(new string("AddDeposit"));
                    assistPermitions.Add(new string("ListDeposits"));
                    assistPermitions.Add(new string("ListAccounts"));

                    
                    managerPermitions.Add(new string("ListPayments"));
                    managerPermitions.Add(new string("EditPayment"));
                    managerPermitions.Add(new string("AddPayment"));
                    managerPermitions.Add(new string("AddReinforcement"));
                    managerPermitions.Add(new string("AddLateInterest"));
                    managerPermitions.Add(new string("AddExpenditure"));
                    managerPermitions.Add(new string("AddDisbursement"));
                    managerPermitions.Add(new string("AddDeposit"));
                    managerPermitions.Add(new string("RemovePayment"));
                    managerPermitions.Add(new string("ListReinforcements"));
                    managerPermitions.Add(new string("EditReinforcement"));
                    managerPermitions.Add(new string("RemoveReinforcement"));
                    managerPermitions.Add(new string("ListLateInterests"));
                    managerPermitions.Add(new string("EditLateInterest"));
                    managerPermitions.Add(new string("RemoveLateInterest"));
                    managerPermitions.Add(new string("ListExpenditures"));
                    managerPermitions.Add(new string("EditExpenditure"));
                    managerPermitions.Add(new string("RemoveExpenditure"));
                    managerPermitions.Add(new string("ListDisbursements"));
                    managerPermitions.Add(new string("EditDisbursement"));
                    managerPermitions.Add(new string("RemoveDisbursement"));
                    managerPermitions.Add(new string("ListDeposits"));
                    managerPermitions.Add(new string("EditDeposit"));
                    managerPermitions.Add(new string("RemoveDeposit"));
                    managerPermitions.Add(new string("AddAccount"));
                    managerPermitions.Add(new string("ListAccounts"));
                    managerPermitions.Add(new string("EditAccount"));
                    managerPermitions.Add(new string("RemoveAccount"));
                    managerPermitions.Add(new string("AddOutgoing"));
                    managerPermitions.Add(new string("ListOutgoings"));
                    managerPermitions.Add(new string("EditOutgoing"));
                    managerPermitions.Add(new string("RemoveOutgoing"));
                    
                     rolesPermissions.Add(new ApplicationRolePermissionsAux
                     {
                         Role = "Administrator",
                         Permissions = adminPermitions
                     });
                     rolesPermissions.Add(new ApplicationRolePermissionsAux
                     {
                         Role = "Assistant",
                         Permissions = assistPermitions
                     });
                     rolesPermissions.Add(new ApplicationRolePermissionsAux
                     {
                         Role = "Manager",
                         Permissions = managerPermitions
                     });
                    
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
                       
                    var adminUsers = new List<AppUser>();
                    var managerUsers = new List<AppUser>();
                    
                    adminUsers.Add(new AppUser
                    {
                        Email = "admin@iosm.com",
                        FullName = "Administrator",
                        UserName = "Admin",
                        EmailConfirmed = true,
                        PhoneNumber = "840000000" 
                    });
                    managerUsers.Add(new AppUser
                    {
                        Email = "ivan@iosm.com",
                        FullName = "Ivan do Anjos",
                        UserName = "ivan22",
                        EmailConfirmed = true,
                        PhoneNumber = "840000001"
                    });
                    
                    var roleAdmin =
                        await context.ApplicationRoles.FirstOrDefaultAsync(x => x.Name == "Administrator");
                    var roleUserManager =
                        await context.ApplicationRoles.FirstOrDefaultAsync(x => x.Name == "Manager");

                    foreach (var item in adminUsers)
                    {
                        item.ApplicationRole = roleAdmin;
                        await userManager.CreateAsync(item, "Pa55w.rd@2021@2021");
                        context.AddAsync(new Administrator
                        {
                            AppUser = item
                        });
                    }
                    
                    foreach (var item in managerUsers)
                    {
                        item.ApplicationRole = roleUserManager;
                        await userManager.CreateAsync(item, "Pa55w.rdM@2021@2022");
                        context.AddAsync(new Manager
                        {
                            AppUser = item
                        });
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