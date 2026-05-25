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

    private Vector2Int specialPosition;
    private bool generateSpecial = false;
    private bool forceSpecialNextChunk = false;

    public int chunksAhead = 2; 
    private int lowestChunkGenerated = 0;

    [Header("Player")]
    public Transform player;

    [Header("Blocks")]
    public List<BlockData> blocks;

    [Header("Specials")]
    public GameObject shopPrefab;
    public GameObject minerPrefab; 
    public GameObject minerPanel;

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
    public void ForceNextChunkSpecial()
    {
        forceSpecialNextChunk = true;
    }

    void GenerateChunk(int chunkY)
    {
        GameObject chunkParent = new GameObject("Chunk_" + chunkY);
        chunkParent.transform.parent = transform;

        float startY = -chunkY * chunkHeight * blockSize;

        generateSpecial = forceSpecialNextChunk;

        if (generateSpecial)
        {
            forceSpecialNextChunk = false;
        }

        if (generateSpecial)
        {
            specialPosition = new Vector2Int(
                Random.Range(2, chunkWidth - 2),
                Random.Range(2, chunkHeight - 2)
            );
        }

        for (int y = 0; y < chunkHeight; y++)
        {
            for (int x = 0; x < chunkWidth; x++)
            {
                Vector2 position = new Vector2(
                    x * blockSize,
                    startY - (y * blockSize)
                );

                if (generateSpecial)
                {
                    int distX = Mathf.Abs(x - specialPosition.x);
                    int distY = Mathf.Abs(y - specialPosition.y);

                    if (distX <= 1 && distY <= 1)
                    {
                        continue;
                    }
                }

                GameObject block = GetRandomBlock();

                if (block != null)
                {
                    Instantiate(block, position, Quaternion.identity, chunkParent.transform);
                }
            }
        }

        // SPAWN DEL ESPECIAL (SOLO UNA VEZ)
        if (generateSpecial)
        {
            Vector2 spawnPos = new Vector2(
                specialPosition.x * blockSize,
                startY - (specialPosition.y * blockSize)
            );

            GameObject prefabToSpawn;

            if (Random.value < 0.5f)
            {
                prefabToSpawn = shopPrefab;
            }
            else
            {
                prefabToSpawn = minerPrefab;
            }

            GameObject spawnedObject = Instantiate(prefabToSpawn, spawnPos, Quaternion.identity, chunkParent.transform);
            MinerManager minerScript = spawnedObject.GetComponent<MinerManager>();

            if (minerScript != null)
            {
                minerScript.MinerButton = minerPanel;
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

