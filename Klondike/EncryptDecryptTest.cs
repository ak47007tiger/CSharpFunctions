namespace UseCSharp.Klondike {
  using System.Text;
  using System;

  public class EncryptDecryptTest {

    public void TestBase64() {
      var encryptDecrypt = new EncryptDecrypt();

      var enStr = encryptDecrypt.DESEncrypt("this is 0101010 111", "1234abcd", "qwer1234");
      Console.Write(enStr);
      var deStr = encryptDecrypt.DESDecrypt(enStr, "1234abcd", "qwer1234");
      Console.Write(deStr);
    }

    public void TestUtf8() {
      var encryptDecrypt = new EncryptDecrypt();
      var src = "this is 0101010 111";
      var key = "1234abcd";
      var vi = "qwer1234";
      var enByte = encryptDecrypt.EncryptBytes(
        Encoding.UTF8.GetBytes(src.ToCharArray()), key, vi);
      var deByte = encryptDecrypt.DecryptBytes(enByte, key, vi);
      Console.WriteLine(Encoding.UTF8.GetString(deByte));
    }

    public void CreateGameAsset(){
      var encryptDecrypt = new EncryptDecrypt();
      var src = "this is 0101010 111";
      var key = "1234abcd";
      var vi = "qwer1234";
      var enByte = encryptDecrypt.EncryptBytes(Encoding.UTF8.GetBytes(src.ToCharArray()), key, vi);
      var deByte = encryptDecrypt.DecryptBytes(enByte, key, vi);
      System.IO.File.WriteAllBytes("d:hpl/bytes_asset.txt", enByte);
    }

  }

}
