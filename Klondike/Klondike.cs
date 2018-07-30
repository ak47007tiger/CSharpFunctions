using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace UseCSharp.Klondike
{
  public class Klondike
  {
    string Convert(string i)
    {
      if (i.Length == 1)
        return "0" + i;
      return i;
    }

    //from x|x...|x to x x ... x 
    public string ConvertBoard(string content)
    {
      var board = content.Split('|');
      var sbd = new StringBuilder();
      for (var i = 0; i < board.Length; i++)
      {
        sbd.Append(Convert(board[i])).Append(' ');
      }
      sbd.Remove(sbd.Length - 1, 1);
      return sbd.ToString();
    }

    void Rename()
    {
      var dir = new DirectoryInfo("E:/hpl_projects/unity_projects/Klongdike/Game");
      var files = dir.GetFiles();
      foreach (var file in files)
      {
        var fileName = file.Name;
        var name = fileName.Substring(0, fileName.LastIndexOf('.'));
        var n1n2 = name.Split('_');
        var newName = n1n2[1] + "_" + n1n2[0] + ".png";
        //var outStr = string.Format("{0} -> {1}, n1:{2}, n2:{3}", name, newName, n1n2[0], n1n2[1]);
        //Console.WriteLine(outStr);
        File.Move(file.FullName, Path.Combine(dir.FullName, newName));
      }
    }
    
  }
}
