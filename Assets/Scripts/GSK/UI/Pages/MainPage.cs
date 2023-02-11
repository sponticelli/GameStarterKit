using UnityEngine;

namespace LiteNinja.GSK.UI
{
  public class MainPage : APage
  {
    protected override void OnDeactivated()
    {
      Debug.Log(gameObject.name + " deactivated");
    }

    protected override void OnActivated()
    {
      Debug.Log(gameObject.name + " activated");
    }
  }
}