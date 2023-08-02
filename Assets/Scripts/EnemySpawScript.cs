using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawScript : MonoBehaviour
{
    [SerializeField] EnemyClass[] enemys;
    [SerializeField] private float spawnRadius = 300f;
    [SerializeField] GameObject enemyParent;
    [SerializeField] private Biome LocalBiome;
    // Start is called before the first frame update
    void Start()
    {
        foreach (EnemyClass enemyClass in enemys)
        {
            foreach (Enemy enemy in enemyClass.enemys)
            {
                foreach (Biome biome in enemy.biomes)
                {
                    if (LocalBiome == biome)
                    {
                        Vector3 spawnpos = new Vector3(Random.Range(-spawnRadius, spawnRadius), 0, Random.Range(-spawnRadius, spawnRadius));
                        GameObject parent = Instantiate(enemyParent, spawnpos, Quaternion.identity);
                        GameObject enemyInstantiation = Instantiate(enemy.model_prefab, spawnpos, Quaternion.identity);
                        enemyInstantiation.transform.parent = parent.transform;
                        enemyParent.name = enemy.name;
                    }
                }
            }
         

        }
    }

   
}
