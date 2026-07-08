using System.Collections;
using UnityEngine;

public class ObsticlesSpawners : MonoBehaviour
{
    [SerializeField] GameObject[] obstacle;
    [SerializeField] Transform obstacleparent; 
    [SerializeField] float waitforobstacle = 1f;

    
    void Start()
    {
        StartCoroutine(SpawnObstacles());
    }

    IEnumerator SpawnObstacles()
    {
        while (true)
        {
            yield return new WaitForSeconds(waitforobstacle);
            Instantiate(obstacle[Random.Range(0, obstacle.Length)], transform.position, Random.rotation, obstacleparent);

        }
    }
}
