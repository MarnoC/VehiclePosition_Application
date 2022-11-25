using System.Text;

namespace VehiclePosition_Application
{
    public class DataHelper
    {
        public static string ConvertAsciiToString(byte[] buffer, int index)
        {
            //Get the lengths of ASCII byte array
            int count = Array.IndexOf<byte>(buffer, 0, index);
            if (count < 0) count = buffer.Length;
            //Decode ASCII byte array to string
            string asciiString = Encoding.ASCII.GetString(buffer, index, count - index);
            //Add number of ASCII bytes to index. Add plus 1 for while space
            FileReader.index = count + 1;
            return asciiString;
        }

        public static DateTime ConvertByteArrayToDateTime(byte[] b, int index)
        {
            DateTime dt = new DateTime();

            try
            {
                ulong posix = BitConverter.ToUInt64(b, index);

                // POSIX is seconds since 1 Jan 1970
                dt = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);

                // add POSIX seconds
                dt = dt.AddSeconds((double)posix);

                //posix is 8 byte uLong values. Add 8 to index.
                FileReader.index += 8;
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR: Exception received during ConvertPOSIX: " + e.Message);
            }

            return dt;
        }

        public static int ConvertByteArrayToInt32(byte[] b, int index)
        {
            //float return type is 4 byte floating-point values. Add 4 to index.
            FileReader.index += 4;
            return BitConverter.ToInt32(b, index);
        }

        public static float ConvertByteArrayToFloat(byte[] b, int index)
        {
            //float return type is 4 byte floating-point values. Add 4 to index.
            FileReader.index += 4;
            return BitConverter.ToSingle(b, index);
        }

        private static double Pow2(double x)
        {
            return x * x;
        }

        public static double DistanceTo(float p1Latitude, float p1longitude, float p2Latitude, float p2longitude)
        {
            return Pow2(p2Latitude - p1Latitude) + Pow2(p2longitude - p1longitude);
        }
    }
}
