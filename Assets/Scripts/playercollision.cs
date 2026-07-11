using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;
public class playercollision : MonoBehaviour
{

    [SerializeField] GameObject chunks;
    [SerializeField] GameObject player;

    private void Start()
    {
        GetComponent<InputScript>().enabled = true;
        GetComponent<Collider>().enabled = true;    
    }


    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(gameObject.name + " collided with " + collision.gameObject.name);
        GetComponent<InputScript>().enabled = false;
        LevelGeneration.instance.movespeed = 0f;
        LevelGeneration.instance.speedovertime = 0f;
        GetComponent<Collider>().enabled = false;
        player.GetComponent<Animator>().enabled = false;
        Invoke("Invokedfor3sec", 3f);

    }

 void Invokedfor3sec()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
