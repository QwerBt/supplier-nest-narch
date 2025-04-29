using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class CountryConfiguration : IEntityTypeConfiguration<Country>
{
    public void Configure(EntityTypeBuilder<Country> builder)
    {
        builder.ToTable("Countries").HasKey(c => c.Id);

        builder.Property(c => c.Id).HasColumnName("Id").IsRequired();
        builder.Property(c => c.Name).HasColumnName("Name").IsRequired();
        builder.Property(c => c.Iso2).HasColumnName("Iso2").IsRequired();
        builder.Property(c => c.Iso3).HasColumnName("Iso3").IsRequired();
        builder.Property(c => c.Phonecode).HasColumnName("Phonecode").IsRequired();
        builder.Property(c => c.Capital).HasColumnName("Capital").IsRequired();
        builder.Property(c => c.Currency).HasColumnName("Currency").IsRequired();
        builder.Property(c => c.Native).HasColumnName("Native");
        builder.Property(c => c.Emoji).HasColumnName("Emoji");
        builder.Property(c => c.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(c => c.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(c => c.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(c => !c.DeletedDate.HasValue);
        builder.HasData(_seedsCountry);
    }
    private IEnumerable<Country> _seedsCountry
    {

        get
        {
            var countries = new List<(int Id, string Name, string Iso2, string Iso3, string Phonecode, string Capital, string Currency, string Native)>
            {

    (
        1,
        "Afghanistan",
        "AF",
        "AFG",
        "93",
        "Kabul",
        "AFN",
        "?????????"
    ),
    (
          2,
          "Aland Islands",
          "AX",
          "ALA",
          "+358-18",
          "Mariehamn",
          "EUR",
         "Åland"
    ),
    (
      3,
          "Albania",
          "AL",
          "ALB",
          "355",
          "Tirana",
          "ALL",
         "Shqipëria"
          
    ),
    (
      4,
          "Algeria",
          "DZ",
          "DZA",
          "213",
          "Algiers",
          "DZD",
         "???????"
          
    ),
    (
      5,
          "American Samoa",
          "AS",
          "ASM",
          "+1-684",
          "Pago Pago",
          "USD",
         "American Samoa"
          
    ),
    (
      6,
          "Andorra",
          "AD",
          "AND",
          "376",
          "Andorra la Vella",
          "EUR",
         "Andorra"
          
    ),
    (
      7,
          "Angola",
          "AO",
          "AGO",
          "244",
          "Luanda",
          "AOA",
         "Angola"
          
    ),
    (
      8,
          "Anguilla",
          "AI",
          "AIA",
          "+1-264",
          "The Valley",
          "XCD",
         "Anguilla"
          
    ),
    (
      9,
          "Antarctica",
          "AQ",
          "ATA",
          "672",
          "",
          "AAD",
         "Antarctica"
          
    ),
    (
      10,
          "Antigua And Barbuda",
          "AG",
          "ATG",
          "+1-268",
          "St. John's",
          "XCD",
         "Antigua and Barbuda"
          
    ),
    (
      11,
          "Argentina",
          "AR",
          "ARG",
          "54",
          "Buenos Aires",
          "ARS",
         "Argentina"
          
    ),
    (
      12,
          "Armenia",
          "AM",
          "ARM",
          "374",
          "Yerevan",
          "AMD",
         "????????"
          
    ),
    (
      13,
          "Aruba",
          "AW",
          "ABW",
          "297",
          "Oranjestad",
          "AWG",
         "Aruba"
          
    ),
    (
      14,
          "Australia",
          "AU",
          "AUS",
          "61",
          "Canberra",
          "AUD",
         "Australia"
          
    ),
    (
      15,
          "Austria",
          "AT",
          "AUT",
          "43",
          "Vienna",
          "EUR",
         "Österreich"
          
    ),
    (
      16,
          "Azerbaijan",
          "AZ",
          "AZE",
          "994",
          "Baku",
          "AZN",
         "Az?rbaycan"
          
    ),
    (
      17,
          "The Bahamas",
          "BS",
          "BHS",
          "+1-242",
          "Nassau",
          "BSD",
         "Bahamas"
          
    ),
    (
      18,
          "Bahrain",
          "BH",
          "BHR",
          "973",
          "Manama",
          "BHD",
         "????????"
          
    ),
    (
      19,
          "Bangladesh",
          "BD",
          "BGD",
          "880",
          "Dhaka",
          "BDT",
         "Bangladesh"
          
    ),
    (
      20,
          "Barbados",
          "BB",
          "BRB",
          "+1-246",
          "Bridgetown",
          "BBD",
         "Barbados"
          
    ),
    (
      21,
          "Belarus",
          "BY",
          "BLR",
          "375",
          "Minsk",
          "BYN",
         "?????????"
          
    ),
    (
      22,
          "Belgium",
          "BE",
          "BEL",
          "32",
          "Brussels",
          "EUR",
         "België"
          
    ),
    (
      23,
          "Belize",
          "BZ",
          "BLZ",
          "501",
          "Belmopan",
          "BZD",
         "Belize"
          
    ),
    (
      24,
          "Benin",
          "BJ",
          "BEN",
          "229",
          "Porto-Novo",
          "XOF",
         "Bénin"
          
    ),
    (
      25,
          "Bermuda",
          "BM",
          "BMU",
          "+1-441",
          "Hamilton",
          "BMD",
         "Bermuda"
          
    ),
    (
      26,
          "Bhutan",
          "BT",
          "BTN",
          "975",
          "Thimphu",
          "BTN",
         "?brug-yul"
          
    ),
    (
      27,
          "Bolivia",
          "BO",
          "BOL",
          "591",
          "Sucre",
          "BOB",
         "Bolivia"
          
    ),
    (
      28,
          "Bosnia and Herzegovina",
          "BA",
          "BIH",
          "387",
          "Sarajevo",
          "BAM",
         "Bosna i Hercegovina"
          
    ),
    (
      29,
          "Botswana",
          "BW",
          "BWA",
          "267",
          "Gaborone",
          "BWP",
         "Botswana"
          
    ),
    (
      30,
          "Bouvet Island",
          "BV",
          "BVT",
          "0055",
          "",
          "NOK",
         "Bouvetøya"
          
    ),
    (
      31,
          "Brazil",
          "BR",
          "BRA",
          "55",
          "Brasilia",
          "BRL",
         "Brasil"
          
    ),
    (
      32,
          "British Indian Ocean Territory",
          "IO",
          "IOT",
          "246",
          "Diego Garcia",
          "USD",
         "British Indian Ocean Territory"
          
    ),
    (
      33,
          "Brunei",
          "BN",
          "BRN",
          "673",
          "Bandar Seri Begawan",
          "BND",
         "Negara Brunei Darussalam"
          
    ),
    (
      34,
          "Bulgaria",
          "BG",
          "BGR",
          "359",
          "Sofia",
          "BGN",
         "????????"
         
    ),
    (
      35,
          "Burkina Faso",
          "BF",
          "BFA",
          "226",
          "Ouagadougou",
          "XOF",
         "Burkina Faso"
          
    ),
    (
      36,
          "Burundi",
          "BI",
          "BDI",
          "257",
          "Bujumbura",
          "BIF",
         "Burundi"
          
    ),
    (
      37,
          "Cambodia",
          "KH",
          "KHM",
          "855",
          "Phnom Penh",
          "KHR",
         "Kâmp?chéa"
          
    ),
    (
      38,
          "Cameroon",
          "CM",
          "CMR",
          "237",
          "Yaounde",
          "XAF",
         "Cameroon"
          
    ),
    (
      39,
          "Canada",
          "CA",
          "CAN",
          "1",
          "Ottawa",
          "CAD",
         "Canada"
          
    ),
    (
      40,
          "Cape Verde",
          "CV",
          "CPV",
          "238",
          "Praia",
          "CVE",
         "Cabo Verde"
          
    ),
    (
      41,
          "Cayman Islands",
          "KY",
          "CYM",
          "+1-345",
          "George Town",
          "KYD",
         "Cayman Islands"
          
    ),
    (
      42,
          "Central African Republic",
          "CF",
          "CAF",
          "236",
          "Bangui",
          "XAF",
         "Ködörösêse tî Bêafrîka"
          
    ),
    (
      43,
          "Chad",
          "TD",
          "TCD",
          "235",
          "N'Djamena",
          "XAF",
         "Tchad"
          
    ),
    (
      44,
          "Chile",
          "CL",
          "CHL",
          "56",
          "Santiago",
          "CLP",
         "Chile"
          
    ),
    (
      45,
          "China",
          "CN",
          "CHN",
          "86",
          "Beijing",
          "CNY",
         "??"
          
    ),
    (
      46,
          "Christmas Island",
          "CX",
          "CXR",
          "61",
          "Flying Fish Cove",
          "AUD",
         "Christmas Island"
          
    ),
    (
      47,
          "Cocos (Keeling) Islands",
          "CC",
          "CCK",
          "61",
          "West Island",
          "AUD",
         "Cocos (Keeling) Islands"
          
    ),
    (
      48,
          "Colombia",
          "CO",
          "COL",
          "57",
          "Bogotá",
          "COP",
         "Colombia"
          
    ),
    (
      49,
          "Comoros",
          "KM",
          "COM",
          "269",
          "Moroni",
          "KMF",
         "Komori"
          
    ),
    (
      50,
          "Congo",
          "CG",
          "COG",
          "242",
          "Brazzaville",
          "XAF",
         "République du Congo"
          
    ),
    (
      51,
          "Democratic Republic of the Congo",
          "CD",
          "COD",
          "243",
          "Kinshasa",
          "CDF",
         "République démocratique du Congo"
          
    ),
    (
      52,
          "Cook Islands",
          "CK",
          "COK",
          "682",
          "Avarua",
          "NZD",
         "Cook Islands"
          
    ),
    (
      53,
          "Costa Rica",
          "CR",
          "CRI",
          "506",
          "San Jose",
          "CRC",
         "Costa Rica"
          
    ),
    (
      54,
          "Cote D'Ivoire (Ivory Coast)",
          "CI",
          "CIV",
          "225",
          "Yamoussoukro",
          "XOF",
         null
          
    ),
    (
      55,
          "Croatia",
          "HR",
          "HRV",
          "385",
          "Zagreb",
          "HRK",
         "Hrvatska"
          
    ),
    (
      56,
          "Cuba",
          "CU",
          "CUB",
          "53",
          "Havana",
          "CUP",
         "Cuba"
          
    ),
    (
      57,
          "Cyprus",
          "CY",
          "CYP",
          "357",
          "Nicosia",
          "EUR",
         "??????"
          
    ),
    (
      58,
          "Czech Republic",
          "CZ",
          "CZE",
          "420",
          "Prague",
          "CZK",
         "?eská republika"
          
    ),
    (
      59,
          "Denmark",
          "DK",
          "DNK",
          "45",
          "Copenhagen",
          "DKK",
         "Danmark"
          
    ),
    (
      60,
          "Djibouti",
          "DJ",
          "DJI",
          "253",
          "Djibouti",
          "DJF",
         "Djibouti"
          
    ),
    (
      61,
          "Dominica",
          "DM",
          "DMA",
          "+1-767",
          "Roseau",
          "XCD",
         "Dominica"
          
    ),
    (
      62,
          "Dominican Republic",
          "DO",
          "DOM",
          "+1-809 and 1-829",
          "Santo Domingo",
          "DOP",
         "República Dominicana"
          
    ),
    (
      63,
          "East Timor",
          "TL",
          "TLS",
          "670",
          "Dili",
          "USD",
         "Timor-Leste"
          
    ),
    (
      64,
          "Ecuador",
          "EC",
          "ECU",
          "593",
          "Quito",
          "USD",
         "Ecuador"
          
    ),
    (
      65,
          "Egypt",
          "EG",
          "EGY",
          "20",
          "Cairo",
          "EGP",
          "??"
          
          
    ),
    (
      66,
          "El Salvador",
          "SV",
          "SLV",
          "503",
          "San Salvador",
          "USD",
         "El Salvador"
          
    ),
    (
      67,
          "Equatorial Guinea",
          "GQ",
          "GNQ",
          "240",
          "Malabo",
          "XAF",
         "Guinea Ecuatorial"
          
    ),
    (
      68,
          "Eritrea",
          "ER",
          "ERI",
          "291",
          "Asmara",
          "ERN","??"
         
          
    ),
    (
      69,
          "Estonia",
          "EE",
          "EST",
          "372",
          "Tallinn",
          "EUR",
         "Eesti"
          
    ),
    (
      70,
          "Ethiopia",
          "ET",
          "ETH",
          "251",
          "Addis Ababa",
          "ETB",
         "?????"
          
    ),
    (
      71,
          "Falkland Islands",
          "FK",
          "FLK",
          "500",
          "Stanley",
          "FKP",
         "Falkland Islands"
          
    ),
    (
      72,
          "Faroe Islands",
          "FO",
          "FRO",
          "298",
          "Torshavn",
          "DKK",
         "Føroyar"
          
    ),
    (
      73,
          "Fiji Islands",
          "FJ",
          "FJI",
          "679",
          "Suva",
          "FJD",
         "Fiji"
          
    ),
    (
      74,
          "Finland",
          "FI",
          "FIN",
          "358",
          "Helsinki",
          "EUR",
         "Suomi"
          
    ),
    (
      75,
          "France",
          "FR",
          "FRA",
          "33",
          "Paris",
          "EUR",
         "France"
          
    ),
    (
      76,
          "French Guiana",
          "GF",
          "GUF",
          "594",
          "Cayenne",
          "EUR",
         "Guyane française"
          
    ),
    (
      77,
          "French Polynesia",
          "PF",
          "PYF",
          "689",
          "Papeete",
          "XPF",
         "Polynésie française"
          
    ),
    (
      78,
          "French Southern Territories",
          "TF",
          "ATF",
          "262",
          "Port-aux-Francais",
          "EUR",
         "Territoire des Terres australes et antarctiques fr"
          
    ),
    (
      79,
          "Gabon",
          "GA",
          "GAB",
          "241",
          "Libreville",
          "XAF",
         "Gabon"
          
    ),
    (
      80,
          "Gambia The",
          "GM",
          "GMB",
          "220",
          "Banjul",
          "GMD",
         "Gambia"
          
    ),
    (
      81,
          "Georgia",
          "GE",
          "GEO",
          "995",
          "Tbilisi",
          "GEL",
         "??????????"
          
    ),
    (
      82,
          "Germany",
          "DE",
          "DEU",
          "49",
          "Berlin",
          "EUR",
         "Deutschland"
          
    ),
    (
      83,
          "Ghana",
          "GH",
          "GHA",
          "233",
          "Accra",
          "GHS",
         "Ghana"
          
    ),
    (
      84,
          "Gibraltar",
          "GI",
          "GIB",
          "350",
          "Gibraltar",
          "GIP",
         "Gibraltar"
          
    ),
    (
      85,
          "Greece",
          "GR",
          "GRC",
          "30",
          "Athens",
          "EUR",
         "??????"
          
    ),
    (
      86,
          "Greenland",
          "GL",
          "GRL",
          "299",
          "Nuuk",
          "DKK",
         "Kalaallit Nunaat"
          
    ),
    (
      87,
          "Grenada",
          "GD",
          "GRD",
          "+1-473",
          "St. George's",
          "XCD",
         "Grenada"
          
    ),
    (
      88,
          "Guadeloupe",
          "GP",
          "GLP",
          "590",
          "Basse-Terre",
          "EUR",
         "Guadeloupe"
          
    ),
    (
      89,
          "Guam",
          "GU",
          "GUM",
          "+1-671",
          "Hagatna",
          "USD",
         "Guam"
          
    ),
    (
      90,
          "Guatemala",
          "GT",
          "GTM",
          "502",
          "Guatemala City",
          "GTQ",
         "Guatemala"
          
    ),
    (
      91,
          "Guernsey and Alderney",
          "GG",
          "GGY",
          "+44-1481",
          "St Peter Port",
          "GBP",
         "Guernsey"
          
    ),
    (
      92,
          "Guinea",
          "GN",
          "GIN",
          "224",
          "Conakry",
          "GNF",
         "Guinée"
          
    ),
    (
      93,
          "Guinea-Bissau",
          "GW",
          "GNB",
          "245",
          "Bissau",
          "XOF",
         "Guiné-Bissau"
          
    ),
    (
      94,
          "Guyana",
          "GY",
          "GUY",
          "592",
          "Georgetown",
          "GYD",
         "Guyana"
          
    ),
    (
      95,
          "Haiti",
          "HT",
          "HTI",
          "509",
          "Port-au-Prince",
          "HTG",
         "Haïti"
          
    ),
    (
      96,
          "Heard Island and McDonald Islands",
          "HM",
          "HMD",
          "672",
          "",
          "AUD",
         "Heard Island and McDonald Islands"
          
    ),
    (
      97,
          "Honduras",
          "HN",
          "HND",
          "504",
          "Tegucigalpa",
          "HNL",
         "Honduras"
          
    ),
    (
      98,
          "Hong Kong S.A.R.",
          "HK",
          "HKG",
          "852",
          "Hong Kong",
          "HKD",
         "??"
          
    ),
    (
      99,
          "Hungary",
          "HU",
          "HUN",
          "36",
          "Budapest",
          "HUF",
         "Magyarország"
          
    ),
    (
      100,
          "Iceland",
          "IS",
          "ISL",
          "354",
          "Reykjavik",
          "ISK",
         "Ísland"
          
    ),
    (
      101,
          "India",
          "IN",
          "IND",
          "91",
          "New Delhi",
          "INR","???"
         
          
    ),
    (
      102,
          "Indonesia",
          "ID",
          "IDN",
          "62",
          "Jakarta",
          "IDR",
         "Indonesia"
          
    ),
    (
      103,
          "Iran",
          "IR",
          "IRN",
          "98",
          "Tehran",
          "IRR",
         "?????"
          
    ),
    (
      104,
          "Iraq",
          "IQ",
          "IRQ",
          "964",
          "Baghdad",
          "IQD",
         "??????"
         
    ),
    (
      105,
          "Ireland",
          "IE",
          "IRL",
          "353",
          "Dublin",
          "EUR",
         "Éire"
          
    ),
    (
      106,
          "Israel",
          "IL",
          "ISR",
          "972",
          "Jerusalem",
          "ILS",
         "??????????"
          
    ),
    (
      107,
          "Italy",
          "IT",
          "ITA",
          "39",
          "Rome",
          "EUR",
         "Italia"
          
    ),
    (
      108,
          "Jamaica",
          "JM",
          "JAM",
          "+1-876",
          "Kingston",
          "JMD",
         "Jamaica"
          
    ),
    (
      109,
          "Japan",
          "JP",
          "JPN",
          "81",
          "Tokyo",
          "JPY",
         "??"
          
    ),
    (
      110,
          "Jersey",
          "JE",
          "JEY",
          "+44-1534",
          "Saint Helier",
          "GBP",
         "Jersey"
          
    ),
    (
      111,
          "Jordan",
          "JO",
          "JOR",
          "962",
          "Amman",
          "JOD",
         "??????"
          
    ),
    (
      112,
          "Kazakhstan",
          "KZ",
          "KAZ",
          "7",
          "Astana",
          "KZT",
         "?????????"
          
    ),
    (
      113,
          "Kenya",
          "KE",
          "KEN",
          "254",
          "Nairobi",
          "KES",
         "Kenya"
          
    ),
    (
      114,
          "Kiribati",
          "KI",
          "KIR",
          "686",
          "Tarawa",
          "AUD",
         "Kiribati"
          
    ),
    (
      115,
          "North Korea",
          "KP",
          "PRK",
          "850",
          "Pyongyang",
          "KPW",
         "??"
          
    ),
    (
      116,
          "South Korea",
          "KR",
          "KOR",
          "82",
          "Seoul",
          "KRW","???"
         
          
    ),
    (
      117,
          "Kuwait",
          "KW",
          "KWT",
          "965",
          "Kuwait City",
          "KWD",
         "??????"
          
    ),
    (
      118,
          "Kyrgyzstan",
          "KG",
          "KGZ",
          "996",
          "Bishkek",
          "KGS",
         "??????????"
          
    ),
    (
      119,
          "Laos",
          "LA",
          "LAO",
          "856",
          "Vientiane",
          "LAK",
         "??????"
              ),
    (
      120,
          "Latvia",
          "LV",
          "LVA",
          "371",
          "Riga",
          "EUR",
         "Latvija"
          
    ),
    (
      121,
          "Lebanon",
          "LB",
          "LBN",
          "961",
          "Beirut",
          "LBP",
         "?????"
          
    ),
    (
      122,
          "Lesotho",
          "LS",
          "LSO",
          "266",
          "Maseru",
          "LSL",
         "Lesotho"
          
    ),
    (
      123,
          "Liberia",
          "LR",
          "LBR",
          "231",
          "Monrovia",
          "LRD",
         "Liberia"
          
    ),
    (
      124,
          "Libya",
          "LY",
          "LBY",
          "218",
          "Tripolis",
          "LYD",
         "??????"
          
    ),
    (
      125,
          "Liechtenstein",
          "LI",
          "LIE",
          "423",
          "Vaduz",
          "CHF",
         "Liechtenstein"
          
    ),
    (
      126,
          "Lithuania",
          "LT",
          "LTU",
          "370",
          "Vilnius",
          "EUR",
         "Lietuva"
          
    ),
    (
      127,
          "Luxembourg",
          "LU",
          "LUX",
          "352",
          "Luxembourg",
          "EUR",
         "Luxembourg"
          
    ),
    (
      128,
          "Macau S.A.R.",
          "MO",
          "MAC",
          "853",
          "Macao",
          "MOP",
         "??"
          
    ),
    (
      129,
          "North Macedonia",
          "MK",
          "MKD",
          "389",
          "Skopje",
          "MKD",
         "??????? ??????????"
          
    ),
    (
      130,
          "Madagascar",
          "MG",
          "MDG",
          "261",
          "Antananarivo",
          "MGA",
         "Madagasikara"
          
    ),
    (
      131,
          "Malawi",
          "MW",
          "MWI",
          "265",
          "Lilongwe",
          "MWK",
         "Malawi"
          
    ),
    (
      132,
          "Malaysia",
          "MY",
          "MYS",
          "60",
          "Kuala Lumpur",
          "MYR",
         "Malaysia"
          
    ),
    (
      133,
          "Maldives",
          "MV",
          "MDV",
          "960",
          "Male",
          "MVR",
         "Maldives"
          
    ),
    (
      134,
          "Mali",
          "ML",
          "MLI",
          "223",
          "Bamako",
          "XOF",
         "Mali"
          
    ),
    (
      135,
          "Malta",
          "MT",
          "MLT",
          "356",
          "Valletta",
          "EUR",
         "Malta"
          
    ),
    (
      136,
          "Man (Isle of)",
          "IM",
          "IMN",
          "+44-1624",
          "Douglas, Isle of Man",
          "GBP",
         "Isle of Man"
          
    ),
    (
      137,
          "Marshall Islands",
          "MH",
          "MHL",
          "692",
          "Majuro",
          "USD",
         "M?aje?"
          
    ),
    (
      138,
          "Martinique",
          "MQ",
          "MTQ",
          "596",
          "Fort-de-France",
          "EUR",
         "Martinique"
          
    ),
    (
      139,
          "Mauritania",
          "MR",
          "MRT",
          "222",
          "Nouakchott",
          "MRO",
         "?????????"
          
    ),
    (
      140,
          "Mauritius",
          "MU",
          "MUS",
          "230",
          "Port Louis",
          "MUR",
         "Maurice"
          
    ),
    (
      141,
          "Mayotte",
          "YT",
          "MYT",
          "262",
          "Mamoudzou",
          "EUR",
         "Mayotte"
          
    ),
    (
      142,
          "Mexico",
          "MX",
          "MEX",
          "52",
          "Ciudad de México",
          "MXN",
         "México"
          
    ),
    (
      143,
          "Micronesia",
          "FM",
          "FSM",
          "691",
          "Palikir",
          "USD",
         "Micronesia"
          
    ),
    (
      144,
          "Moldova",
          "MD",
          "MDA",
          "373",
          "Chisinau",
          "MDL",
         "Moldova"
          
    ),
    (
      145,
          "Monaco",
          "MC",
          "MCO",
          "377",
          "Monaco",
          "EUR",
         "Monaco"
          
    ),
    (
      146,
          "Mongolia",
          "MN",
          "MNG",
          "976",
          "Ulan Bator",
          "MNT",
         "?????? ???"
          
    ),
    (
      147,
          "Montenegro",
          "ME",
          "MNE",
          "382",
          "Podgorica",
          "EUR",
         "???? ????"
          
    ),
    (
      148,
          "Montserrat",
          "MS",
          "MSR",
          "+1-664",
          "Plymouth",
          "XCD",
         "Montserrat"
          
    ),
    (
      149,
          "Morocco",
          "MA",
          "MAR",
          "212",
          "Rabat",
          "MAD",
         "??????"
          
    ),
    (
      150,
          "Mozambique",
          "MZ",
          "MOZ",
          "258",
          "Maputo",
          "MZN",
         "Moçambique"
          
    ),
    (
      151,
          "Myanmar",
          "MM",
          "MMR",
          "95",
          "Nay Pyi Taw",
          "MMK",
         "??????"
          
    ),
    (
      152,
          "Namibia",
          "NA",
          "NAM",
          "264",
          "Windhoek",
          "NAD",
         "Namibia"
          
    ),
    (
      153,
          "Nauru",
          "NR",
          "NRU",
          "674",
          "Yaren",
          "AUD",
         "Nauru"
          
    ),
    (
      154,
          "Nepal",
          "NP",
          "NPL",
          "977",
          "Kathmandu",
          "NPR",
         "???"
          
    ),
    (
      155,
          "Bonaire, Sint Eustatius and Saba",
          "BQ",
          "BES",
          "599",
          "Kralendijk",
          "USD",
         "Caribisch Nederland"
          
    ),
    (
      156,
          "Netherlands",
          "NL",
          "NLD",
          "31",
          "Amsterdam",
          "EUR",
         "Nederland"
          
    ),
    (
      157,
          "New Caledonia",
          "NC",
          "NCL",
          "687",
          "Noumea",
          "XPF",
         "Nouvelle-Calédonie"
          
    ),
    (
      158,
          "New Zealand",
          "NZ",
          "NZL",
          "64",
          "Wellington",
          "NZD",
         "New Zealand"
          
    ),
    (
      159,
          "Nicaragua",
          "NI",
          "NIC",
          "505",
          "Managua",
          "NIO",
         "Nicaragua"
          
    ),
    (
      160,
          "Niger",
          "NE",
          "NER",
          "227",
          "Niamey",
          "XOF",
         "Niger"
          
    ),
    (
      161,
          "Nigeria",
          "NG",
          "NGA",
          "234",
          "Abuja",
          "NGN",
         "Nigeria"
          
    ),
    (
      162,
          "Niue",
          "NU",
          "NIU",
          "683",
          "Alofi",
          "NZD",
         "Niu?"
          
    ),
    (
      163,
          "Norfolk Island",
          "NF",
          "NFK",
          "672",
          "Kingston",
          "AUD",
         "Norfolk Island"
          
    ),
    (
      164,
          "Northern Mariana Islands",
          "MP",
          "MNP",
          "+1-670",
          "Saipan",
          "USD",
         "Northern Mariana Islands"
          
    ),
    (
      165,
          "Norway",
          "NO",
          "NOR",
          "47",
          "Oslo",
          "NOK",
         "Norge"
          
    ),
    (
      166,
          "Oman",
          "OM",
          "OMN",
          "968",
          "Muscat",
          "OMR","???"
         
          
    ),
    (
      167,
          "Pakistan",
          "PK",
          "PAK",
          "92",
          "Islamabad",
          "PKR",
         "Pakistan"
          
    ),
    (
      168,
          "Palau",
          "PW",
          "PLW",
          "680",
          "Melekeok",
          "USD",
         "Palau"
          
    ),
    (
      169,
          "Palestinian Territory Occupied",
          "PS",
          "PSE",
          "970",
          "East Jerusalem",
          "ILS",
         "??????"
          
    ),
    (
      170,
          "Panama",
          "PA",
          "PAN",
          "507",
          "Panama City",
          "PAB",
         "Panamá"
          
    ),
    (
      171,
          "Papua new Guinea",
          "PG",
          "PNG",
          "675",
          "Port Moresby",
          "PGK",
         "Papua Niugini"
          
    ),
    (
      172,
          "Paraguay",
          "PY",
          "PRY",
          "595",
          "Asuncion",
          "PYG",
         "Paraguay"
          
    ),
    (
      173,
          "Peru",
          "PE",
          "PER",
          "51",
          "Lima",
          "PEN",
         "Perú"
          
    ),
    (
      174,
          "Philippines",
          "PH",
          "PHL",
          "63",
          "Manila",
          "PHP",
         "Pilipinas"
          
    ),
    (
      175,
          "Pitcairn Island",
          "PN",
          "PCN",
          "870",
          "Adamstown",
          "NZD",
         "Pitcairn Islands"
          
    ),
    (
      176,
          "Poland",
          "PL",
          "POL",
          "48",
          "Warsaw",
          "PLN",
         "Polska"
          
    ),
    (
      177,
          "Portugal",
          "PT",
          "PRT",
          "351",
          "Lisbon",
          "EUR",
         "Portugal"
          
    ),
    (
      178,
          "Puerto Rico",
          "PR",
          "PRI",
          "+1-787 and 1-939",
          "San Juan",
          "USD",
         "Puerto Rico"
          
    ),
    (
      179,
          "Qatar",
          "QA",
          "QAT",
          "974",
          "Doha",
          "QAR",
         "???"
          
    ),
    (
      180,
          "Reunion",
          "RE",
          "REU",
          "262",
          "Saint-Denis",
          "EUR",
         "La Réunion"
          
    ),
    (
      181,
          "Romania",
          "RO",
          "ROU",
          "40",
          "Bucharest",
          "RON",
         "România"
          
    ),
    (
      182,
          "Russia",
          "RU",
          "RUS",
          "7",
          "Moscow",
          "RUB",
         "??????"
          
    ),
    (
      183,
          "Rwanda",
          "RW",
          "RWA",
          "250",
          "Kigali",
          "RWF",
         "Rwanda"
          
    ),
    (
      184,
          "Saint Helena",
          "SH",
          "SHN",
          "290",
          "Jamestown",
          "SHP",
         "Saint Helena"
          
    ),
    (
      185,
          "Saint Kitts And Nevis",
          "KN",
          "KNA",
          "+1-869",
          "Basseterre",
          "XCD",
         "Saint Kitts and Nevis"
          
    ),
    (
      186,
          "Saint Lucia",
          "LC",
          "LCA",
          "+1-758",
          "Castries",
          "XCD",
         "Saint Lucia"
          
    ),
    (
      187,
          "Saint Pierre and Miquelon",
          "PM",
          "SPM",
          "508",
          "Saint-Pierre",
          "EUR",
         "Saint-Pierre-et-Miquelon"
          
    ),
    (
      188,
          "Saint Vincent And The Grenadines",
          "VC",
          "VCT",
          "+1-784",
          "Kingstown",
          "XCD",
         "Saint Vincent and the Grenadines"
          
    ),
    (
      189,
          "Saint-Barthelemy",
          "BL",
          "BLM",
          "590",
          "Gustavia",
          "EUR",
         "Saint-Barthélemy"
         
    ),
    (
      190,
          "Saint-Martin (French part)",
          "MF",
          "MAF",
          "590",
          "Marigot",
          "EUR",
         "Saint-Martin"
          
    ),
    (
      191,
          "Samoa",
          "WS",
          "WSM",
          "685",
          "Apia",
          "WST",
         "Samoa"
          
    ),
    (
      192,
          "San Marino",
          "SM",
          "SMR",
          "378",
          "San Marino",
          "EUR",
         "San Marino"
          
    ),
    (
      193,
          "Sao Tome and Principe",
          "ST",
          "STP",
          "239",
          "Sao Tome",
          "STD",
         "São Tomé e Príncipe"
          
    ),
    (
      194,
          "Saudi Arabia",
          "SA",
          "SAU",
          "966",
          "Riyadh",
          "SAR",
         "??????? ??????? ????????"
          
    ),
    (
      195,
          "Senegal",
          "SN",
          "SEN",
          "221",
          "Dakar",
          "XOF",
         "Sénégal"
          
    ),
    (
      196,
          "Serbia",
          "RS",
          "SRB",
          "381",
          "Belgrade",
          "RSD",
         "??????"
          
    ),
    (
      197,
          "Seychelles",
          "SC",
          "SYC",
          "248",
          "Victoria",
          "SCR",
         "Seychelles"
          
    ),
    (
      198,
          "Sierra Leone",
          "SL",
          "SLE",
          "232",
          "Freetown",
          "SLL",
         "Sierra Leone"
          
    ),
    (
      199,
          "Singapore",
          "SG",
          "SGP",
          "65",
          "Singapur",
          "SGD",
         "Singapore"
         
    ),
    (
      200,
          "Slovakia",
          "SK",
          "SVK",
          "421",
          "Bratislava",
          "EUR",
         "Slovensko"
          
    ),
    (
      201,
          "Slovenia",
          "SI",
          "SVN",
          "386",
          "Ljubljana",
          "EUR",
         "Slovenija"
          
    ),
    (
      202,
          "Solomon Islands",
          "SB",
          "SLB",
          "677",
          "Honiara",
          "SBD",
         "Solomon Islands"
          
    ),
    (
      203,
          "Somalia",
          "SO",
          "SOM",
          "252",
          "Mogadishu",
          "SOS",
         "Soomaaliya"
          
    ),
    (
      204,
          "South Africa",
          "ZA",
          "ZAF",
          "27",
          "Pretoria",
          "ZAR",
         "South Africa"
          
    ),
    (
      205,
          "South Georgia",
          "GS",
          "SGS",
          "500",
          "Grytviken",
          "GBP",
         "South Georgia"
          
    ),
    (
      206,
          "South Sudan",
          "SS",
          "SSD",
          "211",
          "Juba",
          "SSP",
         "South Sudan"
          
    ),
    (
      207,
          "Spain",
          "ES",
          "ESP",
          "34",
          "Madrid",
          "EUR",
         "España"
          
    ),
    (
      208,
          "Sri Lanka",
          "LK",
          "LKA",
          "94",
          "Colombo",
          "LKR",
         "?r? la?k?va"
          
    ),
    (
      209,
          "Sudan",
          "SD",
          "SDN",
          "249",
          "Khartoum",
          "SDG",
         "???????"
          
    ),
    (
      210,
          "Suriname",
          "SR",
          "SUR",
          "597",
          "Paramaribo",
          "SRD",
         "Suriname"
          
    ),
    (
      211,
          "Svalbard And Jan Mayen Islands",
          "SJ",
          "SJM",
          "47",
          "Longyearbyen",
          "NOK",
         "Svalbard og Jan Mayen"
          
    ),
    (
      212,
          "Swaziland",
          "SZ",
          "SWZ",
          "268",
          "Mbabane",
          "SZL",
         "Swaziland"
          
    ),
    (
      213,
          "Sweden",
          "SE",
          "SWE",
          "46",
          "Stockholm",
          "SEK",
         "Sverige"
          
    ),
    (
      214,
          "Switzerland",
          "CH",
          "CHE",
          "41",
          "Bern",
          "CHF",
         "Schweiz"
          
    ),
    (
      215,
          "Syria",
          "SY",
          "SYR",
          "963",
          "Damascus",
          "SYP",
         "?????"
          
    ),
    (
      216,
          "Taiwan",
          "TW",
          "TWN",
          "886",
          "Taipei",
          "TWD",
         "??"
          
    ),
    (
      217,
          "Tajikistan",
          "TJ",
          "TJK",
          "992",
          "Dushanbe",
          "TJS",
         "??????????"
          
    ),
    (
      218,
          "Tanzania",
          "TZ",
          "TZA",
          "255",
          "Dodoma",
          "TZS",
         "Tanzania"
          
    ),
    (
      219,
          "Thailand",
          "TH",
          "THA",
          "66",
          "Bangkok",
          "THB",
         "?????????"
          
    ),
    (
      220,
          "Togo",
          "TG",
          "TGO",
          "228",
          "Lome",
          "XOF",
         "Togo"
          
    ),
    (
      221,
          "Tokelau",
          "TK",
          "TKL",
          "690",
          "",
          "NZD",
         "Tokelau"
          
    ),
    (
      222,
          "Tonga",
          "TO",
          "TON",
          "676",
          "Nuku'alofa",
          "TOP",
         "Tonga"
          
    ),
    (
      223,
          "Trinidad And Tobago",
          "TT",
          "TTO",
          "+1-868",
          "Port of Spain",
          "TTD",
         "Trinidad and Tobago"
          
    ),
    (
      224,
          "Tunisia",
          "TN",
          "TUN",
          "216",
          "Tunis",
          "TND","???"
         
          
    ),
    (
      225,
          "Turkey",
          "TR",
          "TUR",
          "90",
          "Ankara",
          "TRY",
         "Türkiye"
          
    ),
    (
      226,
          "Turkmenistan",
          "TM",
          "TKM",
          "993",
          "Ashgabat",
          "TMT",
         "Türkmenistan"
          
    ),
    (
      227,
          "Turks And Caicos Islands",
          "TC",
          "TCA",
          "+1-649",
          "Cockburn Town",
          "USD",
         "Turks and Caicos Islands"
          
    ),
    (
      228,
          "Tuvalu",
          "TV",
          "TUV",
          "688",
          "Funafuti",
          "AUD",
         "Tuvalu"
          
    ),
    (
      229,
          "Uganda",
          "UG",
          "UGA",
          "256",
          "Kampala",
          "UGX",
         "Uganda"
          
    ),
    (
      230,
          "Ukraine",
          "UA",
          "UKR",
          "380",
          "Kyiv",
          "UAH",
         "???????"
          
    ),
    (
      231,
          "United Arab Emirates",
          "AE",
          "ARE",
          "971",
          "Abu Dhabi",
          "AED",
         "???? ???????? ??????? ???????"
          
    ),
    (
      232,
          "United Kingdom",
          "GB",
          "GBR",
          "44",
          "London",
          "GBP",
         "United Kingdom"
          
    ),
    (
      233,
          "United States",
          "US",
          "USA",
          "1",
          "Washington",
          "USD",
         "United States"
          
    ),
    (
      234,
          "United States Minor Outlying Islands",
          "UM",
          "UMI",
          "1",
          "",
          "USD",
         "United States Minor Outlying Islands"
          
    ),
    (
      235,
          "Uruguay",
          "UY",
          "URY",
          "598",
          "Montevideo",
          "UYU",
         "Uruguay"
          
    ),
    (
      236,
          "Uzbekistan",
          "UZ",
          "UZB",
          "998",
          "Tashkent",
          "UZS",
         "O‘zbekiston"
          
    ),
    (
      237,
          "Vanuatu",
          "VU",
          "VUT",
          "678",
          "Port Vila",
          "VUV",
         "Vanuatu"
          
    ),
    (
      238,
          "Vatican City State (Holy See)",
          "VA",
          "VAT",
          "379",
          "Vatican City",
          "EUR",
         "Vaticano"
          
    ),
    (
      239,
          "Venezuela",
          "VE",
          "VEN",
          "58",
          "Caracas",
          "VES",
         "Venezuela"
          
    ),
    (
      240,
          "Vietnam",
          "VN",
          "VNM",
          "84",
          "Hanoi",
          "VND",
         "Vi?t Nam"
          
    ),
    (
      241,
          "Virgin Islands (British)",
          "VG",
          "VGB",
          "+1-284",
          "Road Town",
          "USD",
         "British Virgin Islands"
          
    ),
    (
      242,
          "Virgin Islands (US)",
          "VI",
          "VIR",
          "+1-340",
          "Charlotte Amalie",
          "USD",
         "United States Virgin Islands"
          
    ),
    (
      243,
          "Wallis And Futuna Islands",
          "WF",
          "WLF",
          "681",
          "Mata Utu",
          "XPF",
         "Wallis et Futuna"
          
    ),
    (
      244,
          "Western Sahara",
          "EH",
          "ESH",
          "212",
          "El-Aaiun",
          "MAD",
         "??????? ???????"
          
    ),
    (
      245,
          "Yemen",
          "YE",
          "YEM",
          "967",
          "Sanaa",
          "YER",
         "???????"
         
    ),
    (
      246,
          "Zambia",
          "ZM",
          "ZMB",
          "260",
          "Lusaka",
          "ZMW",
         "Zambia"
          
    ),
    (
      247,
          "Zimbabwe",
          "ZW",
          "ZWE",
          "263",
          "Harare",
          "ZWL",
         "Zimbabwe"
          
    ),
    (
      248,
          "Kosovo",
          "XK",
          "XKX",
          "383",
          "Pristina",
          "EUR",
         "Republika e Kosovës"
          
    ),
    (
      249,
          "Curaçao",
          "CW",
          "CUW",
          "599",
          "Willemstad",
          "ANG",
         "Curaçao"
          
    ),
    (
      250,
          "Sint Maarten (Dutch part)",
          "SX",
          "SXM",
          "1721",
          "Philipsburg",
          "ANG",
         "Sint Maarten"
          
    )


            };
            foreach (var cou in countries)
            {
                yield return new Country
                {
                    Id = cou.Id,
                    Name = cou.Name,
                    Iso2 = cou.Iso2,
                    Iso3 = cou.Iso3,
                    Phonecode = cou.Phonecode,
                    Capital = cou.Capital,
                    Currency = cou.Currency,
                    Native = cou.Native,
               
                };
            }

        }
    }


}