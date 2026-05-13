using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BlockData
{
    public string name;
    public GameObject prefab;
    [Range(0f, 100f)]
    public float probability;
}

public class MapGenerator : MonoBehaviour
{
    [Header("Chunk Settings")]
    public int chunkWidth = 10;
    public int chunkHeight = 10;
    public float blockSize = 1f;

    public int chunksAhead = 2; 
    private int lowestChunkGenerated = 0;

    [Header("Player")]
    public Transform player;

    [Header("Blocks")]
    public List<BlockData> blocks;

    private int currentChunkY = 0;
    private Dictionary<int, GameObject> spawnedChunks = new Dictionary<int, GameObject>();


    void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            GenerateChunk(i);
            lowestChunkGenerated = i;
        }
    }

    void Update()
    {
        int playerChunkY = Mathf.FloorToInt(player.position.y / -(chunkHeight * blockSize));


        if (playerChunkY >= lowestChunkGenerated - chunksAhead)
        {
            GenerateChunk(lowestChunkGenerated + 1);
            lowestChunkGenerated++;
        }
    }

    void GenerateChunk(int chunkY)
    {
        GameObject chunkParent = new GameObject("Chunk_" + chunkY);
        chunkParent.transform.parent = transform;

        float startY = -chunkY * chunkHeight * blockSize;

        for (int y = 0; y < chunkHeight; y++)
        {
            for (int x = 0; x < chunkWidth; x++)
            {
                Vector2 position = new Vector2(
                    x * blockSize,
                    startY - (y * blockSize)
                );

                GameObject block = GetRandomBlock();

                if (block != null)
                {
                    Instantiate(block, position, Quaternion.identity, chunkParent.transform);
                }
            }
        }

        spawnedChunks.Add(chunkY, chunkParent);
    }

    void CleanupChunks(int playerChunkY)
    {
        List<int> toRemove = new List<int>();

        foreach (var chunk in spawnedChunks)
        {
            if (chunk.Key < playerChunkY - 2)
            {
                Destroy(chunk.Value);
                toRemove.Add(chunk.Key);
            }
        }

        foreach (int key in toRemove)
        {
            spawnedChunks.Remove(key);
        }
    }

    GameObject GetRandomBlock()
    {
        float total = 0f;

        foreach (var block in blocks)
            total += block.probability;

        float rand = Random.Range(0, total);
        float current = 0f;

        foreach (var block in blocks)
        {
            current += block.probability;
            if (rand <= current)
                return block.prefab;
        }

        return null;
    }
}
