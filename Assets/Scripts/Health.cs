using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private UnityEvent OnValueChanged;

    public float Value { get; private set; }

    private void Start()
    {
        Value = 50;        
    }    

    public void ChangeValue(float changeMagnitude)
    {
        Value += changeMagnitude;

        if (Value > 100)
            Value = 100;

        if (Value < 0)
            Value = 0;

        OnValueChanged.Invoke();
    }            
}
