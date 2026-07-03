using NUnit.Framework;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LevelGeneration : MonoBehaviour
{
    [SerializeField] GameObject plateforms;
    [SerializeField] int plateformlength = 12;
    [SerializeField] Transform plateformparent;

    float platelength = 10f;
    float movespeed = 2f;
    float speedovertime = 0.01f;

   
    List<GameObject> plateform= new List<GameObject>();


    private void Start()
    {
        spwnpz();

    }

    private void Update()
    {
        
        moveplateforms();
    }

    private void spwnpz()
    {
        for (int i = 0; i < plateformlength; i++)
        {
            spwanplateform();

        }
    }

    private void spwanplateform()
    {
        float spwanposz = calculateplateforms();

        Vector3 spwnz = new Vector3(transform.position.x, transform.position.y, spwanposz);
        GameObject newplateform = Instantiate(plateforms, spwnz, Quaternion.identity);

        plateform.Add(newplateform);
    }

    private float calculateplateforms()
    {
        float spwanposz;

        if (plateform.Count == 0)
        {
            spwanposz = transform.position.z;
        }

        else
        {
            spwanposz = plateform[plateform.Count - 1].transform.position.z + platelength;
        }

        return spwanposz;

    }

    private void moveplateforms()
    {
        
        for (int i = 0; i < plateform.Count; i++)
        { 

            GameObject currentplateform = plateform[i];
            currentplateform.transform.Translate(-movespeed * (Time.deltaTime * transform.forward));
            movespeed += speedovertime * Time.deltaTime;

            if (currentplateform.transform.position.z < Camera.main.transform.position.z - platelength)
            {

                plateform.Remove(currentplateform);
                Destroy(currentplateform);
               spwanplateform();


            }

          
        }

    }
}
