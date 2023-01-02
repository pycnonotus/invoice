using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class InvoiceDbContext : DbContext
{
	private readonly string _dbPath;
	
	public InvoiceDbContext()
	{
		var path = Environment.CurrentDirectory;
		_dbPath =Path.Join(path, "invoice.db");
	}
	
	// public DbSet<Product> Products { get; set; } = null!;
	public DbSet<Customer> Customers { get; set; } = null!;
	public DbSet<Invoice> Invoices { get; set; } = null!;

	protected override void OnConfiguring(DbContextOptionsBuilder builder)
	{
		builder
			.UseSqlite($"Data Source={(_dbPath)}")
			.UseLazyLoadingProxies();

			;
	}
	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Invoice>()
			.HasOne(i => i.Customer)
			.WithMany()
			.HasForeignKey(x=> x.CustomerId)
			;


	}
	
}
