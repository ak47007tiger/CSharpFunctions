using System;

namespace UseCSharp {
  public class TestDateTime {
    public static bool IsChallengeMonth(DateTime dateTime) {
      var now = DateTime.Now;
      var max = new DateTime(now.Year, now.Month, 1).AddMonths(1);
      var min = max.AddMonths(-7);
      return min <= dateTime && dateTime < max.AddDays(1);
    }

    public void TestRange(){
      var now = DateTime.Now;
      Console.WriteLine(IsChallengeMonth(now.AddMonths(1)));
      Console.WriteLine(IsChallengeMonth(now));
      Console.WriteLine(IsChallengeMonth(now.AddMonths(-1)));
      Console.WriteLine(IsChallengeMonth(now.AddMonths(-2)));
      Console.WriteLine(IsChallengeMonth(now.AddMonths(-3)));
      Console.WriteLine(IsChallengeMonth(now.AddMonths(-4)));
      Console.WriteLine(IsChallengeMonth(now.AddMonths(-5)));
      Console.WriteLine(IsChallengeMonth(now.AddMonths(-6)));
      Console.WriteLine(IsChallengeMonth(now.AddMonths(-7)));
    }

    public void TestDayOfWeek() {
      var dt = new DateTime(2018, 7, 1);
      for (var i = 1; i <= 6; i++) {
        Console.WriteLine(dt.ToString() + "," + (int) dt.DayOfWeek);
        dt = dt.AddDays(1);
      }
    }

    public void TestMonths() {
      var now = DateTime.Now;
      for (var i = 0; i <= 12; i++) {
        var avaiableMonth = now.AddMonths(-i);
        Console.WriteLine(avaiableMonth);
      }
    }

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