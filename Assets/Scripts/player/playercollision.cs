using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;
public class playercollision : MonoBehaviour
{

    [SerializeField] GameObject chunks;
    [SerializeField] Animator animator;

    [SerializeField] float cooldown = 1f;

    float cooldowntimer = 0f;

    const string starthit = "Hit";
    private void Start()
    {
        GetComponent<InputScript>().enabled = true;
        GetComponent<Collider>().enabled = true;    
    }

    private void Update()
    {
        cooldowntimer += Time.deltaTime;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (cooldowntimer < cooldown) return;


        Debug.Log(gameObject.name + " collided with " + collision.gameObject.name);
        GetComponent<InputScript>().enabled = false;
        LevelGeneration.instance.movespeed = 0f;
        LevelGeneration.instance.speedovertime = 0f;
        GetComponent<Collider>().enabled = false;
        animator.SetTrigger(starthit);
        cooldowntimer = 0f;
        Invoke("Invokedfor3sec", 3f);

    }

 void Invokedfor3sec()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
