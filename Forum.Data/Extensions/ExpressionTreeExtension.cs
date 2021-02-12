using Forum.Data.Entities;
using Forum.Models.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace Forum.Data.Extensions
{
    public static class ExpressionTreeExtension
    {
        public static IQueryable<Post> DynamicWhere<T>(this IQueryable<Post> source,BaseFilterModel baseFilterModel)
        {
            //Dictionary<string, string> _dict = new Dictionary<string, string>();

            //PropertyInfo[] props = typeof(T).GetProperties();
            //foreach (PropertyInfo prop in props)
            //{
            //    object[] attrs = prop.GetCustomAttributes(true);
            //    foreach (object attr in attrs)
            //    {
            //        AuthorAttribute authAttr = attr as AuthorAttribute;
            //        if (authAttr != null)
            //        {
            //            string propName = prop.Name;
            //            string auth = authAttr.Name;

            //            _dict.Add(propName, auth);
            //        }
            //    }
            //}
            var param = Expression.Parameter(typeof(Post), "p");
            var exp = Expression.Lambda<Func<Post, bool>>(
                Expression.Equal(
                    Expression.Property(param, "Name"),
                    Expression.Constant("Bob")
                ),
                param
            );

            ParameterExpression parameter = Expression.Parameter(typeof(T), "x");
            //Expression left = Expression.Call(parameter, typeof(T).GetMethod("Contains",Type.EmptyTypes));
            var expression = Expression.Lambda<Func<Post, bool>>(
                Expression.Equal(Expression.Property(parameter, ""),
                Expression.Constant("")),
                parameter
                );
            return source;
        }
    }
}
