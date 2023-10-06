using System.Collections;
using UnityEngine;


public class Health : MonoBehaviour
{    
    [SerializeField] private float _changeSpeed;

    private float _targetValue;
    private bool _isCoroutineInProgress;

    public float Value { get; private set; }

    private void Start()
    {
        Value = 50;
        _targetValue = Value;
    }    

    public void StartChangeValue(float changeMagnitude)
    {
        _targetValue += changeMagnitude;

        if (_targetValue > 100)
            _targetValue = 100;

        if (_targetValue < 0)
            _targetValue = 0;

        if (_isCoroutineInProgress == false)
            StartCoroutine(ChangeValue());        
    }    
    
    private IEnumerator ChangeValue()
    {
        _isCoroutineInProgress = true;

        while (Value != _targetValue)
        {
           Value = Mathf.MoveTowards(Value, _targetValue, _changeSpeed * Time.deltaTime);
           yield return null;
        }

        _isCoroutineInProgress = false;
    }    
}
