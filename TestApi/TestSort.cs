using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCSharp.test_api
{
  public class TestSort
  {
    void testSort()
    {
      string[] array = new string[] {
                "红烧肉",
                "排骨",
                "红烧鸡腿",
                "酱香排骨"
            };

      Array.Sort<string>(array, new NameIComparer());
      for (int i = 0; i < array.Length; i++)
      {
        string item = array[i];
        Console.WriteLine(item);
      }
      Console.ReadKey();
    }
  }

  class NameIComparer : IComparer<string>
  {

    public int Compare(string x, string y)
    {
      int minLength = Math.Min(x.Length, y.Length);
      for (int i = 0; i < minLength; i++)
      {
        if (x[i] < y[i])
        {
          return -1;
        }
        if (x[i] > y[i])
        {
          return 1;
        }
      }
      if (x.Length == y.Length)
      {
        return 0;
      }
      else if (x.Length > y.Length)
      {
        return -1;
      }
      else
      {
        return 1;
      }
    }
  }
}
