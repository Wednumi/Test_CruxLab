using System.Runtime.CompilerServices;

namespace Validation.Models
{
    public class AmountRange
    {
        public int Left { get; set; }

        public int Right { get; set; }

        public AmountRange(int left, int right)
        {
            Left = left;
            Right = right;
        }

        public static AmountRange Parse(string value)
        {
            var numbers = value.Split('-');

            if (numbers.Length == 2)
            {
                return new AmountRange(int.Parse(numbers[0]), int.Parse(numbers[1]));
            }

            if (numbers.Length == 1)
            {
                return new AmountRange(int.Parse(numbers[0]), int.Parse(numbers[0]));
            }

            throw new FormatException();
        }

        public bool IsValid()
        {
            return Left <= Right;
        }

        public bool InRange(int number)
        {
            return Left <= number && number <= Right;
        }
    }
}
