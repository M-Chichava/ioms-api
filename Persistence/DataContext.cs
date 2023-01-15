using Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class DataContext : IdentityDbContext<AppUser>
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<ApplicationRole> ApplicationRoles { get; set; }
        public DbSet<ApplicationPermission> ApplicationPermissions { get; set; }
        public DbSet<ApplicationRolePermission> ApplicationRolePermissions { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Administrator> Administrators { get; set; }
        public DbSet<ClientAssistant> ClientAssistants { get; set; }
        public DbSet<BankAccount> BankAccount { get; set; }
        public DbSet<AdministrativeCost> AdministrativeCosts { get; set; }
        public DbSet<AdministrativeCostAccount> AdministrativeCostAccounts { get; set; }
        public DbSet<Deposit> Deposits { get; set; }
        public DbSet<DepositAccount> DepositAccounts { get; set; }
        public DbSet<Disbursement> Disbursements { get; set; }
        public DbSet<DisbursementAccount> DisbursementAccounts { get; set; }
        public DbSet<Expenditure> Expenditures { get; set; }
        public DbSet<ExpenditureAccount> ExpenditureAccounts { get; set; }
        public DbSet<LateInterest> LateInterests { get; set; }
        public DbSet<LateInterestAccount> LateInterestAccounts { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<PaymentAccount> PaymentAccounts { get; set; }
        public DbSet<Reinforcement> Reinforcements { get; set; }
        public DbSet<ReinforcementAccount> ReinforcementAccounts { get; set; }
        
    }
}