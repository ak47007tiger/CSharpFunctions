using System;
using System.Collections.Generic;

namespace UseCSharp
{
    public class TestCollectionAndEquals
    {
        public void Test()
        {
            ValueModel v0 = new ValueModel(0, 0);
            ValueModel v1 = new ValueModel(1, 1);
            ValueModel v2 = new ValueModel(2, 2);
            ValueModel v1_1 = new ValueModel(1, 1);

            List<ValueModel> list = new List<ValueModel>();
            list.Add(v0);
            list.Add(v1);
            list.Add(v2);
            if (list.Contains(v1_1))
            {
                Console.WriteLine("can contains");
            }
            if (list.Remove(v1_1))
            {
                Console.WriteLine("can remove");
            }
        }

        public void Test2()
        {
            ValueModel v0 = new ValueModel(0, 0);
            ValueModel v1 = new ValueModel(1, 1);
            ValueModel v2 = new ValueModel(2, 2);
            ValueModel v1_1 = new ValueModel(1, 1);

            List<ValueModel> list = new List<ValueModel>();
            list.Add(v0);
            list.Add(v1);
            list.Add(v2);
            Console.WriteLine("before add:" + list.Count);
            Console.WriteLine("obj:" + list[2]);
            list.Add(v1_1);
            Console.WriteLine("after add:" + list.Count);
            Console.WriteLine("obj:" + list[2]);
        }

        public void Test3()
        {
            ValueModel v0 = new ValueModel(0, 0);
            ValueModel v1 = new ValueModel(1, 1);
            ValueModel v2 = new ValueModel(2, 2);
            ValueModel v1_1 = new ValueModel(1, 1);

            List<ValueModel> list = new List<ValueModel>();
            list.Add(v0);
            list.Add(v1);
            list.Add(v2);
            Console.WriteLine("before add:" + list.Count);
            Console.WriteLine("obj:" + list[2]);
            list.Add(v2);
            Console.WriteLine("after add:" + list.Count);
            Console.WriteLine("obj:" + list[2]);
        }
    }

    public class ValueModel
    {
        static string Prefix = "ValueModel";
        int x;
        int y;

        public ValueModel(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public override bool Equals(object obj)
        {
            if (obj is ValueModel)
            {
                ValueModel objT = (ValueModel)obj;
                return objT.x == x && objT.y == y;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return (Prefix + " " + x + "," + y).GetHashCode();
        }
    }
}
