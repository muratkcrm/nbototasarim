﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace API.Core.Specifications
{
    public class BaseSpecification<T> : ISpecification<T>
    {
        public BaseSpecification(Expression<Func<T, bool>> criteria, List<Expression<Func<T, object>>> ıncludes)
        {
            Criteria = criteria;
            Includes = ıncludes;
        }

        public Expression<Func<T, bool>> Criteria { get; }

        public List<Expression<Func<T, object>>> Includes { get; } = new List<Expression<Func<T, object>>>();

        protected void AddInclude(Expression<Func<T, object>> includeExpression) 
        {
            Includes.Add(includeExpression);
        }
    }
}
