namespace IUrlRegistryRecipe.Web.Models
{
    using System;
    using System.Linq.Expressions;
    using System.Text;

    public class DynamicFuncList<TValue> : ValuePairList<string, Func<TValue, string>>
    {
        public void Add(Expression<Func<TValue, string>> expression)
        {
            MethodCallExpression outermostExpression = expression.Body as MethodCallExpression;
            string methodSignature = outermostExpression.ToString();

            if (outermostExpression.Method.IsGenericMethod)
            {
                StringBuilder genericList = new StringBuilder();

                genericList.Append("<");

                foreach (var param in outermostExpression.Method.GetGenericArguments())
                {
                    genericList.AppendFormat("{0}{1}", genericList.Length == 0 ? ", " : String.Empty, param.Name);
                }

                genericList.Append(">");

                methodSignature = methodSignature.Insert(methodSignature.IndexOf("("), genericList.ToString()).ToString();
            }

            this.Add(methodSignature, expression.Compile());
        }
    }
}