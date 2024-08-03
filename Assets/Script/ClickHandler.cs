using System;
using UnityEngine;

public class ClickHandler : MonoBehaviour
{
    private PlayerInput _playerInput;
    private float _timeClick;


    private void Start()
    {
        _playerInput = GetComponent<PlayerInput>();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _playerInput.Click();
        }
        else if (Input.GetMouseButton(0))
        {
            _timeClick += Time.deltaTime;
             _playerInput.Clamp();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            if (_timeClick <= 0.2f)
            {
                _playerInput.ClickEnd();
                return;
            }
             _playerInput.ClampEnd();
            _timeClick = 0;
        }
    }
}
