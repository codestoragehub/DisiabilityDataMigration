using System;

namespace DisabilityInPortal.Infrastructure.ThrowException
{
    public static class Extensions
    {
        public static void IfNull<T>(this IThrow obj, T value, string propertyName)
        {
            if (value == null)
                throw new ArgumentNullException(propertyName);
        }

        public static void IfNull<T>(
            this IThrow obj, T value, string propertyName, string message)
        {
            if (value == null)
                throw new ArgumentNullException(propertyName + " is NULL. " + message);
        }

        public static void IfNotNull<T>(this IThrow obj, T value, string message)
        {
            if (value != null)
                throw new ArgumentException(message);
        }

        public static void IfNullOrWhiteSpace(this IThrow obj, string value, string propertyName)
        {
            Throw.Exception.IfNull(value, propertyName);

            if (string.IsNullOrEmpty(value))
                throw new ArgumentException("Paramater " + propertyName + " cannot be empty.");
        }

        public static void IfNotEqual<T>(
            this IThrow obj, T valueOne, T valueTwo, string property) where T : IEquatable<T>
        {
            if (!valueOne.Equals(valueTwo))
                throw new ArgumentException("Supplied " + property + " values are not equal.");
        }

        public static void IfFalse(this IThrow obj, bool value, string message)
        {
            if (!value)
                throw new ArgumentException(message);
        }

        public static void IfTrue(this IThrow obj, bool value, string message)
        {
            if (value)
                throw new ArgumentException(message);
        }

        public static void IfZero(this IThrow obj, int value, string property)
        {
            if (value == 0)
                throw new ArgumentException("This Property " + property + " cannot be Zero");
        }
    }
}