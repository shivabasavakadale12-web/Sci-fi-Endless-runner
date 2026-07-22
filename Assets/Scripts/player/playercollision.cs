using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;
public class playercollision : MonoBehaviour
{
    [SerializeField] Timermanager timermanager;
    [SerializeField] AudioSource audio;
    [SerializeField] GameObject gameovertext;
    [SerializeField] GameObject chunks;
    [SerializeField] GameObject menu;
    [SerializeField] Animator animator;
    [SerializeField] AudioSource audioSource;

    [SerializeField] float cooldown = 1f;

    float cooldowntimer = 0f;
    const string starthit = "Hit";


    private void Start()
    {
        menu.gameObject.SetActive(false);
        audio.Play();
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
        animator.SetTrigger(starthit);
        audio.Stop();
        Time.timeScale = .4f;
        AudioSource.PlayClipAtPoint(audioSource.clip, transform.position);
        GetComponent<InputScript>().enabled = false;
        LevelGeneration.instance.movespeed = 0f;
        LevelGeneration.instance.speedovertime = 0f;
        GetComponent<Collider>().enabled = false;
        cooldowntimer = 0f;
        Invoke("Menupopup", 0.5f);
       

    }

    void Menupopup()
    {
        menu.gameObject.SetActive(true);
        gameovertext.SetActive(true);
    }
}
