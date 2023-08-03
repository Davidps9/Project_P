using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteTerrain : MonoBehaviour
{
    public const float maxViewDist = 300f;
    public Transform viewer;
    public static Vector2 viewerPos;
    int chunkSize;
    int chunksVisibileOnViewDist;

    Dictionary<Vector2, TerrainChunk> terrainChunkDictionary = new Dictionary<Vector2, TerrainChunk>();

    private void Start()
    {
        chunkSize = MapGenerator.mapChunkSize - 1;
        chunksVisibileOnViewDist = Mathf.RoundToInt( maxViewDist / chunkSize);
    }
    public void Update()
    {
        viewerPos =  new Vector2(viewerPos.x, viewerPos.y);
        UpdateVisibleChunks();
    }

    void UpdateVisibleChunks()
    {
        int currentChunkCoordX = Mathf.RoundToInt(viewerPos.x / chunkSize);
        int currentChunkCoordY = Mathf.RoundToInt(viewerPos.y / chunkSize);

        for (int yOffset = -chunksVisibileOnViewDist; yOffset <= chunksVisibileOnViewDist; yOffset++)
        {
            for (int xOffset = -chunksVisibileOnViewDist; xOffset <= chunksVisibileOnViewDist; xOffset++)
            {
                Vector2 viewedChunkCoord = new Vector2(currentChunkCoordX + xOffset, currentChunkCoordY + yOffset);

                if(terrainChunkDictionary.ContainsKey(viewedChunkCoord))
                {
                    terrainChunkDictionary[viewedChunkCoord].UpdateChunk();
                }
                else
                {
                    terrainChunkDictionary.Add(viewedChunkCoord, new TerrainChunk(viewedChunkCoord,chunkSize));
                }

            }
        }
    }

    public class TerrainChunk
    {
        GameObject meshObject;
        Vector2 position;
        Bounds bounds;
        public TerrainChunk(Vector2 coord, int size)
        {
            bounds = new Bounds(position, Vector2.one * size);
            position = coord * size;
            Vector3 positionV3 = new Vector3(position.x,0,position.y);

            meshObject = GameObject.CreatePrimitive(PrimitiveType.Plane);
            meshObject.transform.position = positionV3;
            meshObject.transform.localScale = Vector3.one * size / 10f;
            SetVisible(false);
        }

        public void UpdateChunk()
        {
            float viewerDistanceFromNearestEdge = Mathf.Sqrt(bounds.SqrDistance(viewerPos));
            bool visible = viewerDistanceFromNearestEdge <= maxViewDist;
            SetVisible(visible);   
        }

        public void SetVisible(bool visible)
        {
            meshObject.SetActive(visible);
        }
    }
}
