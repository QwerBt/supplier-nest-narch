using System.Reflection;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Persistence.Contexts;

public class BaseDbContext : DbContext
{
    protected IConfiguration Configuration { get; set; }
    public DbSet<EmailAuthenticator> EmailAuthenticators { get; set; }
    public DbSet<OperationClaim> OperationClaims { get; set; }
    public DbSet<OtpAuthenticator> OtpAuthenticators { get; set; }
    public DbSet<RefreshToken> RefreshTokens { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
    public DbSet<Transaction> Transactions { get; set; }
    public DbSet<TransactionDetail> TransactionDetails { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Company> Companies { get; set; }
    public DbSet<CompanyAddress> CompanyAddresses { get; set; }
    public DbSet<CompanyContact> CompanyContacts { get; set; }
    public DbSet<CompanyUser> CompanyUsers { get; set; }
    public DbSet<Item> Items { get; set; }
    public DbSet<ItemUom> ItemUoms { get; set; }
    public DbSet<Uom> Uoms { get; set; }
    public DbSet<CompanyImage> CompanyImages { get; set; }
    public DbSet<ProductImage> ProductImages { get; set; }
    public DbSet<Specification> Specifications { get; set; }
    public DbSet<SpecificationValue> SpecificationValues { get; set; }
    public DbSet<ItemSpecification> ItemSpecifications { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<CompanyService> CompanyServices { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<Region> Regions { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<Town> Towns { get; set; }
    public DbSet<Industry> Industries { get; set; }
    public DbSet<JobFunction> JobFunctions { get; set; }
    public DbSet<Discipline> Disciplines { get; set; }
    public DbSet<JobLevel> JobLevels { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }
    public DbSet<CompanyCategory> CompanyCategories { get; set; }
    public DbSet<CompanyBrand> CompanyBrands { get; set; }
 
  

    public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration)
        : base(dbContextOptions)
    {
        Configuration = configuration;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
