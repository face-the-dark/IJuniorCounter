using TMPro;
using UnityEngine;

public class CounterView : MonoBehaviour
{
    private const string ZeroNumber = "0";
    
    [SerializeField] private Counter _counter;
    [SerializeField] private InputHandler _inputHandler;
    [SerializeField] private TextMeshProUGUI _text;

    private void Start()
    {
        _text.text = ZeroNumber;
    }

    private void OnEnable()
    {
        _inputHandler.LeftMouseButtonPressed += StartIncrease;
        _inputHandler.LeftMouseButtonAgainPressed += StopIncrease;

        _counter.ValueChanged += DisplayValue;
    }
    
    private void OnDisable()
    {
        _inputHandler.LeftMouseButtonPressed -= StartIncrease;
        _inputHandler.LeftMouseButtonAgainPressed -= StopIncrease;
        
        _counter.ValueChanged -= DisplayValue;
    }

    private void StartIncrease()
    {
        _counter.StartIncrease();
    }

    private void StopIncrease()
    {
        _counter.StopIncrease();
    }

    private void DisplayValue(int value)
    {
        _text.text = value.ToString();
    }
}