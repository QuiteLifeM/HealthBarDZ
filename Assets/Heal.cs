using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Heal : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Slider _smoothSlider;
    [SerializeField] private float _currentHealth;

    private float _heal = 10f;
    private float _maxLimit = 100f;
    private float _minLimit = 0f;
    private string _limit = "/100";
    private float _speed = 5f;

    public TMP_Text text;

    private void Awake()
    {
        _slider.value = _currentHealth;
        _smoothSlider.value = _currentHealth;
        text.text = _currentHealth.ToString() + _limit;
    }

    public void OnButtonClick()
    {
        SetValueTextAndSlider();
        StartCoroutine(ChangeSmoothValue());
    }

    private void SetValueTextAndSlider()
    {
        if (_currentHealth > _minLimit && _currentHealth <= _maxLimit)
        {
            _currentHealth += _heal;
            string currentHealthStr = _currentHealth.ToString();
            text.text = currentHealthStr + _limit;
            _slider.value += _heal;
        }
    }

    private IEnumerator ChangeSmoothValue()
    {
        while (_smoothSlider.value != _currentHealth)
        {
            float _smoothCurrentHealth = _smoothSlider.value;
            float _targetSmoothHealth = _currentHealth;
            _smoothSlider.value = Mathf.MoveTowards(_smoothCurrentHealth, _targetSmoothHealth, _speed * Time.deltaTime);
            yield return null;
        }
    }
}
