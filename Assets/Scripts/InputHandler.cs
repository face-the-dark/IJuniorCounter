using System;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    private const int Button = 0;
    
    private bool _isButtonAgainPressed;
    
    public event Action ButtonPressed;
    public event Action ButtonAgainPressed;
    
    private void Update()
    {
        if (Input.GetMouseButtonDown(Button))
        {
            if (_isButtonAgainPressed)
            {
                ButtonAgainPressed?.Invoke();
                _isButtonAgainPressed = false;
            }
            else
            {
                ButtonPressed?.Invoke();
                _isButtonAgainPressed = true;
            }
        }
    }
}
