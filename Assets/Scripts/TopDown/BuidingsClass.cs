using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu  (menuName = "Buildings")]
public class BuidingsClass : ScriptableObject
{
   public Buildings[] buildings;
}
[System.Serializable]
public class Buildings
{
    public string name;
    public GameObject prefab;
    public BuildingType buildingType;
    public Resource[] resource;
    public MeshRenderer basePrefabRenderer;
}


public enum BuildingType
{
    farming,
    recruiting,
    defense,
    living
}

public enum Resource
{
    gold,
    resource2,
    food
}

