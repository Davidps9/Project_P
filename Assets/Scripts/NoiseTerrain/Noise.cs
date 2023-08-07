using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public static class Noise 
{
    public enum NormalizeMode { Local, Global };

    public static float[,] GenerateNoiseMap(int map_width, int map_height, int seed,float scale, int octaves, float persistance, float lacunarity, Vector2 offset, NormalizeMode normalizeMode)
    {
        float[,] noiseMap = new float[map_width, map_height];

        System.Random rand = new System.Random(seed);
        Vector2[] octavesOffset = new Vector2[octaves];


        float frequency = 1;
        float amplitude = 1;
        float maxPossibleHeight = 0;

        for (int i = 0; i < octaves; i++)
        {
            float offsetX = rand.Next(-100000,100000) + offset.x;
            float offsetY = rand.Next(-100000,100000) - offset.y;
            octavesOffset[i] = new Vector2(offsetX, offsetY);
            maxPossibleHeight += amplitude;
            amplitude *= persistance;

        }

        if (scale <= 0)
        {
            scale = 0.0001f;

        }

        float maxNoiseHeight = float.MinValue;
        float minNoiseHieght = float.MaxValue;

        float halfWidth = map_width / 2f;
        float halfHeight = map_height / 2f;
        for (int y = 0; y < map_height; y++)
        {
            for (int x = 0; x < map_width; x++)
            {
                frequency = 1;
                amplitude = 1;
                float noiseHeight = 0;
                for (int i = 0; i < octaves; i++)
                {

                    float sampleX = (x - halfWidth + octavesOffset[i].x) / scale * frequency ;
                    float sampleY = (y - halfHeight + octavesOffset[i].y) / scale * frequency ;

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
                if (normalizeMode == NormalizeMode.Local)
                {
                    noiseMap[x, y] = Mathf.InverseLerp(minNoiseHieght, maxNoiseHeight, noiseMap[x, y]);

                }
                else
                {
                    float normalizedHeight = (noiseMap[x, y] + 1f)/ ( maxPossibleHeight / 0.9f);
                    noiseMap[x, y] = Mathf.Clamp(normalizedHeight,0,int.MaxValue);
                }
            }
        }
        return noiseMap;    
    }
}
