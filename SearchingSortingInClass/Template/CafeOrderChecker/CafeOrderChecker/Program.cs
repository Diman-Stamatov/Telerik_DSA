namespace CafeOrderChecker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var takeout = new int[] { 1, 3, 5 };
            var dineIn = new int[] { 2, 4, 6 };
            var checkout = new int[] { 1, 2, 3, 5, 4, 6 };
            Console.WriteLine(ValidOrders(takeout, dineIn, checkout));
        }
        static bool ValidOrders(int[] takeout, int[] dineIn, int[] checkout)
        {
            var combinedOrders = new int[takeout.Length + dineIn.Length];
            Array.Copy(takeout, combinedOrders, takeout.Length);
            Array.Copy(dineIn, 0, combinedOrders, takeout.Length, dineIn.Length);
            Array.Sort(combinedOrders);
            for (int index = 0; index < takeout.Length; index++)
            {
                if (combinedOrders[index] != checkout[index])
                {
                    return false;
                }
            }
            return true;
        }
    }
}