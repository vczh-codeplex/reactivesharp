using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReactiveSharp.ReactiveObjects
{
    abstract class ReactiveEnumerableBase<T> : IReactiveEnumerable<T>
    {
        private List<T> values = null;

        protected void AppendValue(T value)
        {
            if (this.ValueRecording)
            {
                this.values.Add(value);
            }
            if (this.ValueAdded != null)
            {
                this.ValueAdded(this, new ReactiveEnumerableValueAddedEventArgs<T>() { Sender = this, LastValue = value });
            }
        }

        #region IReactiveEnumerable<T> Members

        public event ValueAddedDelegate<T> ValueAdded;

        public IEnumerable<T> ValueRecorder
        {
            get
            {
                return this.values;
            }
        }

        public bool ValueRecording
        {
            get
            {
                return this.values != null;
            }
            set
            {
                if (value)
                {
                    this.values = new List<T>();
                }
                else
                {
                    this.values = null;
                }
            }
        }

        #endregion
    }
}
