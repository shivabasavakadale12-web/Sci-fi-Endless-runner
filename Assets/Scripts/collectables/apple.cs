using UnityEngine;

public class apple : Collectable
{

    float speed = 4f;

    [SerializeField] AudioSource powerup;

    LevelGeneration levelGeneration;

    [System.Obsolete]
    public void Init(LevelGeneration Lg)
    {
        levelGeneration = Lg;
    }

    protected override void Collect()
    {
        
        levelGeneration.flatformmovespeed(2f);
        AudioSource.PlayClipAtPoint(powerup.clip, transform.position);
        Invoke(nameof(countdown), 10f);
        Destroy(gameObject);
    }

    public void countdown()
    {
       levelGeneration.flatformmovespeed(-speed);
    }
}
