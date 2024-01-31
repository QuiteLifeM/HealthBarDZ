using System;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class HealthViewText : HealthView
{
    [SerializeField] protected TextMeshProUGUI tmpText;

    private void Start()
    {
        tmpText.text = $"{MaxHealth}/{MaxHealth}";
    }

    protected override void UpdateHealth(float targetValue)
    {
        tmpText.text = $"{targetValue}/{MaxHealth}"; 
    }
}
