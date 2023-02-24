using Validation.Models;

namespace Tests
{
    public class ModelAsserter
    {
        public static void ValidationRequestEquals(ValidationRequest req1, ValidationRequest req2)
        {
            RequirementEqual(req1.Requirement, req2.Requirement);
            Assert.Equal(req1.Password, req2.Password);
        }

        public static void RequirementEqual(Requirement req1, Requirement req2)
        {
            RangeEqual(req1.Range, req2.Range);
            Assert.Equal(req1.Symbol, req2.Symbol);
        }

        public static void RangeEqual(AmountRange range1, AmountRange range2)
        {
            Assert.Equal(range1.Left, range2.Left);
            Assert.Equal(range1.Right, range2.Right);
        }
    }
}
