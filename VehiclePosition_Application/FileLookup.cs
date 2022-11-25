using System.Diagnostics;

namespace VehiclePosition_Application
{
    internal class FileLookup
    {
        internal static void GetClosestDistance()
        {
            Stopwatch watch = Stopwatch.StartNew();

            List<VehicleDetails> vehicles = FileReader.GetFileData();

            //Looping throught static positions by selecting the vehicles in the data file with the shortest distance between the vehicle and the static position
            List<VehicleDetails> vehiclePositionList1 = GetStaticPositions().Select(p => vehicles.Select(cv => new { Point = cv, Distance2 = DataHelper.DistanceTo(p.Key, p.Value, cv.Latitude, cv.Longitude) }).Aggregate((p1, p2) => p1.Distance2 < p2.Distance2 ? p1 : p2).Point).ToList();

            //Display each of the vehicles closest to the static position
            for (int i = 0; i < vehiclePositionList1.Count; i++)
            {
                Console.WriteLine($"Nearest vehicle position {i+1}");
                Console.WriteLine($"Latitude: {vehiclePositionList1[i].Latitude}");
                Console.WriteLine($"Longitude: {vehiclePositionList1[i].Longitude}");
                Console.WriteLine("");
            }

            watch.Stop();
            Console.WriteLine(" ");
            Console.WriteLine($"Execution time: {watch.ElapsedMilliseconds} ms");
        }

        static Dictionary<float,float> GetStaticPositions()
        {
            Dictionary<float, float> positionList = new Dictionary<float, float>();

            positionList.Add(34.544909f, -102.100843f);
            positionList.Add(32.345544f, -99.123124f);
            positionList.Add(33.234235f, -100.214124f);
            positionList.Add(35.195739f, -95.348899f);
            positionList.Add(31.895839f, -97.789573f);
            positionList.Add(32.895839f, -101.789573f);
            positionList.Add(34.115839f, -100.225732f);
            positionList.Add(32.335839f, -99.992232f);
            positionList.Add(33.535339f, -94.792232f);
            positionList.Add(32.234235f, -100.222222f);

            return positionList;
        }
    }
}
