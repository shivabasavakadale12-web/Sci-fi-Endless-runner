using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public abstract class Collectable : MonoBehaviour
{
   const string playertag = "Player";

    float rotationSpeed = 100f;


    private void Update()
    {
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
        
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playertag))
        {
            Collect();
        }
       
    }

    protected abstract void Collect();
}
