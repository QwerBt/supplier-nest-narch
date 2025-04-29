using Application.Services.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NArchitecture.Core.Persistence.DependencyInjection;
using Persistence.Contexts;
using Persistence.Repositories;

namespace Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        
        services.AddDbContext<BaseDbContext>(options => options.UseSqlServer("Server=DESKTOP-AN0AOBO; Database=qwer; Trusted_Connection=True; TrustServerCertificate=True;"));
        //services.AddDbContext<BaseDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("BaseDb")));
        services.AddDbMigrationApplier(buildServices => buildServices.GetRequiredService<BaseDbContext>());

        services.AddScoped<IEmailAuthenticatorRepository, EmailAuthenticatorRepository>();
        services.AddScoped<IOperationClaimRepository, OperationClaimRepository>();
        services.AddScoped<IOtpAuthenticatorRepository, OtpAuthenticatorRepository>();
        services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUserOperationClaimRepository, UserOperationClaimRepository>();
        services.AddScoped<ITransactionRepository, TransactionRepository>();
        services.AddScoped<ITransactionDetailRepository, TransactionDetailRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<ICompanyRepository, CompanyRepository>();
        services.AddScoped<ICompanyAddressRepository, CompanyAddressRepository>();
        services.AddScoped<ICompanyContactRepository, CompanyContactRepository>();
        services.AddScoped<ICompanyUserRepository, CompanyUserRepository>();
        services.AddScoped<IItemRepository, ItemRepository>();
        services.AddScoped<IItemUomRepository, ItemUomRepository>();
        services.AddScoped<IUomRepository, UomRepository>();
        services.AddScoped<ICompanyImageRepository, CompanyImageRepository>();
        services.AddScoped<IProductImageRepository, ProductImageRepository>();
        services.AddScoped<IItemSpecificationRepository, ItemSpecificationRepository>();
        services.AddScoped<ISpecificationRepository, SpecificationRepository>();
        services.AddScoped<ISpecificationValueRepository, SpecificationValueRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<ICompanyServiceRepository, CompanyServiceRepository>();
        services.AddScoped<IServiceRepository, ServiceRepository>();
        services.AddScoped<IRegionRepository, RegionRepository>();
        services.AddScoped<ICityRepository, CityRepository>();
        services.AddScoped<ITownRepository, TownRepository>();
        services.AddScoped<ICountryRepository, CountryRepository>();
        services.AddScoped<IIndustryRepository, IndustryRepository>();
        services.AddScoped<IJobFunctionRepository, JobFunctionRepository>();
        services.AddScoped<IDisciplineRepository, DisciplineRepository>();
        services.AddScoped<IJobLevelRepository, JobLevelRepository>();
        services.AddScoped<IRoleRepository, RoleRepository>();
        services.AddScoped<IUserRoleRepository, UserRoleRepository>();
        services.AddScoped<ICompanyCategoryRepository, CompanyCategoryRepository>();
        services.AddScoped<ICompanyBrandRepository, CompanyBrandRepository>();
        services.AddScoped<ICompanyBrandRepository, CompanyBrandRepository>();
        return services;
    }
}
