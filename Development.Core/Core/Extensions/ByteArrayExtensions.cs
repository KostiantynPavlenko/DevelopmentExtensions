using System.Text;

namespace Extensions.Web.Core.Extensions
{
    public static class ByteArrayExtensions
    {
        public static string GetString(this byte[] array)
        {
            var sb = new StringBuilder();
            foreach (var b in array)
            {
                sb.Append(b.ToString("X2"));
            }

            return sb.ToString();
        }
    }
}
