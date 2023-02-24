using Validation.Models;
using Validation;

namespace Tests.Tests
{
    public class ValidationRequestParsing
    {
        [Fact]
        public void Parse_with_alphabetic_symbol()
        {
            var str = "a 1-5: abcdj";
            var expected = new ValidationRequest(new Requirement('a', new AmountRange(1, 5)), "abcdj");

            var result = ValidationRequest.Parse(str);

            ModelAsserter.ValidationRequestEquals(expected, result);
        }

        [Fact]
        public void Parse_with_non_alphabetic_symbol()
        {
            var str = "! 5-10: abcd!6.-+%2j";
            var expected = new ValidationRequest(new Requirement('!', new AmountRange(5, 10)), "abcd!6.-+%2j");

            var result = ValidationRequest.Parse(str);

            ModelAsserter.ValidationRequestEquals(expected, result);
        }

        [Fact]
        public void Parse_with_one_point_range()
        {
            var str = "8 2: ag8asgsa8";
            var expected = new ValidationRequest(new Requirement('8', new AmountRange(2, 2)), "ag8asgsa8");

            var result = ValidationRequest.Parse(str);

            ModelAsserter.ValidationRequestEquals(expected, result);
        }
    }
}
