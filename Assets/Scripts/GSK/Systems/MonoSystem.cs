using UnityEngine;

namespace LiteNinja.GSK.Systems
{
  public abstract class MonoSystem : MonoBehaviour,ISystem
  {
    
    protected virtual void Awake()
    {
      OnLoadSystem();
    }

    protected virtual void OnDestroy()
    {
      OnUnloadSystem();
    }
    
    public virtual void OnLoadSystem()
    {
    }

    public virtual void OnUnloadSystem()
    {
    }
  }
}