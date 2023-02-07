using UnityEngine;

namespace LiteNinja.GSK.Actions
{
  public class DestroyAction : MonoBehaviour
  {
    public void Destroy()
    {
      Destroy(gameObject);
    }
  }
}