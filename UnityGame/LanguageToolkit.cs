using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using SimpleJSON;

namespace UseCSharp.UnityGame
{
  class LanguageToolkit
  {
  }

  public class PrintAllTranslate
  {
    string[] languages;
    string languagesJsonStr;

    public void SetLanguages(string[] languages)
    {
      this.languages = languages;
      /*
      {
        key:{
          "en":"",
          "de":"",
          "es":""
        }
      }
      "en":"","de":"","es":""
      */
      var sbd = new StringBuilder();
      sbd.Append('{');
      foreach (var language in languages)
      {
        sbd.Append(string.Format("\"{0}\":\"\",", language));
      }
      sbd.Remove(sbd.Length - 1, 1);
      sbd.Append('}');
      languagesJsonStr = sbd.ToString();
    }

    public string Convert(string path)
    {
      return Convert(Filter(File.ReadAllText(path).Split('\n')));
    }

    public string[] Filter(string[] lines)
    {
      var list = new List<string>();
      foreach (var line in lines)
      {
        if (line.Length == 0 || line.StartsWith("//"))
        {
          continue;
        }
        list.Add(line);
      }
      return list.ToArray();
    }

    public string Convert(string[] summarys)
    {
      var sbd = new StringBuilder();
      sbd.Append('{');
      foreach (var summary in summarys)
      {
        sbd.Append(string.Format("\"{0}\":{1},", summary, languagesJsonStr));
      }
      sbd.Remove(sbd.Length - 1, 1);
      sbd.Append('}');
      return sbd.ToString();
    }

    public string ConvertWithEnKey(string[] summarys)
    {
      var json = new JSONObject();
      foreach (var summary in summarys)
      {
        var lanJson = JSON.Parse(languagesJsonStr);
        lanJson["en"] = summary;
        json.Add(summary, lanJson);
      }
      return json.ToString(1);
    }

    public void TrimJsonFile(string path)
    {
      var content = JSON.Parse(File.ReadAllText(path)).ToString(1);
      File.WriteAllText(path, content);
    }
  }
}
