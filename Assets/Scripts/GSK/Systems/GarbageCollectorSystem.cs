using UnityEngine;

namespace LiteNinja.GSK.Systems
{
  /// <summary>
  /// A class that periodically call the GarbageCollector and unload unused assets.
  /// _collectInterval specifies after how many seconds the GarbageCollector is called (<=0 to disable).
  /// _unloadUnusedAssets specifies the seconds before checking if  unused assets should be unloaded (<=0 to disable).
  /// </summary>
  public class GarbageCollectorSystem : MonoSystem, IGarbageCollectorSystem
  {
    [SerializeField] private float _collectInterval = 5f;
    [SerializeField] private  float _unloadInterval = 30f;
        
        
    private float _collectTimer = 0f;
    private float _unloadTimer = 0f;
        
    private void Update()
    {
      TryCollect();
      TryUnload();
    }

    private void TryUnload()
    {
      if (_unloadInterval <= 0f) return;
      _unloadTimer += Time.deltaTime;
      if (_unloadTimer >= _unloadInterval)
      {
        _unloadTimer = 0f;
        UnloadUnusedAssets();
      }
    }

    private void TryCollect()
    {
      if (_collectInterval <= 0f) return;
      _collectTimer += Time.deltaTime;
      if (_collectTimer >= _collectInterval)
      {
        _collectTimer = 0f;
        Collect();
      }
    }

    public void Collect()
    {
      System.GC.Collect();
    }
      
    public void UnloadUnusedAssets()
    {
      Resources.UnloadUnusedAssets();
    }
    
  }
}