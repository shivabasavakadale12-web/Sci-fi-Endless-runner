using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;
public class playercollision : MonoBehaviour
{
    [SerializeField] Timermanager timermanager;
    [SerializeField] GameObject gameovertext;
    [SerializeField] GameObject chunks;
    [SerializeField] Animator animator;
    [SerializeField] float cooldown = 1f;

    float cooldowntimer = 0f;
    const string starthit = "Hit";


    private void Start()
    {
        gameovertext.SetActive(false);
        Time.timeScale = 1;
        GetComponent<InputScript>().enabled = true;
        GetComponent<Collider>().enabled = true;    
    }

    private void Update()
    {
        cooldowntimer += Time.deltaTime;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (!timermanager.GameOver) return; 
        if (cooldowntimer < cooldown) return;
        gameovertext.SetActive(true);
        Time.timeScale = .4f;
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
