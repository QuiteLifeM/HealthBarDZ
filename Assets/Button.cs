using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Button : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Slider _smoothSlider;
    [SerializeField] private float _currentHealth;

    private float _heal = 10f;
    private float _attackDamage = 10f;
    private float _maxLimit = 100f;
    private float _minLimit = 0f;
    private string _limit = "/100";
    private float _speed = 5f;
    private bool _isHealed;
    private bool _isAttack;
    private Coroutine _coroutine;

    public TMP_Text text;

    private void Awake()
    {
        _slider.value = _currentHealth;
        _smoothSlider.value = _currentHealth;
        text.text = _currentHealth.ToString() + _limit;
    }

    private void OnButtonClickHeal()
    {
        _isHealed = true;
        SetValueTextAndSlider();
        ChangeSmooth();
    }

    private void OnButtonClickAttack()
    {
        _isAttack = true;
        SetValueTextAndSlider();
        ChangeSmooth();
    }

    private void ChangeSmooth()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(ChangeSmoothValue());
    }

    private void SetValueTextAndSlider()
    {
        if (_currentHealth > _minLimit && _currentHealth <= _maxLimit)
        {
            if (_isHealed == true)
            {
                _currentHealth += _heal;
                string currentHealthStr = _currentHealth.ToString();
                text.text = currentHealthStr + _limit;
                _slider.value += _heal;
                _isHealed = false;
            }

            if (_isAttack == true)
            {
                _currentHealth -= _attackDamage;
                string currentHealthStr = _currentHealth.ToString();
                text.text = currentHealthStr + _limit;
                _slider.value -= _attackDamage;
                _isAttack = false;
            }
        }
    }

    private IEnumerator ChangeSmoothValue()
    {
        while (_smoothSlider.value != _currentHealth)
        {
            _smoothSlider.value = Mathf.MoveTowards(_smoothSlider.value, _currentHealth, _speed * Time.deltaTime);
            yield return null;
        }
    }
}
