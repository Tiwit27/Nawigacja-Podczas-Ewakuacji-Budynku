using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataBase : MonoBehaviour
{
    [SerializeField] public Table[] table = new Table[4];
}
[System.Serializable]
public class Table
{
    [SerializeField] int id;
    [SerializeField] public Vector3 location;
    [SerializeField] public float rotation;
}
