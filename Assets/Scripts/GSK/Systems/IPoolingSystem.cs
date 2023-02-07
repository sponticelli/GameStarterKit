using LiteNinja.Pooling;
using UnityEngine;

namespace LiteNinja.GSK.Systems
{
  public interface IPoolingSystem : ISystem
  {
    /// <summary>
    /// Spawns a new instance of the prefab.
    /// </summary>
    /// <param name="prefab">The prefab to be instantiated.</param>
    /// <param name="initialPoolSize">The initial pool size for the prefab.</param>
    /// <returns>A new instance of the prefab.</returns>
    public GameObject Spawn(GameObject prefab, int initialPoolSize = 5) ;

    /// <summary>
    /// Spawns a new instance of the prefab at the specified position and rotation.
    /// </summary>
    /// <param name="prefab">The prefab to be instantiated.</param>
    /// <param name="position">The position for the instantiated prefab.</param>
    /// <param name="rotation">The rotation for the instantiated prefab.</param>
    /// <param name="initialPoolSize">The initial pool size for the prefab.</param>
    /// <returns>A new instance of the prefab.</returns>
    public GameObject Spawn(GameObject prefab,
      Vector3 position,
      Quaternion rotation,
      int initialPoolSize = 5);
    
    /// <summary>
    /// Spawns a new instance of the prefab of type `T`.
    /// </summary>
    /// <typeparam name="T">The type of the prefab.</typeparam>
    /// <param name="prefab">The prefab to be instantiated.</param>
    /// <param name="initialPoolSize">The initial pool size for the prefab.</param>
    /// <returns>A new instance of the prefab.</returns>
    public  T Spawn<T>(T prefab, int initialPoolSize = 5) where T : Component;
    
    /// <summary>
    /// Spawns a new instance of the prefab of type `T` at the specified position and rotation.
    /// </summary>
    /// <typeparam name="T">The type of the prefab.</typeparam>
    /// <param name="prefab">The prefab to be instantiated.</param>
    /// <param name="position">The position for the instantiated prefab.</param>
    /// <param name="rotation">The rotation for the instantiated prefab.</param>
    /// <param name="initialPoolSize">The initial pool size for the prefab.</param>
    /// <returns>A new instance of the prefab.</returns>
    public  T Spawn<T>(T prefab,
      Vector3 position,
      Quaternion rotation,
      int initialPoolSize = 5) where T : Component;

    /// <summary>
    /// Despawns the instance of the prefab.
    /// </summary>
    /// <param name="prefab">The prefab that the instance belongs to.</param>
    /// <param name="instance">The instance to be despawned.</param>
    public void Despawn(GameObject prefab, GameObject instance);
    
    /// <summary>
    /// Despawns the instance of the prefab of type `T`.
    /// </summary>
    /// <typeparam name="T">The type of the prefab.</typeparam>
    /// <param name="prefab">The prefab that the instance belongs to.</param>
    /// <param name="instance">The instance to be despawned.</param>
    public void Despawn<T>(T prefab, T instance) where T : Component;
    
    /// <summary>
    /// Despawn a game object using a GODespawner component.
    /// </summary>
    /// <param name="instance">The GODespawner component attached to the game object to despawn.</param>
    public  void Despawn(GODespawner instance);
    
    /// <summary>
    /// Fill a pool with the specified number of instances of a prefab.
    /// </summary>
    /// <param name="prefab">The prefab to fill the pool with.</param>
    /// <param name="target">The number of instances to have in the pool after the method is called.</param>
    public void Fill(GameObject prefab, int target);
    
    /// <summary>
    /// Create a specified number of instances of a prefab.
    /// </summary>
    /// <param name="prefab">The prefab to create instances of.</param>
    /// <param name="amount">The number of instances to create.</param>
    public void CreateObjects(GameObject prefab, int amount);
    
    /// <summary>
    /// Create a specified number of instances of a component.
    /// </summary>
    /// <param name="prefab">The component to create instances of.</param>
    /// <param name="amount">The number of instances to create.</param>
    public void CreateObjects(Component prefab, int amount);
        
    /// <summary>
    /// Purge all pools managed by the PoolManager.
    /// </summary>
    public void Purge();
  }
}