// -----------------------------------------------------------------------
//  <copyright file="DbContextExtensions.cs">
//   Copyright (c) Michal Pokorný. All Rights Reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace DynamicMenu.DataLayer.Extensions
{
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Common;
    using Microsoft.EntityFrameworkCore;

    /// <summary> Contains extension methods for <see cref="DbContext" />. </summary>
    public static class DbContextExtensions
    {
        /// <summary>
        /// Executes the named stored procedure for this <see cref="DbContext"/>.
        /// </summary>
        /// <typeparam name="T">The type of the entity.</typeparam>
        /// <param name="context">The context.</param>
        /// <param name="spName">Name of the storage procedure.</param>
        /// <returns>
        /// An <see cref="IList{T}"/> of entities.
        /// </returns>
        public static IList<T> ExecuteStoredProcedure<T>(this DbContext context, string spName)
            where T : new()
        {
            using (var reader = context.ExecuteStoredProcedureImpl(spName).ExecuteReader())
            {
                return reader.MapModel<T>();
            }
        }

        /// <summary>
        /// Executes the named stored procedure and returns <see cref="DbCommand"/> reader.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="spName">Name of the storage procedure.</param>
        /// <returns>
        /// A <see cref="DbCommand"/> reader.
        /// </returns>
        static DbCommand ExecuteStoredProcedureImpl(this DbContext context, string spName)
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