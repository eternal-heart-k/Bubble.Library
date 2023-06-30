using System;
using System.Diagnostics;

namespace Bubble.Library.Extension
{
    /// <summary>
    /// 检查相关
    /// </summary>
    [DebuggerStepThrough]
    public static class CheckHelper
    {
        /// <summary>
        /// 检查是否为空，空则报错
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="parameterName"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static T NotNull<T>(T value, string parameterName) => (object)value is not null ? value : throw new ArgumentNullException(nameof(parameterName));

        /// <summary>
        /// 检查是否为空，空则报错
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="parameterName"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static T NotNull<T>(T value, string parameterName, string message) => (object)value is not null ? value : throw new ArgumentNullException(nameof(parameterName), message);

        /// <summary>
        /// 空、长度过长、长度过短报错
        /// </summary>
        /// <param name="value"></param>
        /// <param name="parameterName"></param>
        /// <param name="maxLength"></param>
        /// <param name="minLength"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
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

        /// <summary>
        /// 空、空格、长度过长、长度过短报错
        /// </summary>
        /// <param name="value"></param>
        /// <param name="parameterName"></param>
        /// <param name="maxLength"></param>
        /// <param name="minLength"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
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

        /// <summary>
        /// 空、长度过长、长度过短报错
        /// </summary>
        /// <param name="value"></param>
        /// <param name="parameterName"></param>
        /// <param name="maxLength"></param>
        /// <param name="minLength"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
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
