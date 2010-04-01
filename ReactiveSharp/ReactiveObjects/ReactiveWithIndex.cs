using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReactiveSharp.ReactiveObjects
{
    class ReactiveWithIndex<T> : ReactiveEnumerableBase<Tuple<int, T>>
    {
        private int index = 0;

        public ReactiveWithIndex(IReactiveEnumerable<T> source)
        {
            source.ValueAdded += new ValueAddedDelegate<T>(source_ValueAdded);
        }

        private void source_ValueAdded(object sender, ReactiveEnumerableValueAddedEventArgs<T> e)
        {
            AppendValue(new Tuple<int, T>() { V1 = index++, V2 = e.LastValue });
        }
    }
}
