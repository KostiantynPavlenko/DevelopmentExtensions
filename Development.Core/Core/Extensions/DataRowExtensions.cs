using System.Data;

namespace Extensions.Web.Core.Extensions
{
    public static class DataRowExtensions
    {
        public static T GetValue<T>(this DataRow row, string columnName)
        {
            return row.Table.Columns.Contains(columnName) ? row[columnName].ConvertTo<T>() : default;
        }
    }
}