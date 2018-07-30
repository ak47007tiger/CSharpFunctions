using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCSharp
{

    public class EventA : EventArgs
    {

    }

    public class EventB : EventArgs
    {

    }

    public class HandlerA
    {
        public void Handle(EventArgs e)
        {
            Console.WriteLine(e.GetType().Name);
        }
    }

    public class HandlerB
    {
        public void Handle(EventArgs e)
        {
            Console.WriteLine(e.GetType().Name);
        }
    }

    public class DelegageConfirm
    {
        public void Delegage1(EventArgs e)
        {
            Console.WriteLine("DelegageConfirm");
        }
    }

    public class EventBusClient
    {
        public void TestDelegate()
        {
            EventBus.OnEvent onEvent = null;

            var dc = new DelegageConfirm();
            onEvent += dc.Delegage1;

            onEvent.Invoke(new EventArgs());

            onEvent -= dc.Delegage1;

            if(onEvent != null)
            {
                onEvent.Invoke(new EventArgs());
            }
            else
            {
                Console.WriteLine("on event is null");
            }

        }

        public void TestAddMulti()
        {
            EventBus eb = new EventBus();

            HandlerA ha = new HandlerA();
            HandlerA ha1 = new HandlerA();


            eb.Add<EventA>(ha.Handle);
            eb.Add<EventA>(ha1.Handle);

            eb.Dispatch(new EventA());
            eb.Remove<EventA>(ha.Handle);
            eb.Dispatch(new EventA());
        }

        public void Test()
        {
            EventBus eb = new EventBus();

            HandlerA ha = new HandlerA();
            HandlerA ha1 = new HandlerA();

            HandlerB hb = new HandlerB();

            eb.Add<EventA>(ha.Handle);
            eb.Add<EventA>(ha1.Handle);
            eb.Add<EventB>(hb.Handle);

            eb.Dispatch(new EventA());
            eb.Dispatch(new EventB());
            eb.Remove<EventA>(ha.Handle);
            eb.Dispatch(new EventA());
            eb.Remove<EventA>(ha1.Handle);
            eb.Dispatch(new EventA());

        }
    }


    public class EventBus
    {
        public delegate void OnEvent(EventArgs e);

        Dictionary<Type, List<OnEvent>> dir = new Dictionary<Type, List<OnEvent>>();

        public void Add<T>(OnEvent handler) where T:EventArgs
        {
            var t = typeof(T);

            if (!dir.ContainsKey(t))
            {
                dir[t] = new List<OnEvent>();
            }
            var handlers = dir[t];
            if (!handlers.Equals(handler))
            {
                handlers.Add(handler);
            }
        }

        public void Remove<T>(OnEvent handler)
        {
            var t = typeof(T);
            if (dir.ContainsKey(t))
            {
                dir[t].Remove(handler);
                if(dir[t].Count == 0)
                {
                    dir.Remove(t);
                }
            }
        }

        public void Dispatch<T>(T e) where T : EventArgs
        {
            var t = typeof(T);
            if (dir.ContainsKey(t))
            {
                var handlers = dir[t];
                for(int i = 0; i < handlers.Count; i++)
                {
                    handlers[i].Invoke(e);
                }
            }
        }

    }

}
