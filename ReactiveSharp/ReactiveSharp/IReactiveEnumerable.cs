using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReactiveSharp
{
    public interface IReactiveEnumerable<T>
    {
        event ValueAddedDelegate<T> ValueAdded;

        IEnumerable<T> ValueRecorder { get; }
        bool ValueRecording { get; set; }
    }

    public class ReactiveEnumerableValueAddedEventArgs<T> : EventArgs
    {
        public IReactiveEnumerable<T> Sender { get; set; }
        public T LastValue { get; set; }
    }

    public delegate void ValueAddedDelegate<T>(object sender, ReactiveEnumerableValueAddedEventArgs<T> e);
}
