using System.IO;

namespace KesselRun.HomeLibrary.EF.Tests.Infrastructure
{
    public class Utilities
    {
        public static byte[] ReadFully(Stream input)
        {
            byte[] buffer = new byte[input.Length];
            input.Read(buffer, 0, buffer.Length);
            return buffer;

        }

    }
}
