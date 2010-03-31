using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReactiveSharp.ReactiveObjects
{
    class ReactiveSelect<T, K> : ReactiveEnumerableBase<K>
    {
        private Func<T, K> selector = null;

        public ReactiveSelect(IReactiveEnumerable<T> source, Func<T, K> selector)
        {
            source.ValueAdded += new ValueAddedDelegate<T>(source_ValueAdded);
            this.selector = selector;
        }

        private void source_ValueAdded(object sender, ReactiveEnumerableValueAddedEventArgs<T> e)
        {
            AppendValue(this.selector(e.LastValue));
        }
    }
}
