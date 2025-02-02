using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] private GameObject objectToSpawn; 
    [SerializeField] private float spawnInterval = 1f; 
    [SerializeField] private float spawnRangeX = 8f; 
    [SerializeField] private float spawnHeight = 6f;

    private void Start()
    {
        StartCoroutine(SpawnObjects());
    }

    private System.Collections.IEnumerator SpawnObjects()
    {
        while (true)
        {
            float randomX = Random.Range(-spawnRangeX, spawnRangeX);
            Vector3 spawnPosition = new Vector3(randomX, spawnHeight, 0f);


            Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);

            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
