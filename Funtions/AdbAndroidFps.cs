using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCSharp {
  class AdbAndroidFps {

    public void WhileLog(int duration) {
      while (true) {
        LogFpsStr(GetFpsStr());
        System.Threading.Thread.Sleep(duration);
      }
    }

    public void LogFpsStr(string result) {
      var lines = result.Split('\n');
      var times = new long[127];
      for (var i = 0; i < 127; i++) {
        var line = lines[i];
        var numbers = line.Split('\t');
        times[i] = long.Parse(numbers[1]);
      }
      long total = 0;
      for (var i = 0; i < 126; i++) {
        long t1 = times[i];
        long t2 = times[i + 1];
        var delta = t2 - t1;
        total += delta;
      }
      total = total / 1000000;
      Console.WriteLine(string.Format("total: {0}, avarage: {1}, last: {2}", total, total / 126, (times[126] - times[125]) / 1000000));
    }

    public string GetFpsStr() {
      //string strInput = Console.ReadLine();
      string strInput = "adb shell dumpsys SurfaceFlinger --latency";
      Process p = new Process();
      //设置要启动的应用程序
      p.StartInfo.FileName = "cmd.exe";
      //是否使用操作系统shell启动
      p.StartInfo.UseShellExecute = false;
      // 接受来自调用程序的输入信息
      p.StartInfo.RedirectStandardInput = true;
      //输出信息
      p.StartInfo.RedirectStandardOutput = true;
      // 输出错误
      p.StartInfo.RedirectStandardError = true;
      //不显示程序窗口
      p.StartInfo.CreateNoWindow = true;
      //启动程序
      p.Start();

      //向cmd窗口发送输入信息
      p.StandardInput.WriteLine(strInput + "&exit");

      p.StandardInput.AutoFlush = true;

      //获取输出信息
      p.StandardOutput.ReadLine();
      p.StandardOutput.ReadLine();
      p.StandardOutput.ReadLine();
      p.StandardOutput.ReadLine();

      var ms = p.StandardOutput.ReadLine();

      p.StandardOutput.ReadLine();

      string strOuput = p.StandardOutput.ReadToEnd();
      //Console.WriteLine(strOuput);
      //等待程序执行完退出进程
      p.WaitForExit();
      p.Close();

      strOuput.IndexOf("&exit");

      return strOuput;
    }
  }
}