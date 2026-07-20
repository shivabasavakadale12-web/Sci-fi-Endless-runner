using System;
using UnityEngine;

public class coin : Collectable

{
    Scoremanager scoremanager;

    [SerializeField] int scorepoint = 1;
    public void Init(Scoremanager sm)
    {
        scoremanager = sm;
    }



    protected override void Collect()
    {
        scoremanager.increasescore(scorepoint);
        Destroy(gameObject);
    }
}
