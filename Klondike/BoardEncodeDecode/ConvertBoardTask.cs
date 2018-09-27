using System;
using System.IO;
using System.Text;
using CSharpFunctions.Klondike;
using CSharpFunctions.Toolkit;

namespace CSharpFunctions {
  public class ConvertBoardTask {

    public static void EncodeGameBoardAsset() {
      var inputPaths = new string[] {
        "E:/hpl_projects/unity_projects/Klongdike/Assets/_Klondike/Asset/boards_d1/easy.txt",
        "E:/hpl_projects/unity_projects/Klongdike/Assets/_Klondike/Asset/boards_d1/medium.txt",
        "E:/hpl_projects/unity_projects/Klongdike/Assets/_Klondike/Asset/boards_d1/hard.txt",
        "E:/hpl_projects/unity_projects/Klongdike/Assets/_Klondike/Asset/boards_d1/expert.txt",
        "E:/hpl_projects/unity_projects/Klongdike/Assets/_Klondike/Asset/boards_d1/master.txt",
        "E:/hpl_projects/unity_projects/Klongdike/Assets/_Klondike/Asset/boards_d1/guru.txt",

        "E:/hpl_projects/unity_projects/Klongdike/Assets/_Klondike/Asset/boards_d3/easy.txt",
        "E:/hpl_projects/unity_projects/Klongdike/Assets/_Klondike/Asset/boards_d3/medium.txt",
        "E:/hpl_projects/unity_projects/Klongdike/Assets/_Klondike/Asset/boards_d3/hard.txt",
        "E:/hpl_projects/unity_projects/Klongdike/Assets/_Klondike/Asset/boards_d3/expert.txt",
        "E:/hpl_projects/unity_projects/Klongdike/Assets/_Klondike/Asset/boards_d3/master.txt",
        "E:/hpl_projects/unity_projects/Klongdike/Assets/_Klondike/Asset/boards_d3/guru.txt",
      };
      var outputPaths = new string[] {
        "E:/hpl_projects/unity_projects/Klongdike/Assets/_Klondike/Asset/boards_d1/easy_encode.txt",
        "E:/hpl_projects/unity_projects/Klongdike/Assets/_Klondike/Asset/boards_d1/medium_encode.txt",
        "E:/hpl_projects/unity_projects/Klongdike/Assets/_Klondike/Asset/boards_d1/hard_encode.txt",
        "E:/hpl_projects/unity_projects/Klongdike/Assets/_Klondike/Asset/boards_d1/expert_encode.txt",
        "E:/hpl_projects/unity_projects/Klongdike/Assets/_Klondike/Asset/boards_d1/master_encode.txt",
        "E:/hpl_projects/unity_projects/Klongdike/Assets/_Klondike/Asset/boards_d1/guru_encode.txt",

        "E:/hpl_projects/unity_projects/Klongdike/Assets/_Klondike/Asset/boards_d3/easy_encode.txt",
        "E:/hpl_projects/unity_projects/Klongdike/Assets/_Klondike/Asset/boards_d3/medium_encode.txt",
        "E:/hpl_projects/unity_projects/Klongdike/Assets/_Klondike/Asset/boards_d3/hard_encode.txt",
        "E:/hpl_projects/unity_projects/Klongdike/Assets/_Klondike/Asset/boards_d3/expert_encode.txt",
        "E:/hpl_projects/unity_projects/Klongdike/Assets/_Klondike/Asset/boards_d3/master_encode.txt",
        "E:/hpl_projects/unity_projects/Klongdike/Assets/_Klondike/Asset/boards_d3/guru_encode.txt",
      };
      var task = new ConvertBoardTask();
      var encodeDecode  = new IndexMoveEncodeDecode();
      task.SetEncodeDecode(encodeDecode);
      
      for (var i = 0; i < inputPaths.Length; i++) {
        var inputPath = inputPaths[i];
        task.EncodeFile(inputPaths[i], outputPaths[i]);
      }
      Printer.print("encode complete");
    }

    public static void EnsureDecodeCorrect() {
      var task = new ConvertBoardTask();
      var encodeDecode  = new IndexMoveEncodeDecode();
      encodeDecode.SetIndexes(new int[]{
        14,13,12,16,40,42,1,6,10,40,28,12,48,22,16,15,28,3,28,32,51,16,30,13,36,39,6,24,27,14,19,42,49,44,38,26,20,24,42,8,28,12,7,23,15,42,13,27,6,32,48,11
      }, new int[]{
        0,34,47,50,35,51,32,0,36,29,30,48,21,38,15,3,35,41,46,4,12,19,3,39,9,7,50,46,26,31,17,47,18,8,41,14,49,40,43,21,44,42,24,51,33,11,2,29,27,9,43,16
      });
      task.SetEncodeDecode(encodeDecode);

      var encodeContent = File.ReadAllText("E:/hpl_projects/unity_projects/Klongdike/Assets/_Klondike/Asset/boards_d1/guru_encode.txt");
      var line1 = encodeContent.Split('\n') [0];
      var cipher = task.boardParser.Parse(line1);
      var origion = task.encodeDecode.ToOrigion(cipher);
      Printer.printArray(origion);
    }

    public static void EnsureDecodeBoard() {
      var task = new ConvertBoardTask();
      var encodeDecode  = new IndexMoveEncodeDecode();
      encodeDecode.SetIndexes(new int[]{
        14,13,12,16,40,42,1,6,10,40,28,12,48,22,16,15,28,3,28,32,51,16,30,13,36,39,6,24,27,14,19,42,49,44,38,26,20,24,42,8,28,12,7,23,15,42,13,27,6,32,48,11
      }, new int[]{
        0,34,47,50,35,51,32,0,36,29,30,48,21,38,15,3,35,41,46,4,12,19,3,39,9,7,50,46,26,31,17,47,18,8,41,14,49,40,43,21,44,42,24,51,33,11,2,29,27,9,43,16
      });
      task.SetEncodeDecode(encodeDecode);

      var line1 = "3|37|32|5|35|17|36|27|46|19|16|24|51|47|8|23|26|14|7|33|42|29|1|44|30|20|9|43|50|48|18|10|11|39|49|52|41|40|31|12|45|25|22|21|28|4|38|15|6|13|2|34";
      var cipher = task.boardParser.Parse(line1);
      var origion = task.encodeDecode.ToOrigion(cipher);
      Printer.printArray(origion);
    }

    IBoardEncodeDecode encodeDecode;

    IBoardParser boardParser = new VerticalLineParse();

    public void SetEncodeDecode(IBoardEncodeDecode encodeDecode){
      this.encodeDecode = encodeDecode;
    }

    public void EncodeFile(string inputPath, string outputPath) {
      File.WriteAllText(outputPath, EncodeContent(File.ReadAllText(inputPath)));
    }

    public string EncodeContent(string content) {
      var sbd = new StringBuilder();
      var lines = content.Split('\n');
      for (var i = 0; i < lines.Length - 1; i++) {
        sbd.Append(EncodeBoard(lines[i])).Append('\n');
      }
      sbd.Append(EncodeBoard(lines[lines.Length - 1]));
      return sbd.ToString();
    }

    public string EncodeBoard(string board) {
      return EncodeBoard(boardParser.Parse(board));
    }

    public string EncodeBoard(int[] board) {
      var psw = encodeDecode.ToCipher(board);
      var sbd = new StringBuilder();
      for (var i = 0; i < psw.Length - 1; i++) {
        sbd.Append(psw[i]).Append('|');
      }
      sbd.Append(psw[psw.Length - 1]);
      return sbd.ToString();
    }

    public class VerticalLineParse : IBoardParser {
      public int[] Parse(string board) {
        var numStrs = board.Split('|');
        var numInts = new int[numStrs.Length];
        for (var i = 0; i < numInts.Length; i++) {
          numInts[i] = int.Parse(numStrs[i]);
        }
        return numInts;
      }
    }

  }

}