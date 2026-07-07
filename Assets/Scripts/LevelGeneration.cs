using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour
{
    [SerializeField] GameObject platforms;
    [SerializeField] int platformlength = 12;
    [SerializeField] Transform platformparent;

    float platlength = 10f;
    float movespeed = 2f;
    float speedovertime = 0.01f;

   
    List<GameObject> platform= new List<GameObject>();


    private void Start()
    {
        spwnpz();

    }

    private void Update()
    {
        
        moveplatforms();  
    }

    private void spwnpz()
    {
        for (int i = 0; i < platformlength; i++)
        {
            spawnplateform();

        }
    }

    private void spawnplateform()
    {
        float spawnposz = calculateplatforms();

        Vector3 spwnz = new Vector3(transform.position.x, transform.position.y, spawnposz);
        GameObject newplatform = Instantiate(platforms, spwnz, Quaternion.identity);

        platform.Add(newplatform);
    }

    private float calculateplatforms()
    {
        float spawnposz;

        if (platform.Count == 0)
        {
            spawnposz = transform.position.z;
        }

        else
        {
            spawnposz = platform[platform.Count - 1].transform.position.z + platlength;
        }

        return spawnposz;

    }

    private void moveplatforms()
    {
        
        for (int i = 0; i < platform.Count; i++)
        { 

            GameObject currentplateform = platform[i];
            currentplateform.transform.Translate(-movespeed * (Time.deltaTime * transform.forward));
            movespeed += speedovertime * Time.deltaTime;

            if (currentplateform.transform.position.z < Camera.main.transform.position.z - platlength)
            {

                platform.Remove(currentplateform);
                Destroy(currentplateform);
               spawnplateform();


            }

          
        }

    }
}
