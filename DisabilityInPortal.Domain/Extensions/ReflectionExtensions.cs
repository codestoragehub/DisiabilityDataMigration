using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace DisabilityInPortal.Domain.Extensions
{
    public static class ReflectionExtensions
    {
        public static T GetAttribute<T>(this MemberInfo member, bool isRequired) where T : Attribute
        {
            var attribute = member.GetCustomAttributes(typeof(T), false).SingleOrDefault();

            if (attribute == null && isRequired)
                throw new ArgumentException(
                    string.Format(
                        CultureInfo.InvariantCulture,
                        "The {0} attribute must be defined on member {1}",
                        typeof(T).Name,
                        member.Name));

            return (T)attribute;
        }

        public static string GetDisplayName<T>(Expression<Func<T, object>> propertyExpression)
        {
            var memberInfo = GetPropertyInformation(propertyExpression.Body);
            if (memberInfo == null)
                throw new ArgumentException(
                    "No property reference expression was found.",
                    nameof(propertyExpression));

            var attr = memberInfo.GetAttribute<DisplayNameAttribute>(false);

            return attr == null
                ? memberInfo.Name
                : attr.DisplayName;
        }

        public static MemberInfo GetPropertyInformation(Expression propertyExpression)
        {
            Debug.Assert(propertyExpression != null, "propertyExpression != null");
            var memberExpr = propertyExpression as MemberExpression;
            if (memberExpr == null)
                if (propertyExpression is UnaryExpression { NodeType: ExpressionType.Convert } unaryExpr)
                    memberExpr = unaryExpr.Operand as MemberExpression;

            if (memberExpr != null && memberExpr.Member.MemberType == MemberTypes.Property) return memberExpr.Member;

            return null;
        }
    }
}