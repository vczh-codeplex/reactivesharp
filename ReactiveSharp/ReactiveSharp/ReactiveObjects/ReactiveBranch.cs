using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReactiveSharp.ReactiveObjects
{
    class ReactiveBranch<T> : ReactiveEnumerableBase<T>
    {
        private Action<IReactiveEnumerable<T>, T> action;

        public ReactiveBranch(IReactiveEnumerable<T> source, Action<IReactiveEnumerable<T>, T> action)
        {
            this.action = action;
            source.ValueAdded += new ValueAddedDelegate<T>(source_ValueAdded);
        }

        private void source_ValueAdded(object sender, ReactiveEnumerableValueAddedEventArgs<T> e)
        {
            this.action(e.Sender, e.LastValue);
            AppendValue(e.LastValue);
        }
    }
}
