using System;

namespace UseCSharp
{
    public class TestEvent
    {
        public event System.Action Foo;

        public void Clear()
        {
            Foo = null;
        }

        public void Listener1()
        {
            Console.WriteLine("Listener1");
        }

        public void Listener2()
        {
            Console.WriteLine("Listener2");
        }

        public void Nortify()
        {
            Foo?.Invoke();
        }
    }
}
