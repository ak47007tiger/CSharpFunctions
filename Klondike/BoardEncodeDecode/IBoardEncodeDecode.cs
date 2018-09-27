namespace CSharpFunctions.Klondike {
  public interface IBoardEncodeDecode{
    int[] ToCipher(int[] origion);
    int[] ToOrigion(int[] psw);
  }
}