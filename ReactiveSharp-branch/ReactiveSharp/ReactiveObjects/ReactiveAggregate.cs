using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReactiveSharp.ReactiveObjects
{
    class ReactiveAggregate<T, K> : ReactiveValueBase<T>
    {
        private T initialValue = default(T);
        private Func<T, K, T> calculator = null;

        public ReactiveAggregate(IReactiveEnumerable<K> source, T initialValue, Func<T, K, T> calculator)
        {
            source.ValueAdded += new ValueAddedDelegate<K>(source_ValueAdded);
            this.initialValue = initialValue;
            this.calculator = calculator;
        }

        private void source_ValueAdded(object sender, ReactiveEnumerableValueAddedEventArgs<K> e)
        {
            this.initialValue = this.calculator(this.initialValue, e.LastValue);
            ChangeValue(this.initialValue);
        }
    }
}
