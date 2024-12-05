using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using jwtauth.Models;
using Microsoft.EntityFrameworkCore;

namespace jwtauth.Data
{
    public class CrmDbContext : DbContext
    {
    public DbSet<Lead> Leads { get; set; }
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<Account> Accounts { get; set; }
    public DbSet<Deal> Deals { get; set; }
    public DbSet<AppTask> AppTasks { get; set; }
    public DbSet<Activity> Activities { get; set; }
    public DbSet<Campaign> Campaigns { get; set; }
    public DbSet<Email> Emails { get; set; }
    public DbSet<Quote> Quotes { get; set; }
    public DbSet<Invoice> Invoices { get; set; }

    public CrmDbContext(DbContextOptions<CrmDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    // Lead - Contact relationship (One-to-Many)
        modelBuilder.Entity<Lead>()
            .HasMany(l => l.Contacts)
            .WithOne(c => c.Lead)
            .HasForeignKey(c => c.LeadId);

        // Lead - Deal relationship (One-to-Many)
        modelBuilder.Entity<Lead>()
            .HasMany(l => l.Deals)
            .WithOne(d => d.Lead)
            .HasForeignKey(d => d.LeadId);

        // Lead - Account relationship (Many-to-One)
        modelBuilder.Entity<Lead>()
            .HasOne(l => l.Account)
            .WithMany(a => a.Leads)
            .HasForeignKey(l => l.AccountId);

        // Account - Deal relationship (One-to-Many)
        modelBuilder.Entity<Account>()
            .HasMany(a => a.Deals)
            .WithOne(d => d.Account)
            .HasForeignKey(d => d.AccountId);

        // Lead - Task relationship (Optional)
        modelBuilder.Entity<Lead>()
            .HasMany(l => l.AppTasks)
            .WithOne(t => t.Lead)
            .HasForeignKey(t => t.LeadId)
            .OnDelete(DeleteBehavior.SetNull);

        // Lead - Activity relationship (One-to-Many)
        modelBuilder.Entity<Lead>()
            .HasMany(l => l.Activities)
            .WithOne(a => a.Lead)
            .HasForeignKey(a => a.LeadId);

        // Lead - Email relationship (One-to-Many)
        modelBuilder.Entity<Lead>()
            .HasMany(l => l.Emails)
            .WithOne(e => e.Lead)
            .HasForeignKey(e => e.LeadId);

        // Lead - Quote relationship (One-to-Many)
        modelBuilder.Entity<Lead>()
            .HasMany(l => l.Quotes)
            .WithOne(q => q.Lead)
            .HasForeignKey(q => q.LeadId);

        // Lead - Invoice relationship (One-to-Many)
        modelBuilder.Entity<Lead>()
            .HasMany(l => l.Invoices)
            .WithOne(i => i.Lead)
            .HasForeignKey(i => i.LeadId);
            

        modelBuilder.Entity<Campaign>()
            .Property(c => c.ActualCost)
            .HasColumnType("decimal(18, 2)"); // precision: 18, scale: 2

        modelBuilder.Entity<Campaign>()
            .Property(c => c.Budget)
            .HasColumnType("decimal(18, 2)"); // precision: 18, scale: 2

        modelBuilder.Entity<Deal>()
            .Property(d => d.Amount)
            .HasColumnType("decimal(18, 2)");

        modelBuilder.Entity<Invoice>()
            .Property(i => i.TotalAmount)
            .HasColumnType("decimal(18, 2)");

        modelBuilder.Entity<Quote>()
            .Property(q => q.TotalAmount)
            .HasColumnType("decimal(18, 2)");

        }
}

}