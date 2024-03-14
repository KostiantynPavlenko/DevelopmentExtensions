using System.IO;

namespace Extensions.Web.Core.Extensions
{
    public static class StreamExtensions
    {
        public static byte[] ToBytes(this Stream input)
        {
            byte[] result;
            var buffer = new byte[16 * 1024];

            using (var ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                result = ms.ToArray();
            }

            return result;
        }
    }
}
