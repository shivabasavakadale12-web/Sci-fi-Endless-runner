using UnityEngine;

public class Collectable : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
    
      Debug.Log("Collectable collected by player!");
      Destroy(gameObject); 
        
    }
}
