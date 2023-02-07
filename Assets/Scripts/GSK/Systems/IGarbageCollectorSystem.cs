namespace LiteNinja.GSK.Systems
{
  public interface IGarbageCollectorSystem : ISystem
  {
    /// <summary>
    /// Call this method to collect garbage.
    /// </summary>
    void Collect();
    
    /// <summary>
    /// Call this method to unload unused assets.
    /// </summary>
    void UnloadUnusedAssets();
  }
}