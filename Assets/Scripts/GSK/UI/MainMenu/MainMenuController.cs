using System;
using LiteNinja.GSK.UI;
using UnityEngine;
using UnityEngine.EventSystems;

namespace GSK.UI
{
  public class MainMenuController : MonoBehaviour
  {
    [SerializeField] private PageScroller _pageScroller;
    
    [SerializeField] private int _buttonCount; //TODO Replece with button references
    [SerializeField] private RectTransform _buttonContainer;
    [SerializeField] private float _selectButtonWidthFactor = 1.1f;
    
    
    private float _buttonWidth;
    private float _selectButtonWidth;
    
    private void Awake()
    {
      CalculateButtonWidth();
      RegisterEvents();
    }
    
    private void OnDisable()
    {
      UnregisterEvents();
    }
    
    private void CalculateButtonWidth()
    {
      var totalWidth = _buttonContainer.rect.width;
      switch (_buttonCount)
      {
        case <= 0:
          throw new ArgumentException("Button count must be greater than 0");
        case 1:
          _buttonWidth = totalWidth;
          _selectButtonWidth = totalWidth;
          return;
      }

      _buttonWidth = totalWidth / _buttonCount;
      _selectButtonWidth = _buttonWidth * _selectButtonWidthFactor;
      _buttonWidth = (totalWidth - _selectButtonWidth)/(_buttonCount - 1);
      
      Debug.Log($"Button width: {_buttonWidth}, Select button width: {_selectButtonWidth}");
    }

    private void UnregisterEvents()
    {
      if (_pageScroller != null)
      {
        _pageScroller.OnPageChangedEvent -= OnPageChanged;
        _pageScroller.OnBeginDragEvent -= OnPageScrollerBeginDrag;
        _pageScroller.OnEndDragEvent -= OnEPageScrollerndDrag;
        _pageScroller.OnDragEvent -= OnPageScrollerDrag;
      }
    }


    private void RegisterEvents()
    {
      if (_pageScroller != null)
      {
        _pageScroller.OnPageChangedEvent += OnPageChanged;
        _pageScroller.OnBeginDragEvent += OnPageScrollerBeginDrag;
        _pageScroller.OnEndDragEvent += OnEPageScrollerndDrag;
        _pageScroller.OnDragEvent += OnPageScrollerDrag;
      }
    }

    private void OnPageScrollerDrag(PointerEventData eventdata)
    {
      // TODO: Implement
    }

    private void OnEPageScrollerndDrag(PointerEventData eventdata)
    {
      // TODO: Implement
    }

    private void OnPageScrollerBeginDrag(PointerEventData eventdata)
    {
      // TODO: Implement
    }

    private void OnPageChanged(int index)
    {
      // TODO: Implement
    }
  }
}