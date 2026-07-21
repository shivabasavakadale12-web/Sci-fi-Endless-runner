using System;
using UnityEngine;

public class coin : Collectable

{
    Scoremanager scoremanager;

    [SerializeField] int scorepoint = 1;
    [SerializeField] AudioSource CoinSound;
    public void Init(Scoremanager sm)
    {
        scoremanager = sm;
    }



    protected override void Collect()
    {
        scoremanager.increasescore(scorepoint);
        AudioSource.PlayClipAtPoint(CoinSound.clip, transform.position, scorepoint);
        Destroy(gameObject);
    }
}
