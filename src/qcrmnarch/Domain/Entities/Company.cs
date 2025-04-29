using Domain.Enums;
using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class Company : Entity<int>
{
    // Firma Genel Bilgileri
    public string Name { get; set; }           // Firma Adı
    public string? TaxId { get; set; }          // Vergi Numarası (Kurumsal firmalar için)
    public string Phone1 { get; set; }    // Telefon Numarasıcv
    public string? Phone2 { get; set; }    // Telefon Numarasıcv
    public string Email { get; set; }          // E-posta
    public string Website { get; set; }        // Web Sitesi

    public string Description { get; set; }


    // Finansal Bilgiler
    public string? BankAccountNumber { get; set; }  // Banka Hesap Numarası
    public string? BankName { get; set; }            // Banka Adı

    // Müşteri Özellikleri

    public bool? IsVerified { get; set; }                   // Müşteri doğrulandı mı?
    public decimal? CreditLimit { get; set; }               // Müşteri Kredi Limiti
    public string? PaymentTerms { get; set; }               // Ödeme Şartları (e.g., 30 gün vadeli)


    // Sosyal Medya ve Web Bilgileri
    public string? FacebookUrl { get; set; }                    // Facebook URL
    public string? TwitterUrl { get; set; }                      // Twitter URL
    public string? LinkedInUrl { get; set; }                     // LinkedIn URL


    // Firma Durumu
    public bool IsActive { get; set; }  // Firma aktif mi (true/false)


    public int IndustryId { get; set; }
    public virtual Industry Industry { get; set; }
    public virtual ICollection<CompanyAddress>? CompanyAddresses { get; set; }= new HashSet<CompanyAddress>();
    public virtual ICollection<CompanyContact>? CompanyContacts { get; set; } = new HashSet<CompanyContact>();
    public virtual ICollection<Transaction>? Transactions { get; set; } = new HashSet<Transaction>();
    public virtual ICollection<CompanyImage>? CompanyImages { get; set; } = new HashSet<CompanyImage>();
    public virtual ICollection<CompanyCategory>? CompanyCategories { get; set; } = new HashSet<CompanyCategory>();
    public virtual ICollection<CompanyBrand>? CompanyBrands{ get; set; } = new HashSet<CompanyBrand>();



    public Company()
    {

    }

    public Company(string name, string? taxId, string phone1, string? phone2, string email, string website, string description, string? bankAccountNumber, string? bankName, bool? ısVerified, decimal? creditLimit, string? paymentTerms, string? facebookUrl, string? twitterUrl, string? linkedInUrl, bool ısActive, int ındustryId, Industry ındustry, ICollection<CompanyAddress>? companyAddresses, ICollection<CompanyContact>? companyContacts, ICollection<Transaction>? transactions, ICollection<CompanyImage>? companyImages, ICollection<CompanyCategory>? companyCategories, ICollection<CompanyBrand>? companyBrands)
    {
        Name = name;
        TaxId = taxId;
        Phone1 = phone1;
        Phone2 = phone2;
        Email = email;
        Website = website;
        Description = description;
        BankAccountNumber = bankAccountNumber;
        BankName = bankName;
        IsVerified = ısVerified;
        CreditLimit = creditLimit;
        PaymentTerms = paymentTerms;
        FacebookUrl = facebookUrl;
        TwitterUrl = twitterUrl;
        LinkedInUrl = linkedInUrl;
        IsActive = ısActive;
        IndustryId = ındustryId;
        Industry = ındustry;
        CompanyAddresses = companyAddresses;
        CompanyContacts = companyContacts;
        Transactions = transactions;
        CompanyImages = companyImages;
        CompanyCategories = companyCategories;
        CompanyBrands = companyBrands;
    }
}


