using System;

public class MatRotate {
  public void Start() {

    var n = int.Parse(Console.ReadLine());

    var mat = new int[n, n];

    for (var c = 0; c < n; c++) {
      for (var r = 0; r < n; r++) {
        mat[c, r] = int.Parse(Console.ReadLine());
      }
    }

    for (var c = n - 1; c >= 0; c--) {
      for (var r = 0; r < n; r++) {
        Console.Write(mat[n - 1 - r, n - 1 - c]);
        Console.Write(' ');
      }
      Console.WriteLine();
    }

  }

}