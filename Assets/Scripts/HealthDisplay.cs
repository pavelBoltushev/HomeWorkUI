using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private Slider _healthBar;
    [SerializeField] private Text _healthValueText;

    private void Update()
    {
        DisplayHealthValue();
    }

    private void DisplayHealthValue()
    {
        _healthBar.value = _health.Value;
        _healthValueText.text = ((int)_health.Value).ToString();
    }
}
