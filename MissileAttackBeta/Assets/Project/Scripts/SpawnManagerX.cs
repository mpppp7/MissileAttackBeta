using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject[] objectPrefabs;
    private float spawnDelay = 0;
    private float spawnInterval = 1.5f;
    public int numberOfObjectsToSpawn = 8;

    private PlayerControllerX playerControllerScript;
    private int objectsSpawned = 0;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObjects", spawnDelay, spawnInterval);
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerControllerX>();
    }

    // Spawn obstacles
    void SpawnObjects()
    {
        // If the desired number of objects have been spawned, stop spawning
        if (objectsSpawned >= numberOfObjectsToSpawn)
        {
            CancelInvoke("SpawnObjects");
            return;
        }

        // Set random spawn location and random object index
        Vector3 spawnLocation = new Vector3(30, Random.Range(5, 14), 0);
        int index = Random.Range(0, objectPrefabs.Length);

        // If game is still active, spawn new object
        if (!playerControllerScript.gameOver)
        {
            Instantiate(objectPrefabs[index], spawnLocation, objectPrefabs[index].transform.rotation);
            objectsSpawned++;
        }
        else if (!playerControllerScript.gameWin)
        {
            Instantiate(objectPrefabs[index], spawnLocation, objectPrefabs[index].transform.rotation);
            objectsSpawned++;
        }
    }
}
