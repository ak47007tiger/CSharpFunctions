using System;
using System.Collections.Generic;
using System.Text;

namespace UseCSharp.Klondike {
  public class KlondikeStatus {
    public List<int>[] foundations = new List<int>[4];
    public List<int>[] tableaus = new List<int>[7];
    public List<int> waste = new List<int> ();
    public List<int> stock = new List<int> ();
    public bool[] idToFace = new bool[52];

    public List<int>[] allList = new List<int>[4 + 7 + 2];

    public KlondikeStatus(){
      for (var i = 0; i < foundations.Length; i++)
      {
        foundations[i] = new List<int>();
      }
      for (var i = 0; i < tableaus.Length; i++)
      {
        tableaus[i] = new List<int>();
      }

      allList[0] = foundations[0];
      allList[1] = foundations[1];
      allList[2] = foundations[2];
      allList[3] = foundations[3];

      allList[4] = tableaus[0];
      allList[5] = tableaus[1];
      allList[6] = tableaus[2];
      allList[7] = tableaus[3];
      allList[8] = tableaus[4];
      allList[9] = tableaus[5];
      allList[10] = tableaus[6];

      allList[11] = waste;
      allList[12] = stock;
    }

    public void Save () {

    }

    public void Restore () {

    }

    public void FromBoard (int[] board) {
      var j = 0;
      for (var c = 0; c < 7; c++) {
        for (var i = 0; i < c + 1; i++) {
          tableaus[c].Add (board[j]);
          j++;
        }
      }
      while (j < board.Length) {
        stock.Add (board[j]);
        j++;
      }
      stock.Reverse ();
      
      for(var i = 0; i < idToFace.Length; i++){
        idToFace[i] = false;
      }
      for(var i = 0; i < 7; i++){
        SetFaceUp(GetTableauTop(i), true);
      }
    }

    public void FromGame (KlondikeRobot robot) {

    }

    public void SetGame (KlondikeRobot robot) {

    }

    public void Greedy () {
      //t to f
      //t_a to t_b then (new card in t_a || (t_a empty && k to t_a))
      //w || s to f
      //w to t_a then t_b to t_a ... then new card in t
      //f to t_a then t_b to t_a ... then new card in t
    }

    public List<CardTransfrom> ComputeAllCardTransform(){
      return null;
    }

    public KlondikeStatus GetNextStatus(CardTransfrom ctf){
      return null;
    }

    public List<KlondikeStatus> GetAllNextStatus(){
      var list = new List<KlondikeStatus>();
      //tableau to tableau makes card flip
      /**
      if below != null
       */
      //for each faceUp card below is back in table find a position to move
      for(var i = 0; i < 7; i++){
        var id = GetFirstFaceUp(tableaus[i]);
        if(IsCard(id)){
          var below = GetBelow(id);
          if(IsCard(below)){
            AddMove(list,id,FindReceiveTableau(id));
          }
        }
      }
      
      //tableau to tableau makes empty tableau
      /**
      if !K && faceUp && first card && current first K and empty < 4
       */
      if(GetEffectiveEmptyCount() < 4){
        for(var i = 0; i < 7; i++){
          var id = GetBottom(tableaus[i]);
          if(IsCard(id) && _Rank(id) < 13 && IsFaceUP(id)){
            AddMove(list,id,FindReceiveTableau(id));
          }
        }
      }

      //tableau to foundation
      //top card && card faceUp && card in tableau
      for(var i = 0; i < 7; i++){
        var id = GetTableauTop(i);
        if(IsCard(id)){
          AddMove(list, id, FindReceiveFoundation(id));
        }
      }

      //(waste or stock) to foundation
      //(waste or stock) to table
      for(var i = 0; i < waste.Count; i++){
        AddMove(list, waste[i], FindReceiveFoundation(waste[i]));
        AddMove(list, waste[i], FindReceiveTableau(waste[i]));
      }
      for(var i = 0; i < stock.Count; i++){
        AddMove(list, stock[i], FindReceiveFoundation(stock[i]));
        AddMove(list, stock[i], FindReceiveTableau(stock[i]));
      }
      
      //foundation to table
      for(var i = 0; i < 4; i++){
        var id = GetFoundationTop(i);
        if(IsCard(id)){
          AddMove(list,id,FindReceiveTableau(id));
        }
      }
      return list;
    }

    public bool IsWin{
      get{
        foreach(var tableau in tableaus){
          foreach(var id in tableau){
            if(IsBack(id)){
              return false;
            }
          }
        }
        return true;
      }
    }

    public string GetFaceBacksTableau(){
      var sbd = new StringBuilder();
      var count = 0;
      foreach(var tableau in tableaus){
        foreach(var id in tableau){
          if(IsBack(id)){
            count++;
            sbd.Append(_SuitC(id)).Append(_Rank(id)).Append(',');
          }
        }
      }
      // for(var id = 1; id <= 52; id++){
      //   if(IsBack(id)){
      //     count++;
      //     sbd.Append(_SuitC(id)).Append(_Rank(id)).Append(',');
      //   }
      // }
      sbd.Insert(0, count + ",");
      return sbd.ToString();
    }

