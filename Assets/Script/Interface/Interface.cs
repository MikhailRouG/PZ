using UnityEngine;
public interface IMovable
{
    void Move(Vector3 position);
    void OnSelected();
    void OnExit();
}

public interface IShootable
{
}
public interface IEnemy
{

}
