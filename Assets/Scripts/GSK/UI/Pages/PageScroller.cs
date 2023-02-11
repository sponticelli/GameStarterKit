using System;
using DG.Tweening;
using LiteNinja.Common.Extensions;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

namespace LiteNinja.GSK.UI
{
  public class PageScroller : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
  {
    public delegate void DragEventHandler(PointerEventData eventData);
    public delegate void PageChangedEventHandler(int index);

    
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private APage[] _pages;
    [SerializeField] private int _startPageIndex;
    
    [Header("Drag Settings")]
    // Determines how much the page will move when dragging
    [SerializeField] private float _dragFactor = 0.5f; 
    // Determine if the page will move to the next page when the drag ends
    [SerializeField] private float _dragThreshold = 10f;
    

    public event DragEventHandler OnBeginDragEvent;
    public event DragEventHandler OnDragEvent;
    public event DragEventHandler OnEndDragEvent;
    public event PageChangedEventHandler OnPageChangedEvent;

 
    private RectTransform[] _pageRects;
    private int _currentPageIndex;
    private float _dragDelta;
    
    private void Awake()
    {
      Init();
    }
    
    private void Start()
    {
      ScrollToPage(_startPageIndex);
    }

    /// <summary>
    /// Initializes the pages and rect transforms
    /// </summary>
    private void Init()
    {
      _pageRects = new RectTransform[_pages.Length];
      for (var i = 0; i < _pages.Length; i++)
      {
        _pageRects[i] = _pages[i].rectTransform();
      }
    }

    /// <summary>
    /// Updates the position of the pages when dragging
    /// </summary>
    /// <param name="eventData">Pointer event data</param>
    public void OnDrag(PointerEventData eventData)
    {
      _dragDelta = (eventData.position.x - eventData.pressPosition.x) * _dragFactor;

      if (_currentPageIndex == 0 && _dragDelta > 0) return;
      if (_currentPageIndex == _pages.Length - 1 && _dragDelta < 0) return;
      
      foreach (var item in _pageRects)
      {
        var targetPosition = item.localPosition;
        targetPosition.x += _dragDelta;
        item.localPosition = targetPosition;
      }
      
      OnDragEvent?.Invoke(eventData);
    }
    
    /// <summary>
    /// Called when the user starts dragging the pages
    /// </summary>
    /// <param name="eventData">Pointer event data</param>
    public void OnBeginDrag(PointerEventData eventData)
    {
      _pages[_currentPageIndex].SetActive(false);
      OnBeginDragEvent?.Invoke(eventData);
    }

    /// <summary>
    /// Called when the user stops dragging the pages
    /// Calculates the delta between the current and press positions of the drag event
    /// Uses the delta to determine if the user has dragged far enough to move to the next or previous page
    /// Calls the ScrollToPage method to animate the movement of the pages to the next or previous page
    /// </summary>
    /// <param name="eventData">Pointer event data</param>
    public void OnEndDrag(PointerEventData eventData)
    {
      _dragDelta = (eventData.position.x - eventData.pressPosition.x) * _dragFactor;
      var targetPageIndex = _dragDelta > 0 ? _currentPageIndex  - 1 : _currentPageIndex + 1;
      if (Mathf.Abs(_dragDelta) < _dragThreshold) targetPageIndex = _currentPageIndex;
      ScrollToPage(targetPageIndex);
      OnEndDragEvent?.Invoke(eventData);
    }

    /// <summary>
    /// Animates the movement of the pages to the specified page, while disabling interactivity during the animation
    /// </summary>
    /// <param name="index">The index of the page to be scrolled to</param>
    public void ScrollToPage(int index)
    {
      if (index < 0 || index >= _pages.Length)
      {
        return;
      }
      _pages[_currentPageIndex].SetActive(false);
      _currentPageIndex = index;
      var distance = _pageRects[index].localPosition.x;
      if (distance == 0) return;

      _canvasGroup.interactable = false;
      foreach (var page in _pageRects)
      {
        var targetPosition = page.localPosition;
        targetPosition.x -= distance;
        DOTween.To(() => page.localPosition,
            x => page.localPosition = x,
            targetPosition, 0.5f).SetEase(Ease.OutCubic)
          .SetOptions(AxisConstraint.X);
      }
      _canvasGroup.interactable = true;
      _pages[_currentPageIndex].SetActive(true);
      
      OnPageChangedEvent?.Invoke(_currentPageIndex);
    }
  }
}