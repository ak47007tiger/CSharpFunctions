using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace CSharpFunctions{
  public class BoardConverter{

    public static readonly int[] indexSwaper_1 = new int[]{
      8,1,24,10,19,17,31,24,1,35,42,21,20,35,41,12,47,4,10,51,36,38,23,50,18,24,32,26,46,9,7,14,14,46,9,31,43,48,13,24,32,24,14,47,25,30,19,21,15,34,36,19
    };
    public static readonly int[] indexSwaper_2 = new int[]{
      5,42,4,21,29,25,43,47,36,5,30,43,28,28,7,26,26,9,20,50,43,38,19,11,24,27,24,40,4,10,10,11,25,39,9,23,42,40,1,17,4,17,39,26,46,22,18,49,23,45,47,5
    };

    Random random = new Random((int)(System.DateTime.Now.Ticks / 5));

    public int[] CreateIndex(int[] input){

      if(input == null) return input;

      var max = input.Length;
      for(var i = 0; i < input.Length; i++){
        input[i] = random.Next(max);
      }
      return input;
    }

    public int[] ConvertToPsw(int[] origion){
      return ConvertToPsw(origion, indexSwaper_1, indexSwaper_2);
    }

    public int[] ConvertToPsw(int[] origion, int[] indexes1, int[] indexes2){
      int[] psw = new int[origion.Length];
      System.Array.Copy(origion, psw, psw.Length);
      for(var i = 0; i < psw.Length; i++){
        var from = indexes1[i];
        var to = indexes2[i];
        var temp = psw[to];
        psw[to] = psw[from];
        psw[from] = temp;
      }
      return psw;
    }

    public int[] ConvertToOrigion(int[] psw){
      return ConvertToOrigion(psw, indexSwaper_1, indexSwaper_2);
    }

    public int[] ConvertToOrigion(int[] psw, int[] indexes1, int[] indexes2){
      int[] origion = new int[psw.Length];
      System.Array.Copy(psw, origion, origion.Length);
      for(var i = origion.Length - 1; i >= 0; i--){
        var from = indexes2[i];
        var to = indexes1[i];
        var temp = origion[to];
        origion[to] = origion[from];
        origion[from] = temp;
      }
      return origion;
    }

    

  }
}