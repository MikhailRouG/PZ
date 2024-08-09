using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ObjectDataSO : ScriptableObject
{
    public List<ObjectData> ObjectData;
}
[Serializable]
public class ObjectData
{
    [field: SerializeField] 
    public string Name { get; private set; }
    [field: SerializeField]
    public int ID { get; private set; }
    [field: SerializeField]
    public Vector2 Size { get; private set; }
    [field: SerializeField]
    public GameObject Prefab { get; private set; }
}