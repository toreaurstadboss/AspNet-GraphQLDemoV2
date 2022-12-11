using HotChocolate.Data.Filters;
using HotChocolate.Data.Filters.Expressions;
using HotChocolate.Language;
using System.Linq.Expressions;
using System.Reflection;

namespace AspNetGraphQLDemoV2.Server
{
    public class QueryableStringInvariantContainsHandler : QueryableStringOperationHandler
    {
        private static readonly MethodInfo _contains = typeof(string).GetMethod(nameof(string.Contains), new[] { typeof(string) })!;

        public QueryableStringInvariantContainsHandler(InputParser inputParser) : base(inputParser)
        {
        }

        protected override int Operation => DefaultFilterOperations.Contains;
        public override Expression HandleOperation(QueryableFilterContext context, IFilterOperationField field, 
            IValueNode value, object? parsedValue)
        {
            Expression property = context.GetInstance();
            if (parsedValue is string str)
            {
                var toLower = Expression.Call(property, typeof(string).GetMethod("ToLower", Type.EmptyTypes)!); //get the ToLower method of string class via reflection. The Type.EmptyTypes will retrieve the method overload of ToLower which accept no arguments.
                var finalExpression = Expression.Call(toLower, _contains, Expression.Constant(str.ToLower()));
                return finalExpression;

            }
            throw new InvalidOperationException();
        }
    }
}