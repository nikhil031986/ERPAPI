using ERPAPI_APP.JSONDataMigration;
using ERPAPI_APP.Models;
using Microsoft.EntityFrameworkCore;
using System.Formats.Asn1;

namespace ERPAPI_APP.DataBaseAccess
{
    internal class DAContact
    {
        private static readonly ErpDbContext erpDbContext = new ErpDbContext();
        internal static async Task<List<ContactDetails>> Contacts()
            => await erpDbContext.ContactMasters
                .Join(erpDbContext.CustomerMasters, p => p.CustomerId, pc => pc.CustomerId, (p, pc) => new { p, pc })
                .Select(m => new ContactDetails
                {
                    contactMaster = m.p,
                    customer = m.pc
                }).ToListAsync();

       

        internal static async Task<ContactMaster> CreateContact(SingUp singUp,int customerId)
        {
            try
            {
                var NewContact = new ContactMaster
                {
                    Slug = singUp.FirstName + " " + singUp.LastName,
                    FirstName = singUp.FirstName,
                    LastName = singUp.LastName,
                    CustomerId = customerId,
                    Phone = singUp.Phone,
                    ContactTranId = 0,
                    PhoneExtension = string.Empty,
                    Titled = string.Empty,
                    Name = singUp.FirstName + " " + singUp.LastName,
                    Email = singUp.emailId,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                };
                
                await erpDbContext.ContactMasters.AddAsync(NewContact);
                await erpDbContext.SaveChangesAsync();
                return NewContact;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
