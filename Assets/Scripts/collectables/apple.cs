using UnityEngine;

public class apple : Collectable
{

    float speed = 4f;


    LevelGeneration levelGeneration;

    [System.Obsolete]
    private void Start()
    {
        levelGeneration = FindObjectOfType<LevelGeneration>();

    }

    protected override void Collect()
    {
        
        levelGeneration.flatformmovespeed(2f);
        Invoke(nameof(countdown), 10f);
        Destroy(gameObject);
    }

    public void countdown()
    {
       levelGeneration.flatformmovespeed(-speed);
    }
}
