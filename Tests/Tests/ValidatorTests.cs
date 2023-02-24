using Validation;
using Validation.Models;

namespace Tests.Tests
{
    public class ValidatorTests
    {
        [Fact]
        public void Validator_validate_proper_request()
        {
            var properRequest = new ValidationRequest(new Requirement('n', new AmountRange(2, 4)), "gscnwsnpeon");

            var result = Validator.IsValid(properRequest);

            Assert.True(result);
        }

        [Fact]
        public void Validator_catch_invalid_range()
        {
            var withInvalidRange = new ValidationRequest(new Requirement('n', new AmountRange(5, 4)), "gscnwsnpeon");

            var result = Validator.IsValid(withInvalidRange);

            Assert.False(result);
        }

        [Fact]
        public void Validator_validate_with_one_point_range()
        {
            var properRequest = new ValidationRequest(new Requirement('!', new AmountRange(1, 1)), "!");

            var result = Validator.IsValid(properRequest);

            Assert.True(result);
        }

        [Fact]
        public void Validator_do_not_validate_improper_request()
        {
            var improperRequest = new ValidationRequest(new Requirement('a', new AmountRange(2, 3)), "aaaafff");

            var result = Validator.IsValid(improperRequest);

            Assert.False(result);
        }
    }
}
