using System;
using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private InputHandler _inputHandler;
    [SerializeField] private int _increment = 1;
    [SerializeField] private float _delay = 0.5f;
    
    private int _value;
    private Coroutine _coroutine;

    public event Action<int> ValueChanged;

    private void OnEnable()
    {
        _inputHandler.ButtonPressed += StartIncrease;
        _inputHandler.ButtonAgainPressed += StopIncrease;
    }

    private void OnDisable()
    {
        _inputHandler.ButtonPressed -= StartIncrease;
        _inputHandler.ButtonAgainPressed -= StopIncrease;
    }

    private void StartIncrease()
    {
        _coroutine = StartCoroutine(Increase());
    }

    private void StopIncrease()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }
    }

    private IEnumerator Increase()
    {
        WaitForSeconds wait = new WaitForSeconds(_delay);

        bool isIncrease = true;
        
        while (isIncrease)
        {
            _value += _increment;
            ValueChanged?.Invoke(_value);

            yield return wait;
        }
    }
}