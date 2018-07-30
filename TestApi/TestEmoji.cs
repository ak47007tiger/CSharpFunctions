using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCSharp.test_api
{
  public class TestEmoji
  {
    public void Test()
    {
      var s = char.ConvertFromUtf32(0x1f602);
      Console.WriteLine(s);
      Console.WriteLine("jtpseoihjoaiefpfji\ud83c\udc51");
    }
  }
}
