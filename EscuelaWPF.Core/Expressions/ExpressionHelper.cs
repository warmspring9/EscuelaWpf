using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EscuelaWPF.Core
{
    /// <summary>
    /// Helper for expresisons
    /// </summary>
    public static class ExpressionHelper
    {
        /// <summary>
        /// Compiles a lambda expression and gets the functions return value
        /// </summary>
        /// <typeparam name="T">type of return value</typeparam>
        /// <param name="lambda">The function</param>
        /// <returns></returns>
        public static T GetPropertyValue<T>(this Expression<Func<T>> lambda)
        {
            return lambda.Compile().Invoke();
        }
        /// <summary>
        /// Sets the underlying properties value to the given value from an expression that contains the property
        /// </summary>
        /// <typeparam name="T">The type </typeparam>
        /// <param name="lambda">The expression</param>
        /// <param name="value">The value to set the property to</param>
        public static void SetPropertyValue<T>(this Expression<Func<T>> lambda, T value)
        {
            //Converts a lambda () => Some.Property to some.Property
            var expression = lambda.Body as MemberExpression;

            //Gets the property information for set
            var propertyInfo = (PropertyInfo)expression.Member;
            var target = Expression.Lambda(expression.Expression).Compile().DynamicInvoke();

            propertyInfo.SetValue(target, value);
        }
    }
}
