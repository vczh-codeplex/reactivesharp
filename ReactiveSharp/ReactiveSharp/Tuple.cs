using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReactiveSharp
{
    public struct Tuple<T1>
    {
        public T1 V1 { get; set; }
    }

    public struct Tuple<T1, T2>
    {
        public T1 V1 { get; set; }
        public T2 V2 { get; set; }
    }

    public struct Tuple<T1, T2, T3>
    {
        public T1 V1 { get; set; }
        public T2 V2 { get; set; }
        public T3 V3 { get; set; }
    }

    public struct Tuple<T1, T2, T3, T4>
    {
        public T1 V1 { get; set; }
        public T2 V2 { get; set; }
        public T3 V3 { get; set; }
        public T4 V4 { get; set; }
    }

    public struct Tuple<T1, T2, T3, T4, T5>
    {
        public T1 V1 { get; set; }
        public T2 V2 { get; set; }
        public T3 V3 { get; set; }
        public T4 V4 { get; set; }
        public T5 V5 { get; set; }
    }

    public struct Tuple<T1, T2, T3, T4, T5, T6>
    {
        public T1 V1 { get; set; }
        public T2 V2 { get; set; }
        public T3 V3 { get; set; }
        public T4 V4 { get; set; }
        public T5 V5 { get; set; }
        public T6 V6 { get; set; }
    }

    public struct Tuple<T1, T2, T3, T4, T5, T6, T7>
    {
        public T1 V1 { get; set; }
        public T2 V2 { get; set; }
        public T3 V3 { get; set; }
        public T4 V4 { get; set; }
        public T5 V5 { get; set; }
        public T6 V6 { get; set; }
        public T7 V7 { get; set; }
    }

    public struct Tuple<T1, T2, T3, T4, T5, T6, T7, T8>
    {
        public T1 V1 { get; set; }
        public T2 V2 { get; set; }
        public T3 V3 { get; set; }
        public T4 V4 { get; set; }
        public T5 V5 { get; set; }
        public T6 V6 { get; set; }
        public T7 V7 { get; set; }
        public T8 V8 { get; set; }
    }
}
