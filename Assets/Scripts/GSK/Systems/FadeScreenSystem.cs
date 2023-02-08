using DG.Tweening;
using UnityEngine;

namespace LiteNinja.GSK.Systems
{
  public class FadeScreenSystem : MonoSystem, IFadeScreenSystem
  {
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private float _fadeDuration = 1f;
    
    public void FadeIn(float duration)
    {
      _canvasGroup.alpha = 0f;
      _canvasGroup.blocksRaycasts = true;
      _canvasGroup.interactable = true;
      _canvasGroup.enabled = true;
      _canvasGroup.DOFade(1f, duration);
    }

    public void FadeOut(float duration)
    {
      _canvasGroup.DOFade(0f, duration).OnComplete(() => DisableCanvasGroup(true));
    }

    public override void OnLoadSystem()
    {
      DisableCanvasGroup(false);
    }
    
    public override void OnUnloadSystem()
    {
      DisableCanvasGroup(false);
    }
    
    private void DisableCanvasGroup(bool enabled)
    {
      _canvasGroup.alpha = 0f;
      _canvasGroup.blocksRaycasts = false;
      _canvasGroup.interactable = false;
      _canvasGroup.enabled = enabled;
    }

  }
}