using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace UseCSharp.Klondike {
  public class KlondikeDifficultyComputer {

    StatusTree statusTree = new StatusTree();

    List<StatusNode> winPaths = new List<StatusNode>();

    int faild1Count = 0;
    int faild2Count = 0;

    int searchCount;

    public int ComputeDifficulty (int[] board) {
      return 0;
    }

    //search a win path from board
    //how to store board
    //how to print path
    public void CompletelySearch (int[] board) {
      searchCount = 0;
      statusTree.Clear();
      winPaths.Clear();

      var status = new KlondikeStatus ();
      status.FromBoard (board);
      statusTree.SetupRoot(status);

      SearchDepthFirst(statusTree.root);

      Console.WriteLine("searchCount: " + searchCount);
    }

    void SearchDepthFirst(StatusNode node){
      searchCount++;
      Console.WriteLine(string.Format("f1: {0}, f2: {1}, search:{2}", faild1Count, faild2Count, searchCount));
      if(winPaths.Count > 0){
        return;
      }
      /**
      in a node i know a status A
      find all card transform add to Ts
      for each T in Ts
        got a new status node B
        if B is win
          find a win path
        else if B is faild
          find a faild path
        else
          SearchDeepthFirst(B)
      search from A with Next T in Ts
       */
      // {
      //   var ctfs = node.status.ComputeAllCardTransform();
      //   foreach(var ctf in ctfs){
      //     var nextStatus = node.status.GetNextStatus(ctf);
      //     var nextNode = node.AddChild(nextStatus);
      //     if(nextStatus.IsWin){
      //       winPaths.Add(nextNode);
      //       Console.WriteLine("find a new win path, total:{0}", winPaths.Count);
      //     }else if(nextNode.IsFaildStatus){

      //     }else{
      //       SearchDepthFirst(nextNode);
      //     }
      //   }
      // }
      {
        var allNextStatus = node.status.GetAllNextStatus();
        if(allNextStatus.Count > 0){
          foreach(var nextStatus in allNextStatus){
            var nextNode = node.AddChild(nextStatus);
            if(nextStatus.IsWin){
              winPaths.Add(nextNode);
              Console.WriteLine("find a win path");
              SaveAWinToFile(nextNode.GetParentToCurrentOps());
            }else if(nextNode.IsFaildStatus){
              faild1Count++;
            }else{
              SearchDepthFirst(nextNode);
            }
          }
        }else{
          faild2Count++;
        }
      }
    }

    void SearchBreadthFirst(StatusNode node){
      
    }

    public void SaveAWinToFile(string content){
      File.WriteAllText("D:\\hpl\\klondike_dev\\win_path.txt", content);
    }

    public StatusNode TryMoveStatus (StatusNode node) {

      //tableau to tableau makes card flip
      //tableau to foundation
      //(waste or stock) to foundation
      //(waste or stock) to table
      //foundation to table

      //how to decide a status is win
      //if all tableau cards are faceup then win

      //how to decide a status is faild
      //if move many count but tableau still have back card

      //when should stop
      //1 win
      //2 faild
      return null;
    }
  }

  public class CardTransform {
    public StatusNode from;
    public StatusNode to;

  }

  public class StatusTree {
    public StatusNode root = new StatusNode();

    public void SetupRoot(KlondikeStatus status){
      root.status = status;
    }

    public void AddChild (KlondikeStatus status) {
      root.AddChild (status);
    }

    public List<StatusNode> AllLeafs () {
      return null;
    }

    public void Clear(){
      root.Clear();
    }
  }

  public class StatusNode {
    public StatusNode parent;
    public KlondikeStatus status;
    public List<StatusNode> children = new List<StatusNode> ();

    public bool IsRoot{get{return parent == null;}}

    public String GetParentToCurrentOps(){
      var listPath = new List<StatusNode>();
      var node = this;
      while(node != null){
        listPath.Add(node);
        node = node.parent;
      }
      listPath.Reverse();
      var sbd = new StringBuilder();
      sbd.AppendFormat("ops:{0}", listPath.Count).AppendLine();
      for(var i = 0; i < listPath.Count - 1; i++){
        var one = listPath[i];
        var next = listPath[i+1];
        sbd.AppendFormat("{0}:{1}",KlondikeStatus.DoubleNumber(i + 1),KlondikeStatus.GetToNextStatusOps(one.status, next.status)).AppendLine();
      }
      return sbd.ToString();
    }

    public bool IsFaildStatus{
      get{
        return !status.IsWin && Height > 800;
      }
    }

    public int Height{
      get{
        var h = 1;
        var parent = this.parent;
        while(parent != null){
          h++;
          parent = parent.parent;
        }
        return h;
      }
    }

    public StatusNode AddChild (KlondikeStatus status) {
      var node = new StatusNode ();
      node.parent = this;
      node.status = status;
      children.Add (node);
      return node;
    }

    public void Clear(){
      children.Clear();
    }

    public void DeepthClear(){
      foreach(var child in children){
        child.DeepthClear();
      }
      children.Clear();
    }

  }

}
