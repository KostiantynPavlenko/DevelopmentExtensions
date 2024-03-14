using System;
using System.Collections.Generic;
using System.Data;

namespace Extensions.Web.Core.Extensions
{
    public static class DataTableExtensions
    {
        public static ICollection<T> ToCollection<T>(this DataTable dataTable, Func<DataRow, T> parseMethod)
        {
            var resultsCollection = new List<T>();

            for (int index = 0; index < dataTable.Rows.Count; index++)
            {
                var row = dataTable.Rows[index];
                resultsCollection.Add(parseMethod(row));
            }

            return resultsCollection;
        }

        public static ICollection<DataRow> ToCollection(this DataTable dataTable)
        {
            var resultsCollection = new List<DataRow>();

            for (int index = 0; index < dataTable.Rows.Count; index++)
            {
                var row = dataTable.Rows[index];
                resultsCollection.Add(row);
            }

            return resultsCollection.ToArray();
        }
    }
}
