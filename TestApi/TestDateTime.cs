using System;

namespace UseCSharp {
  public class TestDateTime {
    public void SimpleTest() {
      DateTime dt = DateTime.Now;
      var culture = System.Globalization.CultureInfo.CreateSpecificCulture("en-US");
      var s = dt.ToString(culture);
      DateTime dt1 = DateTime.Parse(s, culture);
      Console.WriteLine(s);
      Console.WriteLine(dt1.ToString());
    }

    public void TestTimeSpan() {
      DateTime dt = DateTime.Now;
      var culture = System.Globalization.CultureInfo.CreateSpecificCulture("en-US");
      var s = dt.ToString(culture);
      DateTime dt1 = DateTime.Parse(s, culture);

      var ts = dt - dt1;
      Console.WriteLine(ts);
      Console.WriteLine(ts.Days);

    }
  }
}