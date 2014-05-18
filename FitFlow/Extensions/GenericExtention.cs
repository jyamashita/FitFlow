using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace FitFlow.Extensions
{
    public static class GenericExtention
    {
        public static V Nvl<T,V>(this T @this, Func<T,V> func)
        {
            if (@this != null)
                return func(@this);
            else
                return default(V);
        }

        public static V Nvl<T, V>(this T @this, Func<T, V> func, V @default)
        {
            if (@this != null)
                return func(@this);
            else
                return @default;
        }

        public static List<List<T>> AsGroupList<T>(this List<T> source, Func<T,int> func, int maxsize)
        {
            var groupList = new List<List<T>>();
            var group = new List<T>();
            var cnt = 0;
            source.ForEach(t => {
                if (maxsize < cnt + func(t)) {
                    cnt = 0;
                    groupList.Add(group);
                    group = new List<T>();
                }
                cnt += func(t);
                group.Add(t);
            });
            groupList.Add(group);
            return groupList;
        }

        public static List<List<T>> AsGroupList<T>(this IEnumerable<T> source, Func<T, int> func, int maxsize)
        {
            return source.ToList().AsGroupList(func, maxsize);
        }

        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            foreach (var item in source) {
                action(item);
            }
        }


    }
}