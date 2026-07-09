using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class chunk : MonoBehaviour
{
    [SerializeField] GameObject chunkprefabs;
    [SerializeField] float[] spawner = { -2f, 0f, 2.2f };


    private void Start()
    {
        spawnfence();
    }


    void spawnfence()
    { 
        List<int> availablelanes = new List<int> { 0, 1, 2 };

        int fencetospawn = Random.Range(0, 3);

       for (int i = 0; i < fencetospawn; i++)
        {    
            int lanesindex = Random.Range(0, availablelanes.Count);
            int selectedlanes = availablelanes[lanesindex];
            availablelanes.RemoveAt(lanesindex);


            Vector3 spawnfences = new Vector3(spawner[selectedlanes], -3.5f, transform.position.z);
           Instantiate(chunkprefabs, spawnfences, Quaternion.identity, this.transform);
        }


    }

}