    public void MoveTo (int id, List<int> oldParent, List<int> newParent) {
      if(BelongTableau(id)){
        var below = GetBelow(id);
        if(IsCard(below) && IsBack(below)){
          SetFaceUp(below, true);
        }
        var selfAndAboves = GetSelfAndAboves(id);
        foreach(var item in selfAndAboves){
          oldParent.Remove (item);
          newParent.Add (item);
        }
      }else{
        if(oldParent == stock){
          SetFaceUp(id, true);
        }
        oldParent.Remove (id);
        newParent.Add (id);
      }
    }

    void AddMove(List<KlondikeStatus> status, int id, List<int> np){
      if(np != null){
        status.Add(CopyMove(id, np));
      }
    }

    KlondikeStatus CopyMove(int id, List<int> newParent){
      var copy = Copy();
      copy.MoveTo(id, copy.GetParent(id), copy.GetParentWithIndex(GetParentIndex(newParent)));
      return copy;
    }

    public KlondikeStatus Copy () {
      var status = new KlondikeStatus ();
      for (int i = 0; i < idToFace.Length; i++)
      {
        status.idToFace[i] = idToFace[i];
      }
      // for (int i = 0; i < allList.Length; i++)
      // {
      //   status.allList[i].AddRange(allList[i]);
      // }
      Copy(foundations[0], status.foundations[0]);
      Copy(foundations[1], status.foundations[1]);
      Copy(foundations[2], status.foundations[2]);
      Copy(foundations[3], status.foundations[3]);

      Copy(tableaus[0], status.tableaus[0]);
      Copy(tableaus[1], status.tableaus[1]);
      Copy(tableaus[2], status.tableaus[2]);
      Copy(tableaus[3], status.tableaus[3]);
      Copy(tableaus[4], status.tableaus[4]);
      Copy(tableaus[5], status.tableaus[5]);
      Copy(tableaus[6], status.tableaus[6]);

      Copy(waste, status.waste);
      Copy(stock, status.stock);
      return status;
    }

    static void Copy(List<int> src, List<int> dst){
      for(var i = 0; i < src.Count; i++){
        dst.Add(src[i]);
      }
    }

    public static string GetToNextStatusOps(KlondikeStatus s1, KlondikeStatus s2){
      for(var id = 1; id < 53; id++){
        var p1 = s1.GetParent(id);
        var p2 = s2.GetParent(id);
        if(s1.GetParentIndex(p1) != s2.GetParentIndex(p2)){
          var card = id;
          if(s1.BelongTableau(p1)){
            card = s1.GetFirstFaceUp(p1);
          }
          return string.Format("{0},<{1},{2}> -> {3}, {4}", s1.GetParentName(p1), _SuitC(card),_RankStr(card), 
          s2.GetParentName(p2), s1.GetFaceBacksTableau());
        }
      }
      return string.Empty;
    }

    public int GetParentIndex(int id){
      return GetParentIndex(GetParent(id));
    }

    public string GetParentName(List<int> parent){
      return GetParentNameWithIndex(GetParentIndex(parent));
    }

    public string GetParentNameWithIndex(int index){
      return indexToName[index];
    }

    public string GetParentNameWithId(int id){
      return GetParentName(GetParent(id));
    }

    public int GetEffectiveEmptyCount(){
      var count = 0;
      for(var i = 0; i < 4; i++){
        var id = GetFoundationTop(i);
        if(IsCard(id) && _Rank(id) == 13){
          count++;
        }
      }
      for(var i = 0; i < 7; i++){
        var id = GetBottom(tableaus[i]);
        if(!IsCard(id) || _Rank(id) == 13){
          count++;
        }
      }
      return count;
    }

    public List<int> GetParentWithIndex(int index){
      return allList[index];
    }

    public int GetParentIndex(List<int> parent){
      for(var i = 0; i < allList.Length;i++){
        if(allList[i] == parent){
          return i;
        }
      }
      return -1;
    }

    public bool BelongTableau(List<int> p){
      foreach(var tableau in tableaus){
        if(p == tableau){
          return true;
        }
      }
      return false;
    }

    public bool BelongTableau(int id){
      return BelongTableau(GetParent(id));
    }

    public bool IsCard(int id){
      return id != -1;
      //return 1 <= id && id <=52;
    }

    public List<int> FindReceiveFoundation (int id) {
      for (var i = 0; i < 4; i++) {
        if (IsFoundationOrder (GetFoundationTop (i), id)) {
          return foundations[i];
        }
      }
      return null;
    }

    public List<int> FindReceiveTableau (int id) {
      for(var i = 0; i < 7; i++){
        if(IsTableauOrder(GetTableauTop(i), id)){
          return tableaus[i];
        }
      }
      return null;
    }

    public int GetFirstFaceUp(List<int> parent){
      if(parent.Count == 0) {
        return - 1;
      }
      for(var i = 0; i < parent.Count; i++){
        if(IsFaceUP(parent[i])){
          return parent[i];
        }
      }
      return -1;
    }

