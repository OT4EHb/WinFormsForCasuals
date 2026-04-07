using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace App2
{
    internal class TableUtils
    {
        public static PropertyInfo? getPrimary<T>()
        {
            foreach (var i in typeof(T).GetProperties())
            {
                if (i.GetCustomAttribute<IsPrimaryKeyAttribute>() != null)
                {
                    return i;
                }
            }
            return null;
        }

        public static PropertyInfo? getForeign<D, T>()
        {
            var tableName = typeof(D).GetCustomAttribute<TableNameAttribute>()!.Name;
            foreach (var i in typeof(T).GetProperties())
            {
                var foreign = i.GetCustomAttribute<ForeignKeyAttribute>();
                if (foreign != null)
                {
                    if (foreign.ReferenceTable == tableName)
                    {
                        return i;
                    }
                }
            }
            return null;
        }
    }
}
