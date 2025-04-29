using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Domain.Enums;

public enum CompanyStatus
{
    [Description("Firma Onaylandı.")]
    Approved = 1,

    [Description("Firma Kaydedildi.")]
    Registered = 2
 
}
