using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ReactiveSharp.ReactiveObjects;

namespace ReactiveSharp
{
    public static class ReactiveEvent
    {
        #region Enumerable Operations

        public static IReactiveEnumerable<K> Select<T, K>(this IReactiveEnumerable<T> source, Func<T, K> selector)
        {
            return new ReactiveSelect<T, K>(source, selector);
        }

        public static IReactiveEnumerable<T> Where<T>(this IReactiveEnumerable<T> source, Func<T, bool> selector)
        {
            return new ReactiveWhere<T>(source, selector);
        }

        public static IReactiveValue<T> Aggregate<T, K>(this IReactiveEnumerable<K> source, T initialValue, Func<T, K, T> calculator)
        {
            return new ReactiveAggregate<T, K>(source, initialValue, calculator);
        }

        public static IReactiveValue<int> Count<T>(this IReactiveEnumerable<T> source)
        {
            return new ReactiveCount<T>(source);
        }

        public static IReactiveEnumerable<Tuple<T, T>> PairWise<T>(this IReactiveEnumerable<T> source)
        {
            return new ReactivePairWise<T>(source);
        }

        public static IReactiveEnumerable<T> TogetherWith<T>(this IReactiveEnumerable<T> sourceA, IReactiveEnumerable<T> sourceB)
        {
            return new ReactiveTogetherWith<T>(sourceA, sourceB);
        }

        public static IReactiveEnumerable<Tuple<int, T>> WithIndex<T>(this IReactiveEnumerable<T> source)
        {
            return new ReactiveWithIndex<T>(source);
        }

        public static IReactiveEnumerable<T> Branch<T>(this IReactiveEnumerable<T> source, Action<IReactiveEnumerable<T>, T> action)
        {
            return new ReactiveBranch<T>(source, action);
        }

        public static IReactiveEnumerable<T> Branch<T>(this IReactiveEnumerable<T> source, Action<T> action)
        {
            return new ReactiveBranch<T>(source, (s, e) => action(e));
        }

        #endregion

        #region Value Operations

        public static IReactiveValue<T> Listen<T>(this IReactiveValue<T> source, Action<T, T> handler)
        {
            return new ReactiveListen<T>(source, handler);
        }

        public static IReactiveValue<T> Listen<T>(this IReactiveValue<T> source, Action<T> handler)
        {
            return new ReactiveListen<T>(source, (a, b) => { handler(b); });
        }

        #endregion

        #region Extended Operations

        public static IReactiveValue<bool> All<T>(this IReactiveEnumerable<T> source, Func<T, bool> calculator)
        {
            return source.Aggregate(true, (a, b) => (a && calculator(b)));
        }

        public static IReactiveValue<bool> Any<T>(this IReactiveEnumerable<T> source, Func<T, bool> calculator)
        {
            return source.Aggregate(false, (a, b) => (a || calculator(b)));
        }

        #endregion

        #region Int16 Operations

        public static IReactiveValue<short> Sum(this IReactiveEnumerable<short> source)
        {
            return source.Aggregate((short)0, (a, b) => ((short)(a + b)));
        }

        public static IReactiveValue<short> Max(this IReactiveEnumerable<short> source)
        {
            return source.Aggregate((short)0, (a, b) => (a > b ? a : b));
        }

        public static IReactiveValue<short> Min(this IReactiveEnumerable<short> source)
        {
            return source.Aggregate((short)0, (a, b) => (a < b ? a : b));
        }

        #endregion

        #region Int32 Operations

        public static IReactiveValue<int> Sum(this IReactiveEnumerable<int> source)
        {
            return source.Aggregate((int)0, (a, b) => ((int)(a + b)));
        }

        public static IReactiveValue<int> Max(this IReactiveEnumerable<int> source)
        {
            return source.Aggregate((int)0, (a, b) => (a > b ? a : b));
        }

        public static IReactiveValue<int> Min(this IReactiveEnumerable<int> source)
        {
            return source.Aggregate((int)0, (a, b) => (a < b ? a : b));
        }

        #endregion

        #region Int64 Operations

        public static IReactiveValue<long> Sum(this IReactiveEnumerable<long> source)
        {
            return source.Aggregate((long)0, (a, b) => ((long)(a + b)));
        }

        public static IReactiveValue<long> Max(this IReactiveEnumerable<long> source)
        {
            return source.Aggregate((long)0, (a, b) => (a > b ? a : b));
        }

        public static IReactiveValue<long> Min(this IReactiveEnumerable<long> source)
        {
            return source.Aggregate((long)0, (a, b) => (a < b ? a : b));
        }

        #endregion

        #region Single Operations

        public static IReactiveValue<float> Sum(this IReactiveEnumerable<float> source)
        {
            return source.Aggregate((float)0, (a, b) => ((float)(a + b)));
        }

        public static IReactiveValue<float> Max(this IReactiveEnumerable<float> source)
        {
            return source.Aggregate((float)0, (a, b) => (a > b ? a : b));
        }

        public static IReactiveValue<float> Min(this IReactiveEnumerable<float> source)
        {
            return source.Aggregate((float)0, (a, b) => (a < b ? a : b));
        }

        #endregion

        #region Double Operations

        public static IReactiveValue<double> Sum(this IReactiveEnumerable<double> source)
        {
            return source.Aggregate((double)0, (a, b) => ((double)(a + b)));
        }

        public static IReactiveValue<double> Max(this IReactiveEnumerable<double> source)
        {
            return source.Aggregate((double)0, (a, b) => (a > b ? a : b));
        }

        public static IReactiveValue<double> Min(this IReactiveEnumerable<double> source)
        {
            return source.Aggregate((double)0, (a, b) => (a < b ? a : b));
        }

        #endregion

        #region Decimal Operations

        public static IReactiveValue<decimal> Sum(this IReactiveEnumerable<decimal> source)
        {
            return source.Aggregate((decimal)0, (a, b) => ((decimal)(a + b)));
        }

        public static IReactiveValue<decimal> Max(this IReactiveEnumerable<decimal> source)
        {
            return source.Aggregate((decimal)0, (a, b) => (a > b ? a : b));
        }

        public static IReactiveValue<decimal> Min(this IReactiveEnumerable<decimal> source)
        {
            return source.Aggregate((decimal)0, (a, b) => (a < b ? a : b));
        }

        #endregion
    }
}
