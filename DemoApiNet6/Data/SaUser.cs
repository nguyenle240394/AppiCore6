using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoApiNet6.Data;

public partial class SaUser
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid RowId { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedDate { get; set; }

    public string ModifiedBy { get; set; } = null!;

    public DateTime ModifiedDate { get; set; }

    public string UserCode { get; set; } = null!;

    public string? UserName { get; set; }

    public string? UserFullName { get; set; }

    public string? PasswordHash { get; set; }

    public DateTime? PasswordExpiredDate { get; set; }

    public DateTime? Birthday { get; set; }

    public string? PhoneNumber { get; set; }

    public string? FaxNumber { get; set; }

    public string? Address { get; set; }

    public string? Email { get; set; }

    public string EnterpriseCode { get; set; } = null!;

    public string? DataModifiers { get; set; }

    public string? Position { get; set; }

    public bool Inactive { get; set; }

    public string? EmployeeCode { get; set; }
}
