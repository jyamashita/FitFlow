using FitFlow.Models;
using FitFlow.Models.Base;
using System.Data.Entity;
using System.Linq;

namespace FitFlow.Extensions
{
    public static class IQueryableExtensions
    {
        public static IQueryable<T> NotDeleted<T>(this IQueryable<T> dbset)
            where T  : BaseLogicalDeleteModel
        {
            return dbset.Where(s => s.DeleteFlg == 0);
        }
    }
}