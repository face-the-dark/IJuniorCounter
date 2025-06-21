using TMPro;
using UnityEngine;

public class CounterView : MonoBehaviour
{
    private const string ZeroNumber = "0";
    
    [SerializeField] private Counter _counter;
    [SerializeField] private TextMeshProUGUI _text;

    private void Start()
    {
        _text.text = ZeroNumber;
    }

    private void OnEnable()
    {
        _counter.ValueChanged += DisplayValue;
    }
    
    private void OnDisable()
    {
        _counter.ValueChanged -= DisplayValue;
    }

    private void DisplayValue(int value)
    {
        _text.text = value.ToString();
    }
}