using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class CompanyContact : Entity<int>
{
    public string FullName { get; set; }         // İletişim Kişisinin Adı ve Soyadı
    public string Phone1 { get; set; }      // İletişim Kişisinin Telefon Numarası
    public string Phone2 { get; set; }      // İletişim Kişisinin Telefon Numarası
    public string Email { get; set; }            // İletişim Kişisinin E-posta Adresi
    public string Position { get; set; }         // İletişim Kişisinin Pozisyonu (isteğe bağlı)
    public bool IsPrimary { get; set; }          // Bu iletişim kişisi birincil mi? (Firma için ana kişi)

    // İlişkili Firma Bilgileri
    public int CompanyId { get; set; }           // İlişkili Firma ID
    public virtual Company? Company { get; set; }         // İlişkili Firma (Navigation Property)
    public CompanyContact()
    {
    }

    public CompanyContact(string fullName, string phone1, string phone2, string email, string position, bool ısPrimary, int companyId, Company? company)
    {
        FullName = fullName;
        Phone1 = phone1;
        Phone2 = phone2;
        Email = email;
        Position = position;
        IsPrimary = ısPrimary;
        CompanyId = companyId;
        Company = company;
    }
}
