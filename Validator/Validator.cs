using Validation.Models;

namespace Validation
{
    public static class Validator
    {
        public static bool IsValid(ValidationRequest validationRequest)
        {
            if (validationRequest.Requirement.Range.IsValid() is false)
            {
                return false;
            }

            var symbolCount = validationRequest.Password
                .Where(c => c == validationRequest.Requirement.Symbol)
                .Count();

            return validationRequest.Requirement.Range.InRange(symbolCount);
        }
    }
}
