using UnityEngine;

public class ObjectMovement : MonoBehaviour, IMovable
{
    [SerializeField] private MeshRenderer _meshRenderer;
    private Vector3 _startPosition;
    private bool _isCollision;

    public void Move(Vector3 position)
    {
        transform.position = position;
    }

    public void OnSelected()
    {
        _meshRenderer.enabled = true;
        _startPosition = transform.position;
    }

    public void OnExit()
    {
        _meshRenderer.enabled = false;
    }
}
