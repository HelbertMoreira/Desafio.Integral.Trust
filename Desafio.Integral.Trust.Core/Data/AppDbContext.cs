using Microsoft.AspNetCore.Identity;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Desafio.Integral.Trust.Core.Models;
using Desafio.Integral.Trust.Domain.Models;

namespace Desafio.Integral.Trust.Core.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : IdentityDbContext<User,
    IdentityRole<long>,long,
    IdentityUserClaim<long>,
    IdentityUserRole<long>,
    IdentityUserLogin<long>,
    IdentityRoleClaim<long>,
    IdentityUserToken<long>>(options)
{
    public DbSet<Transacao> Transacoes { get; set; } = null!;    
    public DbSet<IndicadorDeRisco> IndicadoresDeRiscos { get; set; } = null!;

    //public DbSet<IncomesAndExpenses> IncomesAndExpenses { get; set; } = null!;
    //public DbSet<IncomesByCategory> IncomesByCategories { get; set; } = null!;
    //public DbSet<ExpensesByCategory> ExpensesByCategories { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        //modelBuilder.Entity<IncomesAndExpenses>()
        //    .HasNoKey()
        //    .ToView("vwGetIncomesAndExpenses");

        //modelBuilder.Entity<IncomesByCategory>()
        //    .HasNoKey()
        //    .ToView("vwGetIncomesByCategory");

        //modelBuilder.Entity<ExpensesByCategory>()
        //    .HasNoKey()
        //    .ToView("vwGetExpensesByCategory");
    }
}
