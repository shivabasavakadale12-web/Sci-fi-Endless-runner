using System;
using UnityEngine;

public class coin : Collectable

{
    Scoremanager scoremanager;

    [SerializeField] int scorepoint = 1;
    private void Start()
    {
        scoremanager = FindAnyObjectByType<Scoremanager>();
    }



    protected override void Collect()
    {
        scoremanager.increasescore(scorepoint);
        Destroy(gameObject);
    }
}
