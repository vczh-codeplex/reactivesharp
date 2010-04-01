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
        private class ReactiveControlEvent<T> : ReactiveEnumerableBase<T>
            where T : EventArgs
        {
            public void EventReceiver(object sender, T e)
            {
                AppendValue(e);
            }
        }

        public static IReactiveEnumerable<T> AttachEvent<T>(this Control control, string name)
            where T : EventArgs
        {
            EventInfo eventInfo = control.GetType().GetEvent(name);
            ReactiveControlEvent<T> eventReceiver = new ReactiveControlEvent<T>();
            eventInfo.AddEventHandler(control, Delegate.CreateDelegate(
                eventInfo.EventHandlerType,
                eventReceiver,
                eventReceiver.GetType().GetMethod("EventReceiver")
                ));
            return eventReceiver;
        }
    }
}
