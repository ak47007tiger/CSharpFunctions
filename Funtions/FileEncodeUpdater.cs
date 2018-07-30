using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCSharp.funtions {
  public class FileEncodeUpdater {
    public void UpdateDir(DirectoryInfo directory, Encoding from, Encoding to) {
      var dirs = directory.GetDirectories();
      foreach (var dir in dirs) {
        UpdateDir(dir, from, to);
      }
      var files = directory.GetFiles();
      foreach (var file in files) {
        if (file.Extension == ".cs") {
          UpdateFile(file, from, to);
        }
      }
    }

    public void UpdateFile(FileInfo file, Encoding from, Encoding to) {
      File.WriteAllText(file.FullName, File.ReadAllText(file.FullName, from), to);
    }
  }
}