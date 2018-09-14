namespace CSharpFunctions{
  public class TestNullAction : TestBehaviour{
    public System.Action action;
    public event System.Action eventAction;

    public void Test1(){
      Printf(action == null);//true
      Printf('\n');

      Printf(eventAction == null);//true
      Printf('\n');

      action += Test2;
      Printf(action == null);//false
      Printf('\n');

      action -= Test2;
      Printf(action == null);//true
      Printf('\n');

      eventAction += Test2;
      Printf(eventAction == null);//false
      Printf('\n');

      eventAction -= Test2;
      Printf(eventAction == null);//true
      Printf('\n');
    }

    public void Test2(){

    }
  }
}