using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public event UnityAction ValueChanged;

    public float Value { get; private set; }

    private void Start()
    {
        Value = 50;        
    }    

    public void ChangeValue(float changeMagnitude)
    {        
        Value = Mathf.Clamp(Value + changeMagnitude, 0, 100);
        ValueChanged?.Invoke();
    }            
}
