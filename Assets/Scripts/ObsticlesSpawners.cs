using System.Collections;
using UnityEngine;

public class ObsticlesSpawners : MonoBehaviour
{
    [SerializeField] GameObject[] obstacle;
    [SerializeField] Transform obstacleparent; 
    [SerializeField] float waitforobstacle = 1f;
    [SerializeField] float spawnWidth = 4f;

    
    void Start()
    {
        StartCoroutine(SpawnObstacles());
    }

    IEnumerator SpawnObstacles()
    {
        while (true)
        {
            Vector3 spawnpositon = new Vector3(Random.Range(-spawnWidth, spawnWidth), transform.position.y, transform.position.z);
            yield return new WaitForSeconds(waitforobstacle);
            Instantiate(obstacle[Random.Range(0, obstacle.Length)], spawnpositon, Random.rotation, obstacleparent);

        }
    }
}
