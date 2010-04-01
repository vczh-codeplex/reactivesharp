using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using ReactiveSharp.ReactiveObjects;

namespace ReactiveSharp
{
    public static class ControlReactiveHelper
    {
        private class ReactiveControlEvent<T> : ReactiveEnumerableBase<Tuple<object, T>>
            where T : EventArgs
        {
            public void EventReceiver(object sender, T e)
            {
                AppendValue(new Tuple<object, T>(sender, e));
            }
        }

        public static IReactiveEnumerable<Tuple<object, T>> AttachEvent<T>(this Control control, string name)
            where T : EventArgs
        {
            ReactiveControlEvent<T> eventReceiver = new ReactiveControlEvent<T>();
            EventInfo eventInfo = control.GetType().GetEvent(name);
            eventInfo.AddEventHandler(control, Delegate.CreateDelegate(
                eventInfo.EventHandlerType,
                eventReceiver,
                eventReceiver.GetType().GetMethod("EventReceiver")
                ));
            return eventReceiver;
        }

        public static IReactiveEnumerable<Tuple<object, T>> AttachEvent<T>(this IEnumerable<Control> controls, string name)
            where T : EventArgs
        {
            ReactiveControlEvent<T> eventReceiver = new ReactiveControlEvent<T>();
            foreach (Control control in controls)
            {
                EventInfo eventInfo = control.GetType().GetEvent(name);
                eventInfo.AddEventHandler(control, Delegate.CreateDelegate(
                    eventInfo.EventHandlerType,
                    eventReceiver,
                    eventReceiver.GetType().GetMethod("EventReceiver")
                    ));
            }
            return eventReceiver;
        }
    }
}
