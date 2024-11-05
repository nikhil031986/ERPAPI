using ERPAPI_APP.Models;
using Microsoft.EntityFrameworkCore;
using System.Formats.Asn1;

namespace ERPAPI_APP.DataBaseAccess
{
    internal class DAPaymentTerms
    {
        private static readonly ErpDbContext erpDbContext = new ErpDbContext();

        internal static async Task<List<PaymentTerm>> GetPaymentTerms()
            => await erpDbContext.PaymentTerms.ToListAsync();
            
        internal static async Task InsertPaymentTerm(PaymentTerm paymentTerm)
            => await erpDbContext.PaymentTerms.AddAsync(paymentTerm);

        internal static async Task InsertListOfPaymentTerms(List<PaymentTerm> listOfPaymentTerms)
            => await erpDbContext.PaymentTerms.AddRangeAsync(listOfPaymentTerms);

        internal static async Task UpdatePaymentTerm(PaymentTerm paymentTerm)
            => erpDbContext.PaymentTerms.Update(paymentTerm);

        internal static async Task UpdateListOdPaymentTerms(List<PaymentTerm> listOfPaymentTerms)
            =>  erpDbContext.PaymentTerms.UpdateRange(listOfPaymentTerms);
    }
}
