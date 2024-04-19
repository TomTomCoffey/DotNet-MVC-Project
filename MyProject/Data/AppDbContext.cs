using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyProject.Models;

public class ApplicationDbContext :  DbContext // IdentityDbContext<ApplicationUser>// <-- this is for identity
{

    public ApplicationDbContext()
    {

    }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    { }
    public DbSet<Customer>? Customers { get; set; }
    public DbSet<Movie>? Movies { get; set; }

    public DbSet<Genre>? Genres { get; set; }

    public DbSet<MembershipType>? MembershipType { get; set; }
}