using Antlr.Runtime.Misc;
using FitFlow.Models;
using FitFlow.Models.Base;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace FitFlow.Extensions
{
    public static class IQueryableExtension
    {
        public static IQueryable<T> NotDeleted<T>(this IQueryable<T> dbset)
            where T  : BaseLogicalDeleteModel
        {
            return dbset.Where(s => s.DeleteFlg == 0);
        }

        public static T Must<T>(this IQueryable<T> dbset, Expression<System.Func<T, bool>> predicate)
        {
            var source = dbset.FirstOrDefault(predicate);
            if (source == null)
                throw new Exception(string.Format("{0} select query is not mutch.", typeof(T)));
            else
                return source;
        }

        public static List<T> Musts<T>(this IQueryable<T> dbset, Expression<System.Func<T, bool>> predicate)
        {
            var source = dbset.Where(predicate).ToList();
            if (source.Any())
                throw new Exception(string.Format("{0} select query is not mutch.", typeof(T)));
            else
                return source;
        }
    }
}