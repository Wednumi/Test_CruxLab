using Validation.Models;

namespace Tests.Tests
{
    public class AmountRangeParsing
    {
        [Fact]
        public void Parse_proper_string()
        {
            var properString = "1-5";
            var expectedRange = new AmountRange(1, 5);

            var parseResult = AmountRange.Parse(properString);

            ModelAsserter.RangeEqual(parseResult, expectedRange);
        }

        [Fact]
        public void Parse_one_point_range_properly()
        {
            var onePointRange = "1";
            var expectedRange = new AmountRange(1, 1);

            var parseResult = AmountRange.Parse(onePointRange);

            ModelAsserter.RangeEqual(parseResult, expectedRange);
        }

        [Fact]
        public void Parse_throw_exception_to_improper_format()
        {
            var improperFormat = "2:3";

            Assert.Throws<FormatException>(() => AmountRange.Parse(improperFormat));
        }

        [Fact]
        public void Parse_throw_exception_to_improper_value()
        {
            var improperValue = "2.1-3";

            Assert.Throws<FormatException>(() => AmountRange.Parse(improperValue));
        }
    }
}
