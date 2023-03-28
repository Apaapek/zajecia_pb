using FizzBuzzWeb.Interfaces;
using System.Text;

namespace FizzBuzzWeb.App
{
    public class FizzBuzzMessageProvider : IFizzBuzzMessageProvider
    {
        public FizzBuzzMessageProvider()
        {
        }
        public string GetFizzBuzzMessage(int number)
        {
            var sb = new StringBuilder();

            if (number % 3 == 0)
            {
                sb.Append("Fizz");
            }
            if (number % 5 == 0)
            {
                sb.Append("Buzz");
            }

            if (sb.Length == 0)
            {
                return $"Liczba {number} nie spełnia kryteriów FizzBuzz";
            }
            else
            {
                return sb.ToString();
            }

        }
    }
}