    public int GetBelow(int id){
      var p = GetParent(id);
      var belowIndex = p.IndexOf(id) - 1;
      if(belowIndex >= 0){
        return p[belowIndex];
      }
      return - 1;
    }

    public bool IsFaceUP(int id){
      return idToFace[id - 1];
    }

    public bool IsBack(int id){
      return !IsFaceUP(id);
    }

    public void SetFaceUp(int id, bool faceUp){
      if(!faceUp){
        Console.WriteLine(string.Format("{0},{1}", id, faceUp));
      }
      idToFace[id - 1] = faceUp;
    }

    public int GetAbove(int id){
      var p = GetParent(id);
      var aboveIndex = p.IndexOf(id) + 1;
      if(aboveIndex >= 0){
        return p[aboveIndex];
      }
      return -1;
    }

    public int[] GetAboves (int id) {
      return null;
    }

    public int[] GetSelfAndAboves (int id) {
      var parent = GetParent (id);
      var baseI = parent.IndexOf (id);
      var r = new int[parent.Count - baseI];
      for (var i = 0; i < r.Length; i++) {
        r[i] = parent[i + baseI];
      }
      return r;
    }

    public List<int> GetParent (int id) {
      foreach (var list in allList) {
        if (list.Contains (id))
          return list;
      }
      return null;
    }

    public int GetFoundationTop (int i) {
      return GetTop(foundations[i]);
    }

    public int GetTableauTop (int i) {
      return GetTop(tableaus[i]);
    }

    public int GetWastTop () {
      return GetTop(waste);
    }

    public int GetStockTop () {
      return GetTop(stock);
    }

    public int GetBottom(List<int> parent){
      if(parent.Count == 0){
        return -1;
      }
      return parent[0];
    }

    public int GetTop(List<int> parent){
      if(parent.Count == 0){
        return -1;
      }
      return parent[parent.Count - 1];
    }

    public bool IsEmpty(List<int> parent){
      return parent.Count == 0;
    }

    public static Suit[] idToSuit = new Suit[52];
    public static int[] idToRank = new int[52];

    public static string[] indexToName = new string[]{
      "f1",
      "f2",
      "f3",
      "f4",

      "t1",
      "t2",
      "t3",
      "t4",
      "t5",
      "t6",
      "t7",

      "w ",
      "s ",
    };

    static KlondikeStatus () {
      for (int i = 0; i < 4; i++) {
        var suit = (Suit) (i);
        for (int j = 0; j < 13; j++) {
          var index = i * 13 + j;
          idToSuit[index] = suit;
          idToRank[index] = j + 1;
        }
      }
    }

    public static int _Id(Suit s, int rank){
      return (int)s * 13 + rank;
    }

    public static Suit _Suit (int id) {
      return idToSuit[id - 1];
    }

    static char[] iToSuitC = new char[]{'c','d','h','s'};
    public static char _SuitC(int id){
      var i = (int)_Suit(id);
      return iToSuitC[i];
    }

    public static string DoubleNumber(int n){
      if(n < 10){
        return "0" + n;
      }
      return n.ToString();
    }

    public static int _Rank (int id) {
      return idToRank[id - 1];
    }

    public static string _RankStr (int id) {
      var rank = _Rank(id);
      if(rank < 10){
        return "0" + rank;
      }
      if(rank == 11){
        return "_J";
      }
      if(rank == 12){
        return "_Q";
      }
      if(rank == 13){
        return "_K";
      }
      return idToRank[id - 1].ToString();
    }

    public static bool IsTableauOrder (int top, int next) {
      if(top == -1){
        return _Rank(next) == 13;
      }
      var topSuit = _Suit (top);
      var nextSuit = _Suit (next);
      if (_Rank (top) == _Rank (next) + 1) {
        if (topSuit == Suit.HEARTS || topSuit == Suit.DIAMONDS) {
          return nextSuit == Suit.SPADES || nextSuit == Suit.CLUBS;
        }
        return nextSuit == Suit.HEARTS || nextSuit == Suit.DIAMONDS;
      }
      return false;
    }

    public static bool IsFoundationOrder (int top, int next) {
      if(top == -1){
        return _Rank(next) == 1;
      }
      return _Suit(top) == _Suit(next) && top + 1 == next;
    }

  }

  public class CardTransfrom{
    public int id;
    public bool faceUp;
    public bool flip;
    public ParentType from;
    public ParentType to;
  }

  public enum ParentType
  {
    None,
    F1, F2, F3, F4,
    Waste, Stock,
    T1, T2, T3, T4, T5, T6, T7
  }

  public class Game{
    public List<Card> waste;
    public List<Card> stock;
    public List<Card> tableaus;
    public List<Card> foundations;
    
    public Card WastTop{
      get{return null;}
    }
  }

  public class Card{
    public Game game;
    public int id;
    public bool faceUp;
    public ParentType parent;
    public Card top;
    public Card below;

    public void MoveTo(ParentType type){
      
    }
  }

}
