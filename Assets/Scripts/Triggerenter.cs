using UnityEngine;
using UnityEngine.SceneManagement;
public class Triggerenter : MonoBehaviour
{
    public GameObject playerrig;
    public GameObject player;

    private void OnTriggerEnter(Collider other)
    {
        
        playerrig.GetComponent<InputScript>().enabled = false;
        LevelGeneration.instance.movespeed = 0f;
        playerrig.GetComponent<Collider>().enabled = false;
        player.GetComponent<Animator>().enabled = false;
        Invoke("Invokedfor3sec", 3f);

    }

    void Invokedfor3sec()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
