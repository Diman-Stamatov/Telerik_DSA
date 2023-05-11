namespace InflightEntertainment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int flighLength = 328;
            int[] movies = new int[] { 123, 111, 94, 99, 230, 150, 128, 200 };

            Console.WriteLine(FitTwoMovies(flighLength, movies));
        }
        static bool FitTwoMovies(int flightLength, int[] movies)
        {
            var hashset = new HashSet<int>(movies);
            foreach (var item in hashset)
            {
                int secondRuntime = flightLength - item;
                if (hashset.Contains(secondRuntime))
                {
                    return true;
                }
                
            }
            return false;
        }
    }
}