using System;
using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private int _increment = 1;
    [SerializeField] private float _delay = 0.5f;
    
    private int _value;

    public event Action<int> ValueChanged;

    public void StartIncrease()
    {
        StartCoroutine(nameof(Increase));
    }

    public void StopIncrease()
    {
        StopCoroutine(nameof(Increase));
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