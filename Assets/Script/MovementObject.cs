using UnityEngine;

public class MovementObject : MonoBehaviour, IMovable
{
    [SerializeField] private MeshRenderer _shootDistanseObject;
    private bool _isMoving;
    private Grid _grid;
    [SerializeField] private Vector3 _gridOffset;

    private void Start()
    {
        _grid = FindFirstObjectByType<Grid>();
        Move(transform.position);
    }

    public void Move(Vector3 direction)
    {
        Vector3Int gridPosition = _grid.WorldToCell(direction);
        Vector3 pos = _grid.CellToWorld(gridPosition);
        Vector3 offset = pos + _gridOffset;
        transform.position = offset;
    }

    public void OnSubscribe()
    {
        _shootDistanseObject.enabled = true;
        _isMoving = true;
    }

    public void OnUnsubscribe()
    {
        _shootDistanseObject.enabled = false;
        _isMoving = false;
    }

    public bool MovementSatus() => _isMoving;
}
