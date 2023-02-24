namespace Validation.Models
{
    public class Requirement
    {
        public char Symbol { get; set; }

        public AmountRange Range { get; set; }

        public Requirement(char symbol, AmountRange range)
        {
            Symbol = symbol;
            Range = range;
        }
    }
}
