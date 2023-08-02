using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawScript : MonoBehaviour
{
    [SerializeField] EnemyClass dragons;
    [SerializeField] private float spawnRadius = 10f;
    [SerializeField] GameObject enemyParent;
    [SerializeField] private Biome LocalBiome;
    // Start is called before the first frame update
    void Start()
    {
        foreach (Enemy enemy in dragons.enemys)
        {
           foreach(Biome biome in enemy.biomes)
            {
                if (LocalBiome == biome)
                {
                    GameObject parent = Instantiate(enemyParent);
                    GameObject enemyInstantiation = Instantiate(enemy.model_prefab);
                    enemyInstantiation.transform.parent = parent.transform;
                    enemyParent.transform.position = new Vector3(Random.Range(-spawnRadius, spawnRadius), 0, Random.Range(-spawnRadius, spawnRadius));
                }
            }

        }
    }

   
}
