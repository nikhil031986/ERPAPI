using ERPAPI_APP.Models;
using System.Reflection;

namespace ERPAPI_APP.DataBaseAccess
{
    internal static class DALogDetails
    {
        internal static async Task InsertLog(DbLog dbLog)
        {
            if(dbLog.ErrorMsg == null) { dbLog.ErrorMsg = string.Empty; }   
            if(dbLog.ErrorDateTime == null) { dbLog.ErrorDateTime = DateTime.Now; }
            if(dbLog.ResponseDate == null) { dbLog.ResponseDate = DateTime.Now; };
            if(dbLog.ResponseValue == null) { dbLog.ResponseValue = string.Empty; }
            if(dbLog.RequestApi == null) { dbLog.RequestApi = string.Empty; };
            if (dbLog.RequestDate == null) { dbLog.RequestDate = DateTime.Now;}
            if (dbLog.LogDate == null) { dbLog.LogDate = DateTime.Now;}
            UtilObject.erpDbContext.DbLogs.Add(dbLog);
            UtilObject.erpDbContext.SaveChanges();
        }
    }
}
