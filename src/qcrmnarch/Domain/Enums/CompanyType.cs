using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Domain.Enums;

public enum CompanyType
{
    [Description("Firms that process raw materials or semi-finished products into final products.")]
    Manufacturing= 1,

    [Description("Firms providing support services such as maintenance, logistics, and consulting to industrial processes.")]
    ServiceProviding= 2,

    [Description("Firms supplying raw materials or processing natural resources.")]
    RawMaterialAndResource= 3,

    [Description("Firms developing technology or providing automation solutions for industrial processes.")]
    TechnologyAndAutomation= 4,

    [Description("Firms involved in the production of chemicals and pharmaceuticals.")]
    ChemicalAndPharmaceutical= 5,

    [Description("Firms operating in energy production, distribution, and infrastructure development.")]
    EnergyAndInfrastructure= 6,

    [Description("Firms supplying raw materials or equipment for industry.")]
    SupplyAndDistributor= 7
}
