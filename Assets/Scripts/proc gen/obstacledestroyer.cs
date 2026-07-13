using UnityEngine;

public class obstacledestroyer : MonoBehaviour
{
   const string obstacletag = "Obstacle";

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(obstacletag))
        {
            Destroy(other.gameObject);
        }

    }
}
