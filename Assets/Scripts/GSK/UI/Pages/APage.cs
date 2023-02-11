using UnityEngine;

namespace LiteNinja.GSK.UI
{
  public abstract class APage : MonoBehaviour, IPage
  {
    public void SetActive(bool active)
    {
      if (active)
      {
         OnActivated();
      }
      else
      {
        OnDeactivated();
      }
    }

    protected abstract void OnDeactivated();
    protected abstract void OnActivated();
  }
}