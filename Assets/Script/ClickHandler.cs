using System;
using UnityEngine;

public class ClickHandler : MonoBehaviour
{
    private PlayerInput _playerInput;
    private float _timeClick;
    public static Action Click, Clamp, End;


    private void Start()
    {
        _playerInput = GetComponent<PlayerInput>();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Click?.Invoke();
        }
        else if (Input.GetMouseButton(0))
        {
            _timeClick += Time.deltaTime;
             Clamp?.Invoke();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            End?.Invoke();
            if (_timeClick <= 0.2f)
            {
                return;
            }
            
            _timeClick = 0;
        }
    }
}
