using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private GameObject  _gridShader;
    private IMovable _gameObject;

    private void Start()
    {
        _gridShader.SetActive(false);
    }
    public void Click()
    {
        if (_gameObject != null)
        {
            _gameObject.OnUnsubscribe();
            _gridShader.SetActive(false);
            _gameObject = null;
        }
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject.TryGetComponent<IMovable>(out IMovable _object))
            {
                _gameObject = _object;
                _gameObject.OnSubscribe();
                _gridShader.SetActive(true);
            }
        }
    }

    public void Clamp()
    {
        if (_gameObject == null) return;
        RaycastHit hit2;
        Ray ray2 = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray2, out hit2, float.MaxValue, _groundLayer))
        {
           
            _gameObject.Move(hit2.point);
        }
    }

    public void ClampEnd()
    {
        if (_gameObject == null) return;
        _gameObject.OnUnsubscribe();
        _gridShader.SetActive(false);
    }

    public void ClickEnd()
    {
        if (_gameObject == null) return;
    }
}

