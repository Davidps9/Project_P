using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public static class Noise 
{
    public enum NormalizeMode { Local, Global };

    public static float[,] GenerateNoiseMap(int map_width, int map_height, int seed,float scale, int octaves, float persistance, float lacunarity, Vector2 offset)
    {


        System.Random rand = new System.Random(seed);
        Vector2[] octavesOffset = new Vector2[octaves];

        for (int i = 0; i < octaves; i++)
        {
            float offsetX = rand.Next(-100000,100000) + offset.x;
            float offsetY = rand.Next(-100000,100000) + offset.y;
            octavesOffset[i] = new Vector2(offsetX, offsetY);
        }

        float[,] noiseMap = new float[map_width, map_height];
        if (scale <= 0)
        {
            scale = 0.0001f;

        }

        float maxNoiseHeight = float.MinValue;
        float minNoiseHieght = float.MaxValue;

        float halfWidth = map_width / 2;
        float halfHeight = map_height / 2;
        for (int y = 0; y < map_height; y++)
        {
            for (int x = 0; x < map_width; x++)
            {
                float frequency = 1;
                float amplitude = 1;
                float noiseHeight = 0;
                for (int i = 0; i < octaves; i++)
                {

                    float sampleX = (x - halfWidth) / scale * frequency + octavesOffset[i].x;
                    float sampleY = (y - halfHeight) / scale * frequency + octavesOffset[i].y;

                    float perlinValue = Mathf.PerlinNoise(sampleX, sampleY) * 2 - 1 ;
                    noiseHeight += perlinValue * amplitude;

                    amplitude *= persistance;
                    frequency *= lacunarity;
                }
             
                if (noiseHeight > maxNoiseHeight)
                {

                    maxNoiseHeight = noiseHeight;
                }
                else if (noiseHeight < minNoiseHieght)
                {
                    minNoiseHieght = noiseHeight;
                }
                 noiseMap[x, y] = noiseHeight;
            }

        }

        for (int y = 0; y < map_height; y++)
        {
            for (int x = 0; x < map_width; x++)
            {


                noiseMap[x, y] = Mathf.InverseLerp(minNoiseHieght, maxNoiseHeight, noiseMap[x, y]);


            }
        }
        return noiseMap;    
    }
}
