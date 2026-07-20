using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class chunk : MonoBehaviour
{
    [Header("Game Objects")]
    [SerializeField] GameObject chunkprefabs;
    [SerializeField] GameObject Appleprefabs;
    [SerializeField] GameObject coinperfabs;

    [Header("spawners")]
    [Tooltip("do not change unless worth changing yup lets go")]
    [SerializeField] float[] spawner = { -2f, 0f, 2f };
    [SerializeField] float randomapplespawn = .1f;
    [SerializeField] float randomcoinspawn = .5f;

    [SerializeField] float spawncoinsep = 2f;

    [SerializeField] float spawnposition = -6.39f;

    List<int> availablelanes = new List<int> { 0, 1, 2 };


    LevelGeneration levelGeneration;
    Scoremanager scoremanager;
    private void Start()
    {
        spawnfence();
        spawnapple();
        spawncoin();
    }

    public void Init(LevelGeneration levelGeneration, Scoremanager sm)
    {
        this.levelGeneration = levelGeneration;
        scoremanager = sm;

    }

    void spawnfence()
    { 

        int fencetospawn = Random.Range(0, 3);

       for (int i = 0; i < fencetospawn; i++)
        {
            int selectedlanes = spawnonlanes();

            Vector3 spawnfences = new Vector3(spawner[selectedlanes], -3.5f, transform.position.z + 1f);
            Instantiate(chunkprefabs, spawnfences, Quaternion.identity, this.transform);
        }


    }

    void spawnapple()
    {
        if (availablelanes.Count <= 0 || Random.Range(0f, 1f) > randomapplespawn) return;
        
        int selectedlanes = spawnonlanes();

        Vector3 spawnfences = new Vector3(spawner[selectedlanes], spawnposition, transform.position.z);
        apple newapple = Instantiate(Appleprefabs, spawnfences, Quaternion.identity, this.transform).GetComponent<apple>();
        newapple.Init(levelGeneration);

    }

    void spawncoin()
    {
        if (availablelanes.Count <= 0 || Random.Range(0f, 1f) > randomcoinspawn) return;
        int selectedlanes = spawnonlanes();

        int maxcoinspawn = 6;
        int coinstospawn = Random.Range(1, maxcoinspawn);

        float zposition = transform.position.z + (spawncoinsep * 2f);

        for (int i = 0;i < coinstospawn; i++)
        {
       float spawnz = zposition - (i * spawncoinsep);
        Vector3 spawnfences = new Vector3(spawner[selectedlanes],spawnposition, spawnz);
        coin newcoin = Instantiate(coinperfabs, spawnfences, Quaternion.identity, this.transform).GetComponent<coin>();
            newcoin.Init(scoremanager);  
        }
          
    }

    int spawnonlanes()
    {
        int lanesindex = Random.Range(0, availablelanes.Count);
        int selectedlanes = availablelanes[lanesindex];
        availablelanes.RemoveAt(lanesindex);
        return selectedlanes;
    }
}
