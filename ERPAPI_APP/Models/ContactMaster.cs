using System;
using System.Collections.Generic;

namespace ERPAPI_APP.Models;

public partial class ContactMaster
{
    public int Id { get; set; }

    public string? Slug { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? PhoneExtension { get; set; }

    public string? Titled { get; set; }

    public string? Contact { get; set; }

    public string? Name { get; set; }

    public string? Phone { get; set; }

    public int? CustomerId { get; set; }

    public string? Email { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public int? ContactTranId { get; set; }
}
