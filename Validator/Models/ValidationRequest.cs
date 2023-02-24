using System.Text.RegularExpressions;

namespace Validation.Models
{
    public class ValidationRequest
    {
        public Requirement Requirement { get; set; }

        public string Password { get; set; }

        public ValidationRequest(Requirement requirement, string password)
        {
            Requirement = requirement;
            Password = password;
        }

        public static ValidationRequest Parse(string value)
        {
            var filter = new Regex(@"^(?<symbol>.) (?<range>\d+-?\d*): (?<password>.*)$");
            var matchCollection = filter.Matches(value);

            var range = AmountRange.Parse(matchCollection.First().Groups["range"].Value);
            var symbol = matchCollection.First().Groups["symbol"].Value.First();
            var password = matchCollection.First().Groups["password"].Value;

            return new ValidationRequest(new Requirement(symbol, range), password);
        }
    }
}
