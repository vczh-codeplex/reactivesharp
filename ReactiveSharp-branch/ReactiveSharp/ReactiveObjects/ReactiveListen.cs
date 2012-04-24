using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReactiveSharp.ReactiveObjects
{
    class ReactiveListen<T> : ReactiveValueBase<T>
    {
        private Action<T, T> handler = null;

        public ReactiveListen(IReactiveValue<T> value, Action<T, T> handler)
        {
            value.ValueIncomed += new ValueIncomedDelegate<T>(value_ValueIncomed);
            this.handler = handler;
        }

        private void value_ValueIncomed(object sender, ReactiveValueValueIncomedEventArgs<T> e)
        {
            handler(e.LastValue, e.CurrentValue);
            ChangeValue(e.LastValue);
        }
    }
}
