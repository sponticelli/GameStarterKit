namespace LiteNinja.GSK.Systems
{
  public interface IFadeScreenSystem : ISystem
  {
    void FadeIn(float duration);
    void FadeOut(float duration);
  }
}