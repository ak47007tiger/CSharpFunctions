using System.Text;
using System;
using CSharpFunctions.Toolkit;

namespace CSharpFunctions.Test {

  public class BoardConverterTest {

    public void Test2(){
      var boardConverter = new BoardConverter();
      var origion = boardConverter.CreateIndex(new int[52]);
      // var indexes1 = boardConverter.CreateIndex(new int[52]);
      // var indexes2 = boardConverter.CreateIndex(new int[52]);
      // Printer.printArray(indexes1);
      // Printer.printArray(indexes2);
      Printer.printArray(origion);
      var psw = boardConverter.ConvertToPsw(origion);
      Printer.printArray(psw);
      var pswToOrigion = boardConverter.ConvertToOrigion(psw);
      Printer.printArray(pswToOrigion);
    }

    public void Test1(){
      var boardConverter = new BoardConverter();
      Printer.printArray(boardConverter.CreateIndex(new int[52]));
      Printer.print('\n');
      Printer.printArray(boardConverter.CreateIndex(new int[52]));
      Printer.print('\n');

      var indexes1 = boardConverter.CreateIndex(new int[8]);
      Printer.printArray(indexes1);
      var indexes2 = boardConverter.CreateIndex(new int[8]);
      Printer.printArray(indexes2);
      Printer.print('\n');

      var origion = new int[] { 1, 2, 3, 4, 5, 6, 7, 8 };
      var psw = boardConverter.ConvertToPsw(origion, indexes1, indexes2);
      Printer.printArray(psw);
      var converted_origion = boardConverter.ConvertToOrigion(psw, indexes1, indexes2);
      Printer.printArray(converted_origion);
      Console.ReadLine();
    }

  }

}
