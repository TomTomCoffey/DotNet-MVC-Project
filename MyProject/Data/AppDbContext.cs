using Microsoft.EntityFrameworkCore;
using MyProject.Models;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    { }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    { }
    public DbSet<Customer>? Customers { get; set; }
    public DbSet<Movie>? Movies { get; set; }
}