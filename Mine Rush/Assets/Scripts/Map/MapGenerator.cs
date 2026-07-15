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
    public PuntajeScript puntajeScript;
    public CameraMovement cameraMovement;

    private bool shopExists = false;
    private bool minerExists = false;

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

        if(puntajeScript.Score > 50)
        {
            blocks[0].probability = 70;
            blocks[1].probability = 15;
            blocks[2].probability = 7.5f;
            blocks[3].probability = 0;
            blocks[4].probability = 7.5f;
            cameraMovement.speed = -0.9f;

        }
        if (puntajeScript.Score > 100)
        {
            blocks[0].probability = 55;
            blocks[1].probability = 20;
            blocks[2].probability = 10;
            blocks[3].probability = 5;
            blocks[4].probability = 10;
            cameraMovement.speed = -1.1f;
        }
        if (puntajeScript.Score > 150)
        {
            blocks[0].probability = 40;
            blocks[1].probability = 20;
            blocks[2].probability = 15;
            blocks[3].probability = 10;
            blocks[4].probability = 15;
            cameraMovement.speed = -1.4f;
        }

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
    public void MinerDestroyed()
    {
        minerExists = false;
    }

    public void ShopDestroyed()
    {
        shopExists = false;
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

            GameObject prefabToSpawn = null;

            if (!shopExists && !minerExists)
            {
                // Ambos disponibles
                prefabToSpawn = Random.value < 0.5f ? shopPrefab : minerPrefab;
            }
            else if (!shopExists)
            {
                // Solo tienda disponible
                prefabToSpawn = shopPrefab;
            }
            else if (!minerExists)
            {
                // Solo minero disponible
                prefabToSpawn = minerPrefab;
            }

            // Si ambos existen, no spawnea nada
            if (prefabToSpawn != null)
            {
                GameObject spawnedObject = Instantiate(
                    prefabToSpawn,
                    spawnPos,
                    Quaternion.identity,
                    chunkParent.transform
                );

                // Registrar existencia
                if (prefabToSpawn == shopPrefab)
                {
                    shopExists = true;
                }
                else if (prefabToSpawn == minerPrefab)
                {
                    minerExists = true;

                    MinerManager minerScript = spawnedObject.GetComponent<MinerManager>();

                    if (minerScript != null)
                    {
                        minerScript.MinerButton = minerPanel;
                    }
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

