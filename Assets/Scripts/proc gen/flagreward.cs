using UnityEngine;

public class flagreward : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag =="Player")
        {
            Debug.Log("Yooo reward unlocked");
        }
    }
}
