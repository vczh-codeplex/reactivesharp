using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReactiveSharp
{
    public interface IReactiveEnumerableAcceptor<T>
    {
        void IReactiveEnumerableAppended(IReactiveEnumerable<T> reactiveEnumerable);
    }
}
