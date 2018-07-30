using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace UseCSharp.test_api
{
  public class TestRegion
  {
    public void PriteAllRegionInformation()
    {
      var cur = RegionInfo.CurrentRegion;
      Console.WriteLine(cur.Name);
      Console.WriteLine(cur.CurrencyEnglishName);
      Console.WriteLine(cur.CurrencySymbol);
      Console.WriteLine(cur.DisplayName);
      Console.WriteLine(cur.EnglishName);
      Console.WriteLine(cur.GeoId);
      Console.WriteLine(cur.TwoLetterISORegionName);
    }
  }
}
