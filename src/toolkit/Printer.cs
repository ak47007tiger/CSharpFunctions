using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace CSharpFunctions.Toolkit {
  public class Printer {
    public static void print<T>(T t) {
      Console.WriteLine(t);
    }

    public static void printFromat(string format, params object[] objs) {
      Console.WriteLine(string.Format(format, objs));
    }

    public static void printArray<T>(T[] array) {
      for (int i = 0; i < array.Length - 1; i++) {
        Console.Write("{0},", array[i]);

      }
      print(array[array.Length - 1]);
    }
  }
}