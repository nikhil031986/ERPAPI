using ERPAPI_APP.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Transactions;

namespace ERPAPI_APP.DataBaseAccess
{
    internal static class DaCommonDBFunction
    {

        internal static List<T> GetData<T>(string tableName, Expression<Func<T, bool>> predicate) where T : class
        {
            // Get the DbSet for the specified table name
            using (var scope = new TransactionScope(
                        TransactionScopeOption.Required,
                        new TransactionOptions { IsolationLevel = IsolationLevel.ReadUncommitted }))
            {
                using (var context = new ErpDbContext())
                {
                    var dbSet = context.GetType().GetProperty(tableName)?.GetValue(context, null) as DbSet<T>;

                    if (dbSet == null)
                    {
                        throw new ArgumentException($"Table '{tableName}' not found in the context.");
                    }

                    // Apply the where condition and return the results
                    return dbSet.Where(predicate).ToList();
                }
            }

        }
    }
}
