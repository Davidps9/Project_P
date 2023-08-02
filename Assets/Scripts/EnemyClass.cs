using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy database")]
public class EnemyClass : ScriptableObject
{
    public Enemy[] enemys;
}
[System.Serializable]

public class Enemy
{

    public GameObject model_prefab;
    public string name;
    [TextArea]
    public string description;
    public Biome[] biomes;
    public Stats stats;
}
[System.Serializable]

public class Stats
{
    public float damage;
    public float speed;
    public float health;
}
[System.Serializable]
public enum Biome
{
    mountain,
    desert,
    snow,
    forest,
    beach
}