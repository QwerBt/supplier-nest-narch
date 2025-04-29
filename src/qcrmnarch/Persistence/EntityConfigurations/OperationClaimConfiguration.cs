using Application.Features.Auth.Constants;
using Application.Features.OperationClaims.Constants;
using Application.Features.UserOperationClaims.Constants;
using Application.Features.Users.Constants;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NArchitecture.Core.Security.Constants;
using Application.Features.Transactions.Constants;
using Application.Features.TransactionDetails.Constants;
using Application.Features.Categories.Constants;
using Application.Features.Companies.Constants;
using Application.Features.CompanyAddresses.Constants;
using Application.Features.CompanyContacts.Constants;
using Application.Features.CompanyUsers.Constants;
using Application.Features.Items.Constants;
using Application.Features.ItemUoms.Constants;
using Application.Features.Uoms.Constants;
using Application.Features.CompanyImages.Constants;
using Application.Features.Industries.Constants;
using Application.Features.JobFunctions.Constants;
using Application.Features.Disciplines.Constants;
using Application.Features.JobLevels.Constants;
using Application.Features.Roles.Constants;
using Application.Features.UserRoles.Constants;
using Application.Features.ItemSpecifications.Constants;
using Application.Features.Specifications.Constants;
using Application.Features.SpecificationValues.Constants;
using Application.Features.Products.Constants;
using Application.Features.ProductImages.Constants;
using Application.Features.CompanyServices.Constants;
using Application.Features.Services.Constants;
using Application.Features.Cities.Constants;
using Application.Features.Regions.Constants;
using Application.Features.Countries.Constants;
using Application.Features.Towns.Constants;
using Application.Features.CompanyAddresses.Constants;
using Application.Features.Countries.Constants;
using Application.Features.SpecificationValues.Constants;
using Application.Features.SpecificationValues.Constants;
using Application.Features.ItemSpecifications.Constants;
using Application.Features.Specifications.Constants;
using Application.Features.CompanyCategories.Constants;
using Application.Features.CompanyBrands.Constants;
using Application.Features.CompanyBrands.Constants;









  
namespace Persistence.EntityConfigurations;

public class OperationClaimConfiguration : IEntityTypeConfiguration<OperationClaim>
{
    public void Configure(EntityTypeBuilder<OperationClaim> builder)
    {
        builder.ToTable("OperationClaims").HasKey(oc => oc.Id);

        builder.Property(oc => oc.Id).HasColumnName("Id").IsRequired();
        builder.Property(oc => oc.Name).HasColumnName("Name").IsRequired();
        builder.Property(oc => oc.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(oc => oc.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(oc => oc.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(oc => !oc.DeletedDate.HasValue);

        builder.HasData(_seeds);

        builder.HasBaseType((string)null!);
    }

    public static int AdminId => 1;
    private IEnumerable<OperationClaim> _seeds
    {
        get
        {
            yield return new() { Id = AdminId, Name = GeneralOperationClaims.Admin };

            IEnumerable<OperationClaim> featureOperationClaims = getFeatureOperationClaims(AdminId);
            foreach (OperationClaim claim in featureOperationClaims)
                yield return claim;
        }
    }

#pragma warning disable S1854 // Unused assignments should be removed
    private IEnumerable<OperationClaim> getFeatureOperationClaims(int initialId)
    {
        int lastId = initialId;
        List<OperationClaim> featureOperationClaims = new();

        #region Auth
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = AuthOperationClaims.Admin },
                new() { Id = ++lastId, Name = AuthOperationClaims.Read },
                new() { Id = ++lastId, Name = AuthOperationClaims.Write },
                new() { Id = ++lastId, Name = AuthOperationClaims.RevokeToken },
            ]
        );
        #endregion

        #region OperationClaims
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Admin },
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Read },
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Write },
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Create },
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Update },
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Delete },
            ]
        );
        #endregion

        #region UserOperationClaims
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Admin },
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Read },
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Write },
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Create },
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Update },
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Delete },
            ]
        );
        #endregion

        #region Users
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = UsersOperationClaims.Admin },
                new() { Id = ++lastId, Name = UsersOperationClaims.Read },
                new() { Id = ++lastId, Name = UsersOperationClaims.Write },
                new() { Id = ++lastId, Name = UsersOperationClaims.Create },
                new() { Id = ++lastId, Name = UsersOperationClaims.Update },
                new() { Id = ++lastId, Name = UsersOperationClaims.Delete },
            ]
        );
        #endregion

        

               
        
        featureOperationClaims.Add(new() { Id = ++lastId, Name = AuthOperationClaims.GoogleLogin });
        

        
        
        #region Transactions CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = TransactionsOperationClaims.Admin },
                new() { Id = ++lastId, Name = TransactionsOperationClaims.Read },
                new() { Id = ++lastId, Name = TransactionsOperationClaims.Write },
                new() { Id = ++lastId, Name = TransactionsOperationClaims.Create },
                new() { Id = ++lastId, Name = TransactionsOperationClaims.Update },
                new() { Id = ++lastId, Name = TransactionsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region TransactionDetails CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = TransactionDetailsOperationClaims.Admin },
                new() { Id = ++lastId, Name = TransactionDetailsOperationClaims.Read },
                new() { Id = ++lastId, Name = TransactionDetailsOperationClaims.Write },
                new() { Id = ++lastId, Name = TransactionDetailsOperationClaims.Create },
                new() { Id = ++lastId, Name = TransactionDetailsOperationClaims.Update },
                new() { Id = ++lastId, Name = TransactionDetailsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Categories CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = CategoriesOperationClaims.Admin },
                new() { Id = ++lastId, Name = CategoriesOperationClaims.Read },
                new() { Id = ++lastId, Name = CategoriesOperationClaims.Write },
                new() { Id = ++lastId, Name = CategoriesOperationClaims.Create },
                new() { Id = ++lastId, Name = CategoriesOperationClaims.Update },
                new() { Id = ++lastId, Name = CategoriesOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Companies CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = CompaniesOperationClaims.Admin },
                new() { Id = ++lastId, Name = CompaniesOperationClaims.Read },
                new() { Id = ++lastId, Name = CompaniesOperationClaims.Write },
                new() { Id = ++lastId, Name = CompaniesOperationClaims.Create },
                new() { Id = ++lastId, Name = CompaniesOperationClaims.Update },
                new() { Id = ++lastId, Name = CompaniesOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region CompanyAddresses CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = CompanyAddressesOperationClaims.Admin },
                new() { Id = ++lastId, Name = CompanyAddressesOperationClaims.Read },
                new() { Id = ++lastId, Name = CompanyAddressesOperationClaims.Write },
                new() { Id = ++lastId, Name = CompanyAddressesOperationClaims.Create },
                new() { Id = ++lastId, Name = CompanyAddressesOperationClaims.Update },
                new() { Id = ++lastId, Name = CompanyAddressesOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region CompanyContacts CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = CompanyContactsOperationClaims.Admin },
                new() { Id = ++lastId, Name = CompanyContactsOperationClaims.Read },
                new() { Id = ++lastId, Name = CompanyContactsOperationClaims.Write },
                new() { Id = ++lastId, Name = CompanyContactsOperationClaims.Create },
                new() { Id = ++lastId, Name = CompanyContactsOperationClaims.Update },
                new() { Id = ++lastId, Name = CompanyContactsOperationClaims.Delete },
            ]
        );
        #endregion
               
        
        #region CompanyUsers CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = CompanyUsersOperationClaims.Admin },
                new() { Id = ++lastId, Name = CompanyUsersOperationClaims.Read },
                new() { Id = ++lastId, Name = CompanyUsersOperationClaims.Write },
                new() { Id = ++lastId, Name = CompanyUsersOperationClaims.Create },
                new() { Id = ++lastId, Name = CompanyUsersOperationClaims.Update },
                new() { Id = ++lastId, Name = CompanyUsersOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Items CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = ItemsOperationClaims.Admin },
                new() { Id = ++lastId, Name = ItemsOperationClaims.Read },
                new() { Id = ++lastId, Name = ItemsOperationClaims.Write },
                new() { Id = ++lastId, Name = ItemsOperationClaims.Create },
                new() { Id = ++lastId, Name = ItemsOperationClaims.Update },
                new() { Id = ++lastId, Name = ItemsOperationClaims.Delete },
            ]
        );
        #endregion
        
     
        
        #region ItemUoms CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = ItemUomsOperationClaims.Admin },
                new() { Id = ++lastId, Name = ItemUomsOperationClaims.Read },
                new() { Id = ++lastId, Name = ItemUomsOperationClaims.Write },
                new() { Id = ++lastId, Name = ItemUomsOperationClaims.Create },
                new() { Id = ++lastId, Name = ItemUomsOperationClaims.Update },
                new() { Id = ++lastId, Name = ItemUomsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Uoms CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = UomsOperationClaims.Admin },
                new() { Id = ++lastId, Name = UomsOperationClaims.Read },
                new() { Id = ++lastId, Name = UomsOperationClaims.Write },
                new() { Id = ++lastId, Name = UomsOperationClaims.Create },
                new() { Id = ++lastId, Name = UomsOperationClaims.Update },
                new() { Id = ++lastId, Name = UomsOperationClaims.Delete },
            ]
        );
        #endregion
       
        
        #region CompanyImages CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = CompanyImagesOperationClaims.Admin },
                new() { Id = ++lastId, Name = CompanyImagesOperationClaims.Read },
                new() { Id = ++lastId, Name = CompanyImagesOperationClaims.Write },
                new() { Id = ++lastId, Name = CompanyImagesOperationClaims.Create },
                new() { Id = ++lastId, Name = CompanyImagesOperationClaims.Update },
                new() { Id = ++lastId, Name = CompanyImagesOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region ProductImages CRUD
        featureOperationClaims.AddRange(
            [
 
                new() { Id = ++lastId, Name = ProductImagesOperationClaims.Admin },
                new() { Id = ++lastId, Name = ProductImagesOperationClaims.Read },
                new() { Id = ++lastId, Name = ProductImagesOperationClaims.Write },
                new() { Id = ++lastId, Name = ProductImagesOperationClaims.Create },
                new() { Id = ++lastId, Name = ProductImagesOperationClaims.Update },
                new() { Id = ++lastId, Name = ProductImagesOperationClaims.Delete },
 
            ]
        );
        #endregion
        
        
        #region Items CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = ItemsOperationClaims.Admin },
                new() { Id = ++lastId, Name = ItemsOperationClaims.Read },
                new() { Id = ++lastId, Name = ItemsOperationClaims.Write },
                new() { Id = ++lastId, Name = ItemsOperationClaims.Create },
                new() { Id = ++lastId, Name = ItemsOperationClaims.Update },
                new() { Id = ++lastId, Name = ItemsOperationClaims.Delete },
            ]
        );
        #endregion
        
 
        
        #region ItemSpecifications CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = ItemSpecificationsOperationClaims.Admin },
                new() { Id = ++lastId, Name = ItemSpecificationsOperationClaims.Read },
                new() { Id = ++lastId, Name = ItemSpecificationsOperationClaims.Write },
                new() { Id = ++lastId, Name = ItemSpecificationsOperationClaims.Create },
                new() { Id = ++lastId, Name = ItemSpecificationsOperationClaims.Update },
                new() { Id = ++lastId, Name = ItemSpecificationsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Specifications CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = SpecificationsOperationClaims.Admin },
                new() { Id = ++lastId, Name = SpecificationsOperationClaims.Read },
                new() { Id = ++lastId, Name = SpecificationsOperationClaims.Write },
                new() { Id = ++lastId, Name = SpecificationsOperationClaims.Create },
                new() { Id = ++lastId, Name = SpecificationsOperationClaims.Update },
                new() { Id = ++lastId, Name = SpecificationsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region SpecificationValues CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = SpecificationValuesOperationClaims.Admin },
                new() { Id = ++lastId, Name = SpecificationValuesOperationClaims.Read },
                new() { Id = ++lastId, Name = SpecificationValuesOperationClaims.Write },
                new() { Id = ++lastId, Name = SpecificationValuesOperationClaims.Create },
                new() { Id = ++lastId, Name = SpecificationValuesOperationClaims.Update },
                new() { Id = ++lastId, Name = SpecificationValuesOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Items CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = ItemsOperationClaims.Admin },
                new() { Id = ++lastId, Name = ItemsOperationClaims.Read },
                new() { Id = ++lastId, Name = ItemsOperationClaims.Write },
                new() { Id = ++lastId, Name = ItemsOperationClaims.Create },
                new() { Id = ++lastId, Name = ItemsOperationClaims.Update },
                new() { Id = ++lastId, Name = ItemsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Products CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = ProductsOperationClaims.Admin },
                new() { Id = ++lastId, Name = ProductsOperationClaims.Read },
                new() { Id = ++lastId, Name = ProductsOperationClaims.Write },
                new() { Id = ++lastId, Name = ProductsOperationClaims.Create },
                new() { Id = ++lastId, Name = ProductsOperationClaims.Update },
                new() { Id = ++lastId, Name = ProductsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region CompanyServices CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = CompanyServicesOperationClaims.Admin },
                new() { Id = ++lastId, Name = CompanyServicesOperationClaims.Read },
                new() { Id = ++lastId, Name = CompanyServicesOperationClaims.Write },
                new() { Id = ++lastId, Name = CompanyServicesOperationClaims.Create },
                new() { Id = ++lastId, Name = CompanyServicesOperationClaims.Update },
                new() { Id = ++lastId, Name = CompanyServicesOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Services CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = ServicesOperationClaims.Admin },
                new() { Id = ++lastId, Name = ServicesOperationClaims.Read },
                new() { Id = ++lastId, Name = ServicesOperationClaims.Write },
                new() { Id = ++lastId, Name = ServicesOperationClaims.Create },
                new() { Id = ++lastId, Name = ServicesOperationClaims.Update },
                new() { Id = ++lastId, Name = ServicesOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Cities CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = CitiesOperationClaims.Admin },
                new() { Id = ++lastId, Name = CitiesOperationClaims.Read },
                new() { Id = ++lastId, Name = CitiesOperationClaims.Write },
                new() { Id = ++lastId, Name = CitiesOperationClaims.Create },
                new() { Id = ++lastId, Name = CitiesOperationClaims.Update },
                new() { Id = ++lastId, Name = CitiesOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Regions CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = RegionsOperationClaims.Admin },
                new() { Id = ++lastId, Name = RegionsOperationClaims.Read },
                new() { Id = ++lastId, Name = RegionsOperationClaims.Write },
                new() { Id = ++lastId, Name = RegionsOperationClaims.Create },
                new() { Id = ++lastId, Name = RegionsOperationClaims.Update },
                new() { Id = ++lastId, Name = RegionsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Regions CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = RegionsOperationClaims.Admin },
                new() { Id = ++lastId, Name = RegionsOperationClaims.Read },
                new() { Id = ++lastId, Name = RegionsOperationClaims.Write },
                new() { Id = ++lastId, Name = RegionsOperationClaims.Create },
                new() { Id = ++lastId, Name = RegionsOperationClaims.Update },
                new() { Id = ++lastId, Name = RegionsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Countries CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = CountriesOperationClaims.Admin },
                new() { Id = ++lastId, Name = CountriesOperationClaims.Read },
                new() { Id = ++lastId, Name = CountriesOperationClaims.Write },
                new() { Id = ++lastId, Name = CountriesOperationClaims.Create },
                new() { Id = ++lastId, Name = CountriesOperationClaims.Update },
                new() { Id = ++lastId, Name = CountriesOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Countries CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = CountriesOperationClaims.Admin },
                new() { Id = ++lastId, Name = CountriesOperationClaims.Read },
                new() { Id = ++lastId, Name = CountriesOperationClaims.Write },
                new() { Id = ++lastId, Name = CountriesOperationClaims.Create },
                new() { Id = ++lastId, Name = CountriesOperationClaims.Update },
                new() { Id = ++lastId, Name = CountriesOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Towns CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = TownsOperationClaims.Admin },
                new() { Id = ++lastId, Name = TownsOperationClaims.Read },
                new() { Id = ++lastId, Name = TownsOperationClaims.Write },
                new() { Id = ++lastId, Name = TownsOperationClaims.Create },
                new() { Id = ++lastId, Name = TownsOperationClaims.Update },
                new() { Id = ++lastId, Name = TownsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Countries CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = CountriesOperationClaims.Admin },
                new() { Id = ++lastId, Name = CountriesOperationClaims.Read },
                new() { Id = ++lastId, Name = CountriesOperationClaims.Write },
                new() { Id = ++lastId, Name = CountriesOperationClaims.Create },
                new() { Id = ++lastId, Name = CountriesOperationClaims.Update },
                new() { Id = ++lastId, Name = CountriesOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Cities CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = CitiesOperationClaims.Admin },
                new() { Id = ++lastId, Name = CitiesOperationClaims.Read },
                new() { Id = ++lastId, Name = CitiesOperationClaims.Write },
                new() { Id = ++lastId, Name = CitiesOperationClaims.Create },
                new() { Id = ++lastId, Name = CitiesOperationClaims.Update },
                new() { Id = ++lastId, Name = CitiesOperationClaims.Delete },
            ]
        );
        #endregion
 
 
 #region Industries CRUD
 featureOperationClaims.AddRange(
     [
         new() { Id = ++lastId, Name = IndustriesOperationClaims.Admin },
         new() { Id = ++lastId, Name = IndustriesOperationClaims.Read },
         new() { Id = ++lastId, Name = IndustriesOperationClaims.Write },
         new() { Id = ++lastId, Name = IndustriesOperationClaims.Create },
         new() { Id = ++lastId, Name = IndustriesOperationClaims.Update },
         new() { Id = ++lastId, Name = IndustriesOperationClaims.Delete },
     ]
 );
 #endregion
 
 
 #region JobFunctions CRUD
 featureOperationClaims.AddRange(
     [
         new() { Id = ++lastId, Name = JobFunctionsOperationClaims.Admin },
         new() { Id = ++lastId, Name = JobFunctionsOperationClaims.Read },
         new() { Id = ++lastId, Name = JobFunctionsOperationClaims.Write },
         new() { Id = ++lastId, Name = JobFunctionsOperationClaims.Create },
         new() { Id = ++lastId, Name = JobFunctionsOperationClaims.Update },
         new() { Id = ++lastId, Name = JobFunctionsOperationClaims.Delete },
     ]
 );
 #endregion
 
 
 #region Disciplines CRUD
 featureOperationClaims.AddRange(
     [
         new() { Id = ++lastId, Name = DisciplinesOperationClaims.Admin },
         new() { Id = ++lastId, Name = DisciplinesOperationClaims.Read },
         new() { Id = ++lastId, Name = DisciplinesOperationClaims.Write },
         new() { Id = ++lastId, Name = DisciplinesOperationClaims.Create },
         new() { Id = ++lastId, Name = DisciplinesOperationClaims.Update },
         new() { Id = ++lastId, Name = DisciplinesOperationClaims.Delete },
     ]
 );
 #endregion
 
 
 #region Disciplines CRUD
 featureOperationClaims.AddRange(
     [
         new() { Id = ++lastId, Name = DisciplinesOperationClaims.Admin },
         new() { Id = ++lastId, Name = DisciplinesOperationClaims.Read },
         new() { Id = ++lastId, Name = DisciplinesOperationClaims.Write },
         new() { Id = ++lastId, Name = DisciplinesOperationClaims.Create },
         new() { Id = ++lastId, Name = DisciplinesOperationClaims.Update },
         new() { Id = ++lastId, Name = DisciplinesOperationClaims.Delete },
     ]
 );
 #endregion
 
 
 #region JobLevels CRUD
 featureOperationClaims.AddRange(
     [
         new() { Id = ++lastId, Name = JobLevelsOperationClaims.Admin },
         new() { Id = ++lastId, Name = JobLevelsOperationClaims.Read },
         new() { Id = ++lastId, Name = JobLevelsOperationClaims.Write },
         new() { Id = ++lastId, Name = JobLevelsOperationClaims.Create },
         new() { Id = ++lastId, Name = JobLevelsOperationClaims.Update },
         new() { Id = ++lastId, Name = JobLevelsOperationClaims.Delete },
     ]
 );
 #endregion
 
 
 #region Roles CRUD
 featureOperationClaims.AddRange(
     [
         new() { Id = ++lastId, Name = RolesOperationClaims.Admin },
         new() { Id = ++lastId, Name = RolesOperationClaims.Read },
         new() { Id = ++lastId, Name = RolesOperationClaims.Write },
         new() { Id = ++lastId, Name = RolesOperationClaims.Create },
         new() { Id = ++lastId, Name = RolesOperationClaims.Update },
         new() { Id = ++lastId, Name = RolesOperationClaims.Delete },
     ]
 );
 #endregion
 
 
 #region UserRoles CRUD
 featureOperationClaims.AddRange(
     [
         new() { Id = ++lastId, Name = UserRolesOperationClaims.Admin },
         new() { Id = ++lastId, Name = UserRolesOperationClaims.Read },
         new() { Id = ++lastId, Name = UserRolesOperationClaims.Write },
         new() { Id = ++lastId, Name = UserRolesOperationClaims.Create },
         new() { Id = ++lastId, Name = UserRolesOperationClaims.Update },
         new() { Id = ++lastId, Name = UserRolesOperationClaims.Delete },
     ]
 );
 #endregion
 
 
 #region CompanyAddresses CRUD
 featureOperationClaims.AddRange(
     [
         new() { Id = ++lastId, Name = CompanyAddressesOperationClaims.Admin },
         new() { Id = ++lastId, Name = CompanyAddressesOperationClaims.Read },
         new() { Id = ++lastId, Name = CompanyAddressesOperationClaims.Write },
         new() { Id = ++lastId, Name = CompanyAddressesOperationClaims.Create },
         new() { Id = ++lastId, Name = CompanyAddressesOperationClaims.Update },
         new() { Id = ++lastId, Name = CompanyAddressesOperationClaims.Delete },
     ]
 );
 #endregion
 
 
 #region Countries CRUD
 featureOperationClaims.AddRange(
     [
         new() { Id = ++lastId, Name = CountriesOperationClaims.Admin },
         new() { Id = ++lastId, Name = CountriesOperationClaims.Read },
         new() { Id = ++lastId, Name = CountriesOperationClaims.Write },
         new() { Id = ++lastId, Name = CountriesOperationClaims.Create },
         new() { Id = ++lastId, Name = CountriesOperationClaims.Update },
         new() { Id = ++lastId, Name = CountriesOperationClaims.Delete },
     ]
 );
 #endregion
 
 
 #region SpecificationValues CRUD
 featureOperationClaims.AddRange(
     [
         new() { Id = ++lastId, Name = SpecificationValuesOperationClaims.Admin },
         new() { Id = ++lastId, Name = SpecificationValuesOperationClaims.Read },
         new() { Id = ++lastId, Name = SpecificationValuesOperationClaims.Write },
         new() { Id = ++lastId, Name = SpecificationValuesOperationClaims.Create },
         new() { Id = ++lastId, Name = SpecificationValuesOperationClaims.Update },
         new() { Id = ++lastId, Name = SpecificationValuesOperationClaims.Delete },
     ]
 );
 #endregion
 
 
 #region SpecificationValues CRUD
 featureOperationClaims.AddRange(
     [
         new() { Id = ++lastId, Name = SpecificationValuesOperationClaims.Admin },
         new() { Id = ++lastId, Name = SpecificationValuesOperationClaims.Read },
         new() { Id = ++lastId, Name = SpecificationValuesOperationClaims.Write },
         new() { Id = ++lastId, Name = SpecificationValuesOperationClaims.Create },
         new() { Id = ++lastId, Name = SpecificationValuesOperationClaims.Update },
         new() { Id = ++lastId, Name = SpecificationValuesOperationClaims.Delete },
     ]
 );
 #endregion
 
 
 #region ItemSpecifications CRUD
 featureOperationClaims.AddRange(
     [
         new() { Id = ++lastId, Name = ItemSpecificationsOperationClaims.Admin },
         new() { Id = ++lastId, Name = ItemSpecificationsOperationClaims.Read },
         new() { Id = ++lastId, Name = ItemSpecificationsOperationClaims.Write },
         new() { Id = ++lastId, Name = ItemSpecificationsOperationClaims.Create },
         new() { Id = ++lastId, Name = ItemSpecificationsOperationClaims.Update },
         new() { Id = ++lastId, Name = ItemSpecificationsOperationClaims.Delete },
     ]
 );
 #endregion
 
 
 #region Specifications CRUD
 featureOperationClaims.AddRange(
     [
         new() { Id = ++lastId, Name = SpecificationsOperationClaims.Admin },
         new() { Id = ++lastId, Name = SpecificationsOperationClaims.Read },
         new() { Id = ++lastId, Name = SpecificationsOperationClaims.Write },
         new() { Id = ++lastId, Name = SpecificationsOperationClaims.Create },
         new() { Id = ++lastId, Name = SpecificationsOperationClaims.Update },
         new() { Id = ++lastId, Name = SpecificationsOperationClaims.Delete },
     ]
 );
 #endregion
 
 
 #region CompanyCategories CRUD
 featureOperationClaims.AddRange(
     [
         new() { Id = ++lastId, Name = CompanyCategoriesOperationClaims.Admin },
         new() { Id = ++lastId, Name = CompanyCategoriesOperationClaims.Read },
         new() { Id = ++lastId, Name = CompanyCategoriesOperationClaims.Write },
         new() { Id = ++lastId, Name = CompanyCategoriesOperationClaims.Create },
         new() { Id = ++lastId, Name = CompanyCategoriesOperationClaims.Update },
         new() { Id = ++lastId, Name = CompanyCategoriesOperationClaims.Delete },
     ]
 );
 #endregion
 
 
 featureOperationClaims.Add(new() { Id = ++lastId, Name = CompanyCategoriesOperationClaims.GetByCompanyId });
 
 featureOperationClaims.Add(new() { Id = ++lastId, Name = CompanyCategoriesOperationClaims.GetListByDynamic });
 
 #region CompanyBrands CRUD
 featureOperationClaims.AddRange(
     [
         new() { Id = ++lastId, Name = CompanyBrandsOperationClaims.Admin },
         new() { Id = ++lastId, Name = CompanyBrandsOperationClaims.Read },
         new() { Id = ++lastId, Name = CompanyBrandsOperationClaims.Write },
         new() { Id = ++lastId, Name = CompanyBrandsOperationClaims.Create },
         new() { Id = ++lastId, Name = CompanyBrandsOperationClaims.Update },
         new() { Id = ++lastId, Name = CompanyBrandsOperationClaims.Delete },
     ]
 );
 #endregion
 
 
 #region CompanyBrands CRUD
 featureOperationClaims.AddRange(
     [
         new() { Id = ++lastId, Name = CompanyBrandsOperationClaims.Admin },
         new() { Id = ++lastId, Name = CompanyBrandsOperationClaims.Read },
         new() { Id = ++lastId, Name = CompanyBrandsOperationClaims.Write },
         new() { Id = ++lastId, Name = CompanyBrandsOperationClaims.Create },
         new() { Id = ++lastId, Name = CompanyBrandsOperationClaims.Update },
         new() { Id = ++lastId, Name = CompanyBrandsOperationClaims.Delete },
     ]
 );
 #endregion
 
        return featureOperationClaims;
    }
#pragma warning restore S1854 // Unused assignments should be removed
}
