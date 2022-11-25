namespace VehiclePosition_Application
{
    internal class FileReader
    {
        public static int index = 0;
        internal static byte[] ReadDataFile()
        {
            string fileName = "VehiclePositions.dat";
            //Get the file path to the compiled directory + Data\VehiclePositions.dat 
            string path = Path.Combine(Environment.CurrentDirectory, @"Data\", fileName);

            //Check if file exists 
            if (File.Exists(path))
            {
                return File.ReadAllBytes(path);
            }
            else
            {
                Console.WriteLine("File does not exist at path: " + path);
                return null;
            }
        }

        internal static List<VehicleDetails> GetFileData()
        {
            List<VehicleDetails> vehicles = new List<VehicleDetails>();

            byte[] data = ReadDataFile();

            //Looping through byte array. Convert byte array values and map to appropriate properties in vehicle list. 
            while (index < data.Length)
            {
                vehicles.Add(new VehicleDetails()
                {
                    PositionId = DataHelper.ConvertByteArrayToInt32(data, index),
                    VehicleRegistration = DataHelper.ConvertAsciiToString(data, index),
                    Latitude = DataHelper.ConvertByteArrayToFloat(data, index),
                    Longitude = DataHelper.ConvertByteArrayToFloat(data, index),
                    RecordedTimeUTC = DataHelper.ConvertByteArrayToDateTime(data, index),
                });
            }

            return vehicles;
        }
    }
}
