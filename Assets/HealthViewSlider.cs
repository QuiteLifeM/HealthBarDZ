using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthViewSlider : HealthView
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Slider _smoothSlider;
    [SerializeField] private float _speed = 4f;

    private Coroutine _coroutine;
    

    private void Start()
    {
        _smoothSlider.maxValue = MaxHealth;
        _smoothSlider.value = MaxHealth;
        _slider.maxValue = MaxHealth;
        _slider.value = MaxHealth;
    }

    private IEnumerator ChangeSmoothSliderValue(float targetValue)
    {
        float tolerance = 0.1f;
        
        while (Math.Abs(_smoothSlider.value - targetValue) > tolerance)
        {
            _smoothSlider.value = Mathf.MoveTowards(_smoothSlider.value, targetValue, _speed * Time.deltaTime);
            
            yield return null;  
        }
    }
    
    protected override void UpdateHealth(float targetValue)
    {
        _slider.value = targetValue;
        
        if(_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(ChangeSmoothSliderValue(targetValue));
    }
}
