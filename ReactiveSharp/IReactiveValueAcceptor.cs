using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReactiveSharp
{
    public interface IReactiveValueAcceptor<T>
    {
        void ReactiveValueRefreshed(IReactiveValue<T> reactiveValue, T oldValue);
    }
}
