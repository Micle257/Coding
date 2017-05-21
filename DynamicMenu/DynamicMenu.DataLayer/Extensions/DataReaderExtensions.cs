// -----------------------------------------------------------------------
//  <copyright file="DataReaderExtensions.cs">
//   Copyright (c) Michal Pokorný. All Rights Reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace DynamicMenu.DataLayer.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Reflection;

    /// <summary> Contains extension methods for <see cref="IDataReader" />. </summary>
    public static class DataReaderExtensions
    {
        internal static IList<T> MapModel<T>(this IDataReader reader)
            where T : new()
        {
            var result = new List<T>();
            var properties = reader.GetColumns<T>();
            while (reader.Read())
            {
                var row = new T();
                for (var i = 0; i < reader.FieldCount; i++)
                {
                    var name = reader.GetName(i);
                    if (properties.TryGetValue(name, out PropertyInfo property))
                    {
                        var value = reader.GetValue(i);
                        property.SetValue(row, value == DBNull.Value ? null : value);
                    }
                }
                result.Add(row);
            }
            return result;
        }

        static IDictionary<string, PropertyInfo> GetColumns<T>(this IDataReader reader)
        {
            var result = new Dictionary<string, PropertyInfo>();
            var type = typeof(T);
            for (var i = 0; i < reader.FieldCount; i++)
            {
                var name = reader.GetName(i);
                var fixedName = name.Replace("-", string.Empty).Replace("_", string.Empty);
                var property = type.GetProperty(fixedName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
                if (property != null)
                    result[name] = property;
            }
            return result;
        }
    }
}