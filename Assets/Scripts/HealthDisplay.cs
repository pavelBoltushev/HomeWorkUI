using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private Slider _healthBar;
    [SerializeField] private Text _healthValueText;
    [SerializeField] private float _changeSpeed;

    private float _displayedValue;
    private bool _isCoroutineInProgress;

    private void Start()
    {
        SetDisplayedValue(_health.Value);
    }

    public void StartChangeDisplayedValue()
    {
        if (_isCoroutineInProgress == false)        
            StartCoroutine(ChangeDisplayedValue());        
    }

    private IEnumerator ChangeDisplayedValue()
    {
        _isCoroutineInProgress = true;

        while (_displayedValue != _health.Value)
        {
            SetDisplayedValue(Mathf.MoveTowards(_displayedValue, _health.Value, _changeSpeed * Time.deltaTime));
            yield return null;
        }

        _isCoroutineInProgress = false;
    }

    private void SetDisplayedValue(float value)
    {
        _displayedValue = value;
        _healthBar.value = _displayedValue;
        _healthValueText.text = ((int)_displayedValue).ToString();
    }    
}
