using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReactiveSharp
{
    public interface IReactiveEnumerable<T>
    {
        bool InstallAcceptor(IReactiveEnumerableAcceptor<T> acceptor);
        bool UninstallAcceptor(IReactiveEnumerableAcceptor<T> acceptor);
        T LastValue { get; }
        bool IsEmpty { get; }

        IEnumerable<T> ValueRecorder { get; }
        bool ValueRecording { get; set; }
    }
}
