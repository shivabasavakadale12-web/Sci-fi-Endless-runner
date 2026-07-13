using UnityEngine;

public class apple : Collectable
{

    LevelGeneration levelGeneration;

    [System.Obsolete]
    private void Start()
    {
        levelGeneration = FindObjectOfType<LevelGeneration>();

    }

    protected override void Collect()
    {
        Debug.Log("power up!");
        levelGeneration.flatformmovespeed(2f);
        Invoke("countdown", 10f);
        Destroy(gameObject);
    }

    public void countdown()
    {
       levelGeneration.flatformmovespeed(-2f);
    }
}
