using System;
using System.Diagnostics;

namespace Bubble.Library.Extension
{
    [DebuggerStepThrough]
    public static class CheckHelper
    {
        public static T NotNull<T>(T value, string parameterName) => (object)value is not null ? value : throw new ArgumentNullException(nameof(parameterName));

        public static T NotNull<T>(T value, string parameterName, string message) => (object)value is not null ? value : throw new ArgumentNullException(nameof(parameterName), message);

        public static string NotNull(string value, string parameterName, int maxLength = int.MaxValue, int minLength = 0)
        {
            if (value is null)
            {
                throw new ArgumentNullException(parameterName, parameterName + " can not be null!");
            }
            if (value.Length > maxLength)
            {
                throw new ArgumentException($"{parameterName} must be lower than or equal to {maxLength}!", parameterName);
            }
            if (minLength > 0 && value.Length < maxLength)
            {
                throw new ArgumentException($"{parameterName} must be greater than or equal to {minLength}!", parameterName);
            }
            return value;
        }

        public static string NotNullOrWhiteSpace(string value, string parameterName, int maxLength = int.MaxValue, int minLength = 0)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException(parameterName, parameterName + " can not be null, empty or white space!");
            }
            if (value.Length > maxLength)
            {
                throw new ArgumentException($"{parameterName} must be lower than or equal to {maxLength}!", parameterName);
            }
            if (minLength > 0 && value.Length < maxLength)
            {
                throw new ArgumentException($"{parameterName} must be greater than or equal to {minLength}!", parameterName);
            }
            return value;
        }

        public static string NotNullOrEmpty(string value, string parameterName, int maxLength = int.MaxValue, int minLength = 0)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException(parameterName, parameterName + " can not be null or empty!");
            }
            if (value.Length > maxLength)
            {
                throw new ArgumentException($"{parameterName} must be lower than or equal to {maxLength}!", parameterName);
            }
            if (minLength > 0 && value.Length < maxLength)
            {
                throw new ArgumentException($"{parameterName} must be greater than or equal to {minLength}!", parameterName);
            }
            return value;
        }
    }
}
