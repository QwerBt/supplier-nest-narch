using System.Reflection;
using Application.Services.AuthenticatorService;
using Application.Services.AuthService;
using Application.Services.UsersService;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using NArchitecture.Core.Application.Pipelines.Validation;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Logging.Abstraction;
using NArchitecture.Core.CrossCuttingConcerns.Logging.Configurations;
using NArchitecture.Core.CrossCuttingConcerns.Logging.Serilog.File;
using NArchitecture.Core.ElasticSearch;
using NArchitecture.Core.ElasticSearch.Models;
using NArchitecture.Core.Localization.Resource.Yaml.DependencyInjection;
using NArchitecture.Core.Mailing;
using NArchitecture.Core.Mailing.MailKit;
using NArchitecture.Core.Security.DependencyInjection;
using NArchitecture.Core.Security.JWT;
using Application.Services.Transactions;
using Application.Services.TransactionDetails;
using Application.Services.Categories;
using Application.Services.Companies;
using Application.Services.CompanyAddresses;
using Application.Services.CompanyContacts;
using Application.Services.CompanyUsers;
using Application.Services.Items;
using Application.Services.ItemUoms;
using Application.Services.Uoms;
using Application.Services.CompanyImages;
using Application.Services.ItemSpecifications;
using Application.Services.Specifications;
using Application.Services.SpecificationValues;
using Application.Services.Products;
using Application.Services.CompanyServices;
using Application.Services.Services;
using Application.Services.Cities;
using Application.Services.Regions;
using Application.Services.Countries;
using Application.Services.Towns;
using Application.Services.ProductImages;
using Application.Services.Industries;
using Application.Services.JobFunctions;
using Application.Services.Disciplines;
using Application.Services.JobLevels;
using Application.Services.Roles;
using Application.Services.UserRoles;
using Application.Services.CompanyCategories;
using Application.Services.CompanyBrands;


namespace Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(
        this IServiceCollection services,
        MailSettings mailSettings,
        FileLogConfiguration fileLogConfiguration,
        ElasticSearchConfig elasticSearchConfig,
        TokenOptions tokenOptions
    )
    {
 
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            configuration.AddOpenBehavior(typeof(AuthorizationBehavior<,>));
            configuration.AddOpenBehavior(typeof(CachingBehavior<,>));
            configuration.AddOpenBehavior(typeof(CacheRemovingBehavior<,>));
            configuration.AddOpenBehavior(typeof(LoggingBehavior<,>));
            configuration.AddOpenBehavior(typeof(RequestValidationBehavior<,>));
            configuration.AddOpenBehavior(typeof(TransactionScopeBehavior<,>));
        });

        services.AddSubClassesOfType(Assembly.GetExecutingAssembly(), typeof(BaseBusinessRules));

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        services.AddSingleton<IMailService, MailKitMailService>(_ => new MailKitMailService(mailSettings));
        services.AddSingleton<ILogger, SerilogFileLogger>(_ => new SerilogFileLogger(fileLogConfiguration));
        services.AddSingleton<IElasticSearch, ElasticSearchManager>(_ => new ElasticSearchManager(elasticSearchConfig));

        services.AddScoped<IAuthService, AuthManager>();
        services.AddScoped<IAuthenticatorService, AuthenticatorManager>();
        services.AddScoped<IUserService, UserManager>();

        services.AddYamlResourceLocalization();

        services.AddSecurityServices<Guid, int, Guid>(tokenOptions);

         services.AddScoped<ITransactionService, TransactionManager>();
         services.AddScoped<ITransactionDetailService, TransactionDetailManager>();
         services.AddScoped<ICategoryService, CategoryManager>();
         services.AddScoped<ICompanyService, CompanyManager>();
         services.AddScoped<ICompanyAddressService, CompanyAddressManager>();
         services.AddScoped<ICompanyContactService, CompanyContactManager>();
         services.AddScoped<ICompanyUserService, CompanyUserManager>();
         services.AddScoped<IItemService, ItemManager>();
         services.AddScoped<IItemUomService, ItemUomManager>();
         services.AddScoped<IUomService, UomManager>();
         services.AddScoped<ICompanyImageService, CompanyImageManager>();
         services.AddScoped<IProductImageService, ProductImageManager>();
         services.AddScoped<IItemSpecificationService, ItemSpecificationManager>();
         services.AddScoped<ISpecificationService, SpecificationManager>();
         services.AddScoped<ISpecificationValueService, SpecificationValueManager>();
         services.AddScoped<IProductService, ProductManager>();
         services.AddScoped<ICompanyServiceService, CompanyServiceManager>();
         services.AddScoped<IServiceService, ServiceManager>();
         services.AddScoped<ICityService, CityManager>();
         services.AddScoped<IRegionService, RegionManager>();
         services.AddScoped<ICountryService, CountryManager>();
         services.AddScoped<ITownService, TownManager>();
         services.AddScoped<IIndustryService, IndustryManager>();
         services.AddScoped<IJobFunctionService, JobFunctionManager>();
         services.AddScoped<IDisciplineService, DisciplineManager>();
         services.AddScoped<IJobLevelService, JobLevelManager>();
         services.AddScoped<IRoleService, RoleManager>();
         services.AddScoped<IUserRoleService, UserRoleManager>();
 services.AddScoped<ISpecificationService, SpecificationManager>();
 services.AddScoped<ICompanyCategoryService, CompanyCategoryManager>();
 services.AddScoped<ICompanyBrandService, CompanyBrandManager>();
 services.AddScoped<ICompanyBrandService, CompanyBrandManager>();
        return services;
    }

    public static IServiceCollection AddSubClassesOfType(
        this IServiceCollection services,
        Assembly assembly,
        Type type,
        Func<IServiceCollection, Type, IServiceCollection>? addWithLifeCycle = null
    )
    {
        var types = assembly.GetTypes().Where(t => t.IsSubclassOf(type) && type != t).ToList();
        foreach (Type? item in types)
            if (addWithLifeCycle == null)
                services.AddScoped(item);
            else
                addWithLifeCycle(services, type);
        return services;
    }
}
