namespace Sequence
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split(' ');
            int firstNumber = int.Parse(numbers[0]);
            int nthNumber = int.Parse(numbers[1]);
            Console.WriteLine(findNumber(firstNumber, nthNumber));

        }
        static int findNumber(int firstNumber, int nthNumber)
        {
            if (nthNumber == 1)
            {
                return firstNumber;
            }
            else if (nthNumber == 2)
            {
                return firstNumber + 1;
            }
            else if (nthNumber == 3)
            {
                return firstNumber * 2 + 1;
            }
            else if (nthNumber == 4)
            {
                return firstNumber + 2;
            }
            return findNumber(firstNumber+1, nthNumber - 3);
        }
    }
}