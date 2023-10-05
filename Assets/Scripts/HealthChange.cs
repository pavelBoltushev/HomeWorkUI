using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthChange : MonoBehaviour
{
    [SerializeField] private Slider _healthBar;
    [SerializeField] private Text _healthValueText;
    [SerializeField] private float _changeSpeed;

    private float _healthValue;

    private void Start()
    {
        _healthValue = 50;
        DisplayHealthValue();
    }    

    public void IncreaseHealthValueByTen()
    {
        float targetHealthValue = _healthValue + 10;

        if (targetHealthValue > 100)
            targetHealthValue = 100;

        StartCoroutine(ChangeHealthValue(targetHealthValue));
    }

    public void ReduceHealthValueByTen()
    {
        float targetHealthValue = _healthValue - 10;

        if (targetHealthValue < 0)
            targetHealthValue = 0;

        StartCoroutine(ChangeHealthValue(targetHealthValue));
    }
    
    private IEnumerator ChangeHealthValue(float targetHealthValue)
    {
        while (_healthValue != targetHealthValue)
        {
           _healthValue = Mathf.MoveTowards(_healthValue, targetHealthValue, _changeSpeed * Time.deltaTime);
            DisplayHealthValue();

            yield return null;
        }        
    }

    private void DisplayHealthValue()
    {
        _healthBar.value = _healthValue;
        _healthValueText.text = ((int)_healthValue).ToString();
    }
}
