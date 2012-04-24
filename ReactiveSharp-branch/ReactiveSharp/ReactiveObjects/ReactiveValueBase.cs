using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReactiveSharp.ReactiveObjects
{
    class ReactiveValueBase<T> : IReactiveValue<T>
    {
        private T lastValue=default(T);

        protected void ChangeValue(T value)
        {
            if (this.ValueIncomed != null)
            {
                this.ValueIncomed(this, new ReactiveValueValueIncomedEventArgs<T>() { Sender = this, CurrentValue = value, LastValue = this.lastValue });
            }
            this.lastValue = value;
        }

        #region IReactiveValue<T> Members

        public event ValueIncomedDelegate<T> ValueIncomed;

        #endregion
    }
}
