using System.ComponentModel.DataAnnotations;

namespace SurveyBasketV9.Api.Validations
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class LengthCustomAttribute : ValidationAttribute
    {
        readonly int _minLength;
        readonly int _maxLength;

        public LengthCustomAttribute(int minLength, int maxLength)
        {
            _minLength = minLength;
            _maxLength = maxLength;
        }

        public override bool IsValid(object? value)
        {
            bool result = false;

            if (value is string s)
            {
                result = s.Length > _minLength && s.Length < _maxLength;
            }

            return result;
        }

        public override string FormatErrorMessage(string name)
        {
            return $"Min length {name} must be {_maxLength} and the max length must be {_maxLength}.";
        }
    }
}
