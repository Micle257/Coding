using System.Collections.Generic;
using System.Text;

namespace DynamicMenu.DataLayer.Extensions
{
    using System.Data;
    using System.Data.Common;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Contains extension methods for <see cref="DbContext" />.
    /// </summary>
    public static class DbContextExtensions
    {
        public static IList<T> ExecuteStoredProcedure<T>(this DbContext context, string spName)
            where T : new()
        {
            using (var reader = context.InvokesStoredProcedure(spName).ExecuteReader())
            {
                return reader.MapModel<T>();
            }
        }

       static DbCommand InvokesStoredProcedure(this DbContext context, string spName)
       {
           var cmd = context.Database.GetDbConnection().CreateCommand();
           cmd.CommandText = spName;
            cmd.CommandType = CommandType.StoredProcedure;

            context
                .Database.OpenConnection();
           return cmd;
       }
    }
}
