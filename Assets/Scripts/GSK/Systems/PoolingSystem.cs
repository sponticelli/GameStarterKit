using LiteNinja.DI;
using LiteNinja.Pooling;
using UnityEngine;

namespace LiteNinja.GSK.Systems
{
  /// <summary>
  /// Wrap the PoolManager to make it injectable.
  /// It binds/unbinds itself to the DI container.
  /// </summary>
  [DefaultExecutionOrder(-100)]
  public class PoolingSystem : MonoSystem, IPoolingSystem
  {
    [SerializeField] private ScriptableDIContainer _container;
    

    //TODO Binding to DI container could be done in a more generic way. A specific class could be created for this. (also for AudioSystem)
    public override void OnLoadSystem()
    {
      _container.BindInstance<IPoolingSystem>(this);
    }

    public override void OnUnloadSystem()
    {
      _container.Unbind(typeof(IPoolingSystem));
    }

    public GameObject Spawn(GameObject prefab, int initialPoolSize = 5) => PoolManager.Spawn(prefab, initialPoolSize);

    public GameObject Spawn(GameObject prefab,
      Vector3 position,
      Quaternion rotation,
      int initialPoolSize = 5) =>
      PoolManager.Spawn(prefab, position, rotation, initialPoolSize);

    public T Spawn<T>(T prefab, int initialPoolSize = 5) where T : Component =>
      PoolManager.Spawn(prefab, initialPoolSize);

    public T Spawn<T>(T prefab,
      Vector3 position,
      Quaternion rotation,
      int initialPoolSize = 5) where T : Component =>
      PoolManager.Spawn(prefab, position, rotation, initialPoolSize);

    public void Despawn(GameObject prefab, GameObject instance) => PoolManager.Despawn(prefab, instance);
    public void Despawn<T>(T prefab, T instance) where T : Component => PoolManager.Despawn(prefab, instance);
    public void Despawn(GODespawner instance) => PoolManager.Despawn(instance);

    public void Fill(GameObject prefab, int target) => PoolManager.Fill(prefab, target);
    public void CreateObjects(GameObject prefab, int amount) => PoolManager.CreateObjects(prefab, amount);
    public void CreateObjects(Component prefab, int amount) => PoolManager.CreateObjects(prefab, amount);

    public void Purge() => PoolManager.PurgePools();
  }
}