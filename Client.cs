using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using AlgorithmForce.Searching;
using CSharpFunctions;
using CSharpFunctions.Test;
using CSharpFunctions.Toolkit;
using UseCSharp.Klondike;
using UseCSharp.UnityGame;

namespace UseCSharp {
  public class Client {

    public static void MainEx(string[] args) {
      //new TestDateTime().TestRange();
      // new MatRotate().Start();
      // new TestNullAction().Test1();
      //new BoardConverterTest().Test2();
      // ConvertBoardTask.EncodeGameBoardAsset();
      // ConvertBoardTask.EnsureDecodeCorrect();
      // ConvertBoardTask.EnsureDecodeBoard();
      string s = "1231abcdabcd123231abcdabcdabcdtrefabc";
      var t = new List<char> { 'a', 'b', 'c', 'd', 'a', 'b', 'c', 'd' };
      foreach (var index in s.IndexesOf(t)) {
        Console.WriteLine(index); // 4, 18, 22
      }
    }

    static void printf(object format, params object[] arg) {
      Console.WriteLine(format.ToString(), arg);
    }

    static void Main1(string[] args) {
      var pAllTranslate = new PrintAllTranslate();
      pAllTranslate.SetLanguages(new string[] {
        "en",
        "de",
        "es",
        "fr",
        "hi",
        "in",
        "it",
        "ja",
        "ko",
        "pt",
        "ru",
        "tr",
        "zh",
        "zht"
      });
      //File.WriteAllText("D:\\hpl\\klondike_dev\\klondike_languages.json", pAllTranslate.Convert("D:\\hpl\\klondike_dev\\klondike_translate_summary.c"));
      File.WriteAllText("D:\\hpl\\klondike_dev\\klondike_languages_temp.json",
       pAllTranslate.ConvertWithEnKey(new string[] {
         "notification_message0",
         "notification_message1",
         "notification_message2",
         "notification_message3",
         "notification_message4",
         "notification_message5",
         "notification_message6",
         "yes or no clear vegas integral",
         "Google Play is not initialized!"
       }));
      printf("ok");
      Console.ReadLine();
    }

    static void Main2(string[] args) {
      var klondikeDfficultyComputer = new KlondikeDifficultyComputer();
      var klondikeRobot = new KlondikeRobot();
      string boardStr;
      boardStr = "39|22|40|37|4|50|21|38|30|13|9|27|14|34|51|7|11|36|24|3|20|42|18|12|35|5|19|41|15|44|2|52|16|26|29|49|47|31|45|6|25|23|48|8|28|33|1|32|46|17|43|10";
      boardStr = "10|35|47|39|19|17|3|12|50|41|11|22|6|49|2|14|43|33|42|24|13|21|25|34|38|20|48|8|5|27|52|9|37|23|30|36|16|40|1|32|45|18|26|51|29|4|28|46|44|7|31|15";
      boardStr = "5|51|31|3|1|2|24|46|42|25|52|47|33|37|36|28|6|22|30|9|34|27|13|23|19|48|50|11|39|49|10|32|14|44|40|12|38|16|45|4|7|41|35|8|43|17|15|29|20|21|18|26";
      boardStr = "3|20|1|43|27|42|39|9|23|45|2|47|33|22|37|10|30|50|6|34|24|16|40|19|41|36|4|7|8|46|29|31|13|51|15|21|25|26|18|12|14|32|49|11|48|38|52|5|17|35|44|28";
      boardStr = "37|41|20|3|32|36|2|52|11|17|10|50|12|1|23|22|21|39|16|14|30|29|38|18|6|42|46|33|49|5|15|48|43|51|9|45|19|31|24|28|4|26|7|47|40|8|35|25|27|34|13|44";
      boardStr = "7|24|5|38|37|41|42|39|23|43|10|31|17|30|15|29|1|12|48|45|26|46|27|4|52|18|47|44|28|14|32|25|3|40|33|35|11|8|22|21|13|36|50|20|19|51|2|49|6|16|9|34";

      var board = klondikeRobot.Convert(boardStr.Split('|'));
      klondikeDfficultyComputer.CompletelySearch(board);
      Console.ReadLine();
    }
  }
}