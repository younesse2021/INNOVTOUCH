using System;
using System.Collections.Generic;
using MvvmHelpers;

namespace XForms.Extensions
{
    public static class ObservableExtension
    {
        public static ObservableRangeCollection<T> ToObservableRangeCollection<T>(this IEnumerable<T> source)
        {
            var collection = new ObservableRangeCollection<T>();

            foreach (var item in source)
            {
                collection.Add(item);
            }

            return collection;
        }
    }
}
