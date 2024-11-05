using ERPAPI_APP.Controllers;
using ERPAPI_APP.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Transactions;

namespace ERPAPI_APP.DataBaseAccess
{
    internal class DaOrder
    {
        internal static async Task<List<GetOrderMaster>> GetOrderDetail(string orderId)
        {
            List<GetOrderMaster> lstorderMaster = new List<GetOrderMaster>();
            try
            {
                using (var scope = new TransactionScope(
                        TransactionScopeOption.Required,
                        new TransactionOptions { IsolationLevel = IsolationLevel.ReadUncommitted }))
                {
                    using (var context = new ErpDbContext())
                    {
                        var objOrder = context.OrderMasters.Where(x => x.OrderId == orderId).FirstOrDefault();
                        if (objOrder != null)
                        {
                            var orderMasterEntry = new GetOrderMaster();
                            orderMasterEntry.Id = objOrder.Id;
                            orderMasterEntry.customer = context.CustomerMasters.Where(x => x.CustomerId == objOrder.CustomerId).FirstOrDefault();
                            orderMasterEntry.OrderId = objOrder.OrderId;
                            orderMasterEntry.CustomerId = objOrder.CustomerId;
                            orderMasterEntry.PaymentMethodId = objOrder.PaymentMethodId;
                            orderMasterEntry.DiscountAmount = objOrder.DiscountAmount;
                            orderMasterEntry.TotalAmout = objOrder.DiscountAmount;
                            orderMasterEntry.PaymentTermId = objOrder.PaymentTermId;
                            orderMasterEntry.OrderDate = objOrder.OrderDate;
                            orderMasterEntry.pymethod = context.PaymentMethods.Where(x => x.Id == objOrder.PaymentMethodId).FirstOrDefault();
                            orderMasterEntry.pyTerm = context.PaymentTerms.Where(x => x.Id == objOrder.PaymentTermId).FirstOrDefault();
                            orderMasterEntry.OrderPayments = context.OrderPayments.Where(x => x.OrderId == objOrder.Id).Select(x =>
                            new GetOrderPayment
                            {
                                Id = x.Id,
                                OrderId = x.OrderId,
                                PaymentTerm = x.PaymentTerm,
                                PaymentType = x.PaymentType,
                                Amount = x.Amount,
                            }).ToList();
                            orderMasterEntry.OrderDetails = context.OrderDetails.Where(x => x.OrderId == objOrder.Id).Select(x =>
                            new GetOrderDetail
                            {
                                Id = x.Id,
                                OrderId = x.OrderId,
                                Qty = x.Qty,
                                ItemPrice = x.ItemPrice,
                                ItemCode = x.ItemCode,
                                itemDesc = context.ItemMasters.Where(i => i.ItemName == x.ItemCode).FirstOrDefault().ItemDescription,
                                imgPath = DAItems.getImagePath(x.ItemCode),
                                Unit = x.Unit,
                            }).ToList();
                            orderMasterEntry.OrderShipments = context.OrderShipments.Where(x => x.OrderId == objOrder.Id).Select(x =>
                            new GetOrderShipment
                            {
                                Id = x.Id,
                                OrderId = objOrder.Id,
                                Address1 = x.Address1,
                                Address2 = x.Address2,
                                State = x.State,
                                Contry = x.Contry,
                                PhoneNumber = x.PhoneNumber,
                                Email = x.Email,
                            }).ToList();

                            lstorderMaster.Add(orderMasterEntry);
                        }
                    }
                    scope.Complete();
                }
                return lstorderMaster;
            }
            catch (Exception)
            {
                return lstorderMaster;
            }
        }


        internal static async Task<OrderMaster> SaveOrder(OrderMasterEntry orderMaster)
        {
            OrderMaster addedEntry = null;
            Random random = new Random();
            var newOrderId = DateTime.Now.ToString("dd-MM-yyyy").Replace("-", "") + random.Next().ToString() + "_" + orderMaster.CustomerId;
            try
            {
                using (var scope = new TransactionScope(
                         TransactionScopeOption.Required,
                         new TransactionOptions { IsolationLevel = IsolationLevel.ReadUncommitted }))
                {
                    using (var context = new ErpDbContext())
                    {
                        var entOrder = new OrderMaster
                        {
                            OrderDate = orderMaster.OrderDate,
                            OrderId = newOrderId,
                            PaymentMethodId = orderMaster.PaymentMethodId,
                            PaymentTermId = orderMaster.PaymentTermId,
                            TotalAmout = orderMaster.TotalAmout,
                            DiscountAmount = orderMaster.DiscountAmount,
                            CreateAt = DateTime.Now,
                            CustomerId = orderMaster.CustomerId,
                        };
                        context.OrderMasters.Add(entOrder);
                        context.SaveChanges();

                        foreach (var objorderDetail in orderMaster.OrderDetails)
                        {
                            var newDetails = new OrderDetail
                            {
                                OrderId = entOrder.Id,
                                ItemCode = objorderDetail.ItemCode,
                                ItemPrice = objorderDetail.ItemPrice,
                                Unit = objorderDetail.Unit,
                                Qty = objorderDetail.Qty,
                                CreateAt = DateTime.Now,
                            };
                            context.OrderDetails.Add(newDetails);
                            context.SaveChanges();
                        }

                        foreach (var objpayment in orderMaster.OrderPayments)
                        {
                            var newPayment = new OrderPayment
                            {
                                OrderId = entOrder.Id,
                                PaymentType = objpayment.PaymentType,
                                PaymentTerm = objpayment.PaymentTerm,
                                Amount = objpayment.Amount,
                                CreateAt = DateTime.Now,
                            };
                            context.OrderPayments.Add(newPayment);
                            context.SaveChanges();
                        }
                        foreach (var orderShip in orderMaster.OrderShipments)
                        {
                            var newOrderShipmant = new OrderShipment
                            {
                                OrderId = entOrder.Id,
                                Address1 = orderShip.Address1,
                                Address2 = orderShip.Address2,
                                State = orderShip.State,
                                Contry = orderShip.Contry,
                                PhoneNumber = orderShip.PhoneNumber,
                                Email = orderShip.Email,
                                CreateAt = DateTime.Now,
                            };
                            context.OrderShipments.Add(newOrderShipmant);
                            context.SaveChanges();
                        }
                        addedEntry = entOrder;
                    }
                    scope.Complete();
                }
                return addedEntry;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        internal static async Task<JsonResult> PaymentDetail(paymentDetailsEntry paymentInfo)
        {
            var paymentId = 0;
            try
            {
                if (paymentInfo.OrderId == 0)
                {
                    return new JsonResult(new { message = "Payment order not found." })
                    {
                        StatusCode = StatusCodes.Status400BadRequest // Status code here 
                    };
                }
                using (var scope = new TransactionScope(
                        TransactionScopeOption.Required,
                        new TransactionOptions { IsolationLevel = IsolationLevel.ReadUncommitted }))
                {
                    using (var context = new ErpDbContext())
                    {
                        var newPayment = new OrderPaymentDetail
                        {
                            OrderId = paymentInfo.OrderId,
                            Amount = paymentInfo.Amount,
                            PaymentThrow = paymentInfo.PaymentThrow,
                            CardNumber = paymentInfo.CardNumber,
                            CvcCheck = paymentInfo.CvcCheck,
                            ExpMonth = paymentInfo.ExpMonth,
                            ExpYear = paymentInfo.ExpYear,
                            Funding = paymentInfo.Funding,
                            Last4 = paymentInfo.Last4,
                            EmailId = paymentInfo.EmailId,
                            ClientIp = paymentInfo.ClientIp,
                            TokenValue = paymentInfo.TokenValue,
                            CreateAt = DateTime.Now,
                        };
                        context.OrderPaymentDetails.Add(newPayment);
                        context.SaveChanges();
                        paymentId = newPayment.Id;
                    }
                    scope.Complete();
                }
                return new JsonResult(new { message = "Payment succ." })
                {
                    StatusCode = StatusCodes.Status200OK // Status code here 
                };
            }
            catch (Exception)
            {
                return new JsonResult(new { message = "Payment not succ." })
                {
                    StatusCode = StatusCodes.Status400BadRequest // Status code here 
                };
            }

        }
    }
}
