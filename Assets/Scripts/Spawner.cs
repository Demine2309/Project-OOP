using System.Collections.Generic;
using UnityEngine;

// Nguyễn Như Cường - 20200076
public class Spawner : MonoBehaviour
{
    [Header("Set Object")]
    public List<GameObject> objectToSpawn = new List<GameObject>();

    public Vector3 cubeSize = new Vector3(10f, 10f, 10f);

    [Header("Set Time")]
    public float timeToSpawn;

    private float currentTimeSpawn;

    [Header("Is Random")]
    public bool isRandomized;

    // Start is called before the first frame update
    private void Start()
    {
        currentTimeSpawn = timeToSpawn;
        //UpdateTime();
    }

    private void Update()
    {
        UpdateTime();
    }

    // Update is called once per frame
    private void UpdateTime()
    {
        if (currentTimeSpawn > 0)
        {
            currentTimeSpawn -= Time.deltaTime;
        }
        else
        {
            SpawnObject();
            currentTimeSpawn = 2 * timeToSpawn;
        }
    }

    public void SpawnObject()
    {
        int index = isRandomized ? Random.Range(0, objectToSpawn.Count) : 0;

        Vector3 randomPos = new Vector3(Random.Range(-cubeSize.x / 2f, cubeSize.x / 2f),
                                        Random.Range(-cubeSize.y / 2f, cubeSize.y / 2f),
                                        0);
        Vector3 spawnPos = transform.position + randomPos;

        if (objectToSpawn.Count > 0)
        {
            Instantiate(objectToSpawn[index], spawnPos, Quaternion.identity);
        }

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;

        Gizmos.DrawWireCube(transform.position, cubeSize);
    }
}
