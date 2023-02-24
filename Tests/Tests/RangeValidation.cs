using Validation.Models;

namespace Tests.Tests
{    
    public class RangeValidation
    {
        [Fact]
        public void Range_validate_valid_range()
        {
            var sut = new AmountRange(2, 5);

            var result = sut.IsValid();

            Assert.True(result);
        }

        [Fact]
        public void Range_catch_invalid_range()
        {
            var sut = new AmountRange(10, 5);

            var result = sut.IsValid();

            Assert.False(result);
        }
    }
}
