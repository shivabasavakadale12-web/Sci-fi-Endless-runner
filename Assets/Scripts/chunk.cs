using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class chunk : MonoBehaviour
{
    [SerializeField] GameObject chunkprefabs;
    [SerializeField] GameObject Appleprefabs;
    [SerializeField] GameObject coinperfabs;
    [SerializeField] float[] spawner = { -2f, 0f, 2.2f };
    [SerializeField] float randomapplespawn = .3f;
    [SerializeField] float randomcoinspawn = .5f;

    [SerializeField] float spawncoinsep = 2f;

    [SerializeField] float spawnposition = -6.39f;

    List<int> availablelanes = new List<int> { 0, 1, 2 };

    private void Start()
    {
        spawnfence();
        spawnapple();
        spawncoin();
    }


    void spawnfence()
    { 

        int fencetospawn = Random.Range(0, 3);

       for (int i = 0; i < fencetospawn; i++)
        {
            int selectedlanes = spawnonlanes();

            Vector3 spawnfences = new Vector3(spawner[selectedlanes], -3.5f, transform.position.z);
            Instantiate(chunkprefabs, spawnfences, Quaternion.identity, this.transform);
        }


    }

    void spawnapple()
    {
        if (availablelanes.Count <= 0 || Random.Range(0f, 1f) > randomapplespawn) return;
        
        int selectedlanes = spawnonlanes();

        Vector3 spawnfences = new Vector3(spawner[selectedlanes], spawnposition, transform.position.z);
        Instantiate(Appleprefabs, spawnfences, Quaternion.identity, this.transform);

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
        Instantiate(coinperfabs, spawnfences, Quaternion.identity, this.transform);     
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
