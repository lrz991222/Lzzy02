using ELearning.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ELearning.DataAccess.Tools
{
    public static class ExpressionFactoryMethod
    {
        /// <summary>
        /// 构建指定属性名称的 Lambda 表达式
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public static Expression<Func<T, TKey>> GetPropertyExpression<T,TKey>(string propertyName) where T : class, IEntityBase, new()
        {
            ParameterExpression parameter = Expression.Parameter(typeof(T), "x");
            return Expression.Lambda<Func<T, TKey>>(Expression.Property(parameter, propertyName), parameter);
        }

        /// <summary>
        /// 构建根据指定关键词进行查询的条件 Lambda 表达式
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public static Expression<Func<T, bool>> GetConditionExpression<T>(string keyword) where T : class, IEntity, new()
        {
            Expression<Func<T, bool>> expression = _GetContains<T>("Name", keyword);
            PropertyInfo[] properties = typeof(T).GetProperties();

            foreach (var item in properties)
            {
                var itemTypeName = item.PropertyType.Name;
                if (itemTypeName.ToLower() == "string" && item.Name!="Name")
                {
                    expression = expression.Or(_GetContains<T>(item.Name, keyword));
                }
            }
            return expression;
        }

        public static Expression<Func<T, bool>> GetConditionExpression<T>(string keyword,string[] names) where T : class, IEntity, new()
        {
            Expression<Func<T, bool>> expression = _GetContains<T>("Name", keyword);
            foreach (var item in names)
            {
                if (item != "Name")
                {
                    expression = expression.Or(_GetContains<T>(item, keyword));
                }
            }
            return expression;
        }

        /// <summary>
        /// 创建lambda表达式：x=>x.propertyName.Contains(propertyValue)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="column"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        private static Expression<Func<T, bool>> _GetContains<T>(string propertyName, string propertyValue)
        {
            ParameterExpression parameter = Expression.Parameter(typeof(T), "x");
            MemberExpression member = Expression.PropertyOrField(parameter, propertyName);
            MethodInfo method = typeof(string).GetMethod("Contains", new[] { typeof(string) });
            ConstantExpression constant = Expression.Constant(propertyValue, typeof(string));

            return Expression.Lambda<Func<T, bool>>(Expression.Call(member, method, constant), parameter);
        }

    }

    public class SwapVisitor : ExpressionVisitor
    {
        private readonly Expression from, to;
        public SwapVisitor(Expression from, Expression to)
        {
            this.from = from;
            this.to = to;
        }
        public override Expression Visit(Expression node)
        {
            return node == from ? to : base.Visit(node);
        }
    }

    public class ParameterRebinder : ExpressionVisitor
    {
        private readonly Dictionary<ParameterExpression, ParameterExpression> map;
        public ParameterRebinder(Dictionary<ParameterExpression, ParameterExpression> map)
        {
            this.map = map ?? new Dictionary<ParameterExpression, ParameterExpression>();
        }
        public static Expression ReplaceParameters(Dictionary<ParameterExpression, ParameterExpression> map, Expression exp)
        {
            return new ParameterRebinder(map).Visit(exp);
        }
        protected override Expression VisitParameter(ParameterExpression p)
        {
            ParameterExpression replacement;
            if (map.TryGetValue(p, out replacement))
            {
                p = replacement;
            }
            return base.VisitParameter(p);
        }
    }

    public static class Utility
    {   
        /// <summary>
        /// Lambda表达式拼接        
        /// /// </summary>        
        /// /// <typeparam name="T"></typeparam>        
        /// /// <param name="first"></param>        
        /// /// <param name="second"></param>        
        /// /// <param name="merge"></param>        
        /// /// <returns></returns>        
        public static Expression<T> Compose<T>(this Expression<T> first, Expression<T> second, Func<Expression, Expression, Expression> merge)        
        {
            // build parameter map (from parameters of second to parameters of first)            
            var map = first.Parameters.Select((f, i) => new { f, s = second.Parameters[i] }).ToDictionary(p => p.s, p => p.f);
            // replace parameters in the second lambda expression with parameters from the first            
            var secondBody = ParameterRebinder.ReplaceParameters(map, second.Body);
            // apply composition of lambda expression bodies to parameters from the first expression             
            return Expression.Lambda<T>(merge(first.Body, secondBody), first.Parameters);
        }

        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second)
        {
            return first.Compose(second, Expression.And);
        }

        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second)
        {
            return first.Compose(second, Expression.Or);
        }
    }

}
