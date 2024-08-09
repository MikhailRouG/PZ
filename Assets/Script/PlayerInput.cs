using System;
using UnityEditor;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private GameObject  _gridShader;
    [SerializeField] private Grid _grid;
    private IMovable _selectedObject;

    private void Start()
    {
        _gridShader.SetActive(false);
        ClickHandler.Click += Click;
        ClickHandler.Clamp += Clamp;
        ClickHandler.End += End;
    }
    private void Click()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject.TryGetComponent<IMovable>(out IMovable _object))
            {
                if (_selectedObject != _object && _selectedObject != null) _selectedObject.OnExit();
                 _object.OnSelected();
                _selectedObject = _object;
                _gridShader.SetActive(true);
            }
            else if (_selectedObject != null)
            {
                _selectedObject.OnExit();
                _selectedObject = null;
            }
        }
    }

    private void Clamp()
    {
        if (_selectedObject == null) return;
        RaycastHit hit2;
        Ray ray2 = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray2, out hit2, float.MaxValue, _groundLayer))
        {
            Vector3Int gridPosition = _grid.WorldToCell(hit2.point);
            Vector3 position = _grid.CellToWorld(gridPosition);
            _selectedObject.Move(position);
        }
    }

    private void End()
    {
        if (_selectedObject == null) return;
        _gridShader.SetActive(false);
    }

    private void ClickEnd()
    {
        if (_selectedObject == null) return;
    }
}

