using System;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    private bool _isLeftMouseButtonAgainPressed;
    
    public event Action LeftMouseButtonPressed;
    public event Action LeftMouseButtonAgainPressed;
    
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_isLeftMouseButtonAgainPressed)
            {
                LeftMouseButtonAgainPressed?.Invoke();
                _isLeftMouseButtonAgainPressed = false;
            }
            else
            {
                LeftMouseButtonPressed?.Invoke();
                _isLeftMouseButtonAgainPressed = true;
            }
        }
    }
}
