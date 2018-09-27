using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using AlgorithmForce.Searching;

namespace search_language{
  public class SearchLanguage{
    char[][] targets = new char[][]{
      "Language".ToCharArray(),"LanFormat".ToCharArray()
    };
    HashSet<string> keys = new HashSet<string>();

    public void Clear(){
      keys.Clear();
    }
    
    public void SearchDir(DirectoryInfo dir){
      var dirs = dir.GetDirectories();
      foreach(var item in dirs){
        SearchDir(item);
      }
      var files = dir.GetFiles();
      foreach(var file in files){
        SearchFile(file);
      }
    }

    public void SearchFile(FileInfo file){
      var txt = File.ReadAllText(file.FullName);
      foreach(var target in targets){
        var indexes = txt.IndexesOf(target);
        
      }
    }

  }
}
