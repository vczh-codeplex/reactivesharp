using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReactiveSharp.ReactiveObjects
{
    class ReactiveCount<T> : ReactiveValueBase<int>
    {
        private int counter = 0;

        public ReactiveCount(IReactiveEnumerable<T> source)
        {
            source.ValueAdded += new ValueAddedDelegate<T>(source_ValueAdded);
        }

        private void source_ValueAdded(object sender, ReactiveEnumerableValueAddedEventArgs<T> e)
        {
            counter++;
            ChangeValue(counter);
        }
    }
}
