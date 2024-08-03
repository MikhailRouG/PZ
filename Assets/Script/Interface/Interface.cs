using UnityEngine;
public interface IMovable
{
    void Move(Vector3 offset);
    void OnSubscribe();
    void OnUnsubscribe();

    bool MovementSatus();
}

public interface IShootable
{
}