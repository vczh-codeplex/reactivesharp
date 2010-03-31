using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReactiveSharp.ReactiveObjects
{
    class ReactivePairWise<T> : ReactiveEnumerableBase<Tuple<T, T>>
    {
        private T currentValue = default(T);
        private bool hasValue = false;

        public ReactivePairWise(IReactiveEnumerable<T> source)
        {
            source.ValueAdded += new ValueAddedDelegate<T>(source_ValueAdded);
        }

        private void source_ValueAdded(object sender, ReactiveEnumerableValueAddedEventArgs<T> e)
        {
            if (this.hasValue)
            {
                AppendValue(new Tuple<T, T>(this.currentValue, e.LastValue));
            }
            this.hasValue = true;
            this.currentValue = e.LastValue;
        }
    }
}
