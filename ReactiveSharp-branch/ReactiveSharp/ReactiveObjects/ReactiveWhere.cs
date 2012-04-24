using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReactiveSharp.ReactiveObjects
{
    class ReactiveWhere<T> : ReactiveEnumerableBase<T>
    {
        private Func<T, bool> selector = null;

        public ReactiveWhere(IReactiveEnumerable<T> source, Func<T, bool> selector)
        {
            source.ValueAdded += new ValueAddedDelegate<T>(source_ValueAdded);
            this.selector = selector;
        }

        private void source_ValueAdded(object sender, ReactiveEnumerableValueAddedEventArgs<T> e)
        {
            if (this.selector(e.LastValue))
            {
                AppendValue(e.LastValue);
            }
        }
    }
}
