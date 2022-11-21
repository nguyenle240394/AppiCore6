using System;
using System.Collections.Generic;

namespace DemoApiNet6.Data;

public partial class DmBillOfLading
{
    public Guid RowId { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedDate { get; set; }

    public string ModifiedBy { get; set; } = null!;

    public DateTime ModifiedDate { get; set; }

    public string ShipKey { get; set; } = null!;

    public string? Pol { get; set; }

    public string? Pod { get; set; }

    public string Hblno { get; set; } = null!;

    public string? FromPort { get; set; }

    public decimal Quantity { get; set; }

    public string UnitCode { get; set; } = null!;

    public int NumOfPackage { get; set; }

    public int NumOfContainer { get; set; }

    public string? SaleContractNo { get; set; }

    public DateTime? SaleContractDate { get; set; }

    public string? Lcnumber { get; set; }

    public string? BondedWarehouseContractNo { get; set; }

    public bool Inactive { get; set; }

    public string EnterpriseCode { get; set; } = null!;

    public string? InwardDeclarationNo { get; set; }

    public DateTime? InwardDeclarationDate { get; set; }

    public string? InwardDeclarationStatus { get; set; }

    public string? OutwardDeclarationNo { get; set; }

    public DateTime? OutwardDeclarationDate { get; set; }

    public string? OutwardDeclarationStatus { get; set; }

    public string? NoteBill { get; set; }
}
