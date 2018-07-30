using System;

namespace UseCSharp
{
    public class TestEnum
    {
        public enum Type
        {
            t1,t2,t3
        }

        public void TestName()
        {
            Console.WriteLine(Type.t1.ToString());
        }

        public void TestOperate()
        {
            Type t = Type.t1;
            Console.WriteLine((int)(t));
            t++;
            Console.WriteLine((int)(t));
            Console.WriteLine((int)(t--));
        }

        public void TestIndex()
        {
            Console.WriteLine(Type.t2);
            int i = (int)Type.t2;
            Console.WriteLine(i);
        }
    }
}
