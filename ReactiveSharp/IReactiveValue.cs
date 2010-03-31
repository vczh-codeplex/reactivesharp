using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReactiveSharp
{
    public interface IReactiveValue<T>
    {
        bool InstallAcceptor(IReactiveValueAcceptor<T> acceptor);
        bool UninstallAcceptor(IReactiveValueAcceptor<T> acceptor);
    }
}
