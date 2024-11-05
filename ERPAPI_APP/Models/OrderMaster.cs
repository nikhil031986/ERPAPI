using System;
using System.Collections.Generic;

namespace ERPAPI_APP.Models;

public partial class OrderMaster
{
    public int Id { get; set; }

    public string? OrderId { get; set; }

    public int CustomerId { get; set; }

    public DateTime? OrderDate { get; set; }

    public int? PaymentMethodId { get; set; }

    public int? PaymentTermId { get; set; }

    public decimal? TotalAmout { get; set; }

    public decimal? DiscountAmount { get; set; }

    public DateTime? CreateAt { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual ICollection<OrderPaymentDetail> OrderPaymentDetails { get; set; } = new List<OrderPaymentDetail>();

    public virtual ICollection<OrderPayment> OrderPayments { get; set; } = new List<OrderPayment>();

    public virtual ICollection<OrderShipment> OrderShipments { get; set; } = new List<OrderShipment>();
}
