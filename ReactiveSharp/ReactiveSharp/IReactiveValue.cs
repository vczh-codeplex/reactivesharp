using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReactiveSharp
{
    public interface IReactiveValue<T>
    {
        event ValueIncomedDelegate<T> ValueIncomed;
    }

    public class ReactiveValueValueIncomedEventArgs<T> : EventArgs
    {
        public IReactiveValue<T> Sender { get; set; }
        public T CurrentValue { get; set; }
        public T LastValue { get; set; }
    }

    public delegate void ValueIncomedDelegate<T>(object sender, ReactiveValueValueIncomedEventArgs<T> e);
}
