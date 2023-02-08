using System;
using UnityEngine;
using UnityEngine.UI;

namespace LiteNinja.GSK.Actions
{
  public class ProgressBar : MonoBehaviour, IProgressBar
  {
    [Header("Value")] 
    [SerializeField] private float _value;
    [SerializeField] private float _maxValue;
    [SerializeField] private float _minValue;

    [Header("References")] 
    [SerializeField] private Image _fillImage;

    [SerializeField] private RectTransform _background;


    public float Value
    {
      get => _value;
      set
      {
        _value = Mathf.Clamp(value, _minValue, _maxValue);
        Fill();
      }
    }

    private void Fill()
    {
      _fillImage.fillAmount = _value / _maxValue;
    }

    public float MaxValue
    {
      get => _maxValue;
      set
      {
        _maxValue = value;
        Value = _value;
      }
    }

    public float MinValue
    {
      get => _minValue;
      set
      {
        _minValue = value;
        Value = _value;
      }
    }

    public float Percentage
    {
      get => _value / _maxValue;
      set => _value = value * _maxValue;
    }


    private void Awake()
    {
      if (_fillImage == null)
      {
        throw new Exception("Fill is null");
      }

      if (_background == null)
      {
        throw new Exception("Background is null");
      }

      Value = _value;
    }
  }
}