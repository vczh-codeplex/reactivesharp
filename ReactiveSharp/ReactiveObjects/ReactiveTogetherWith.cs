using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReactiveSharp.ReactiveObjects
{
    class ReactiveTogetherWith<T> : ReactiveEnumerableBase<T>
    {
        public ReactiveTogetherWith(IReactiveEnumerable<T> sourceA, IReactiveEnumerable<T> sourceB)
        {
            sourceA.ValueAdded += new ValueAddedDelegate<T>(source_ValueAdded);
            sourceB.ValueAdded += new ValueAddedDelegate<T>(source_ValueAdded);
        }

        private void source_ValueAdded(object sender, ReactiveEnumerableValueAddedEventArgs<T> e)
        {
            AppendValue(e.LastValue);
        }
    }
}
