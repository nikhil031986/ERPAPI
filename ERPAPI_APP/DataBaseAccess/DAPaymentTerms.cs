using ERPAPI_APP.Models;
using Microsoft.EntityFrameworkCore;
using System.Formats.Asn1;

namespace ERPAPI_APP.DataBaseAccess
{
    internal class DAPaymentTerms
    {
        internal static async Task<List<PaymentTerm>> GetPaymentTerms()
            => await UtilObject.erpDbContext.PaymentTerms.ToListAsync();

        internal static async Task InsertPaymentTerm(PaymentTerm paymentTerm)
            => await UtilObject.erpDbContext.PaymentTerms.AddAsync(paymentTerm);

        internal static async Task InsertListOfPaymentTerms(List<PaymentTerm> listOfPaymentTerms)
            => await UtilObject.erpDbContext.PaymentTerms.AddRangeAsync(listOfPaymentTerms);

        internal static async Task UpdatePaymentTerm(PaymentTerm paymentTerm)
            => UtilObject.erpDbContext.PaymentTerms.Update(paymentTerm);

        internal static async Task UpdateListOdPaymentTerms(List<PaymentTerm> listOfPaymentTerms)
            =>  UtilObject.erpDbContext.PaymentTerms.UpdateRange(listOfPaymentTerms);
    }
}
