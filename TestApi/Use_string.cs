using System;

namespace UseCSharp
{
  public class Use_string
  {
    public Use_string()
    {
    }

    public void testSpilt()
    {
      string line1 = "asdb-ow";
      string line2 = "daowe-";
      string line3 = "oqwie";

      string[] sL1 = line1.Split('-');
      string[] sL2 = line2.Split('-');
      string[] sL3 = line3.Split('-');
    }

    public void TestRemove()
    {
      string origin = "ab,cd,ef,gh";
      string remove1 = ",cd";
      string remove2 = "cd,";
      string remove3 = "cd";
      string after = origin.Remove(origin.IndexOf(remove1), remove1.Length);
      Console.WriteLine(after);
    }

  }

  public class GetSet
  {
    public static void testGetSet()
    {
      GetSet gs = new GetSet();
      Console.WriteLine(gs.num);
      Console.WriteLine(gs.Num);
      gs.Num = 6;
      Console.WriteLine(gs.num);
      Console.WriteLine(gs.Num);
    }
    int num = 10;
    public int Num { get { return num; } set { num = value; } }

    public int content
    {
      get;
      set;
    }
  }

  public class UnityUtils
  {
    public static void test_int2string()
    {
      int v = 100 * 1000 * 1000;
      Console.WriteLine(v);
      string text = new UnityUtils().int2string(v);
      Console.WriteLine(text);
    }
    public string int2string(int money)
    {
      //13000000 -> 13,000,000
      /*
      获得一个字符串
      从字符串最后一个开始复制
      每复制3个就插入一个","号
      */
      string content = string.Concat(money);
      int pointCount = (content.Length - 1) / 3;
      char[] newContent = new char[content.Length + pointCount];
      int dstIndex = newContent.Length - 1;
      int copyCount = 0;
      for (int i = content.Length - 1; i >= 0; i--)
      {
        if (copyCount == 3)
        {
          copyCount = 0;
          newContent[dstIndex] = ',';
          dstIndex--;
        }
        newContent[dstIndex] = content[i];
        dstIndex--;
        copyCount++;
      }
      string result = new string(newContent);

      return result;
    }
  }
}

