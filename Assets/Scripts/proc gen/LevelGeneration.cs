using System.Collections.Generic;
using Unity.Cinemachine;
using UnityEngine;

public class LevelGeneration : MonoBehaviour
{
    [SerializeField] CameraController controller;
    [SerializeField] GameObject platforms;
    [SerializeField] Scoremanager sm;
    [SerializeField] int platformlength = 12;
    [SerializeField] Transform platformparent;
    [SerializeField] float maxspeed = 14f;


          float platlength = 10f;
   public float movespeed = 2f;
   public float speedovertime = 0.01f;

    public static LevelGeneration instance;

    List<GameObject> platform= new List<GameObject>();


    private void Awake()
    {
        instance = this;
    }


    private void Start()
    {
        spwnpz();

    }

    private void Update()
    {
        
        moveplatforms();  
    }

    public void flatformmovespeed(float speedamount)
    {
        movespeed += speedamount;

        if (movespeed > maxspeed)
        {
            movespeed = maxspeed;
        }
        Physics.gravity = new Vector3(Physics.gravity.x, Physics.gravity.y, Physics.gravity.z - speedamount);
        controller.changecamerafov(speedamount);
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
        GameObject newplatformGO = Instantiate(platforms, spwnz, Quaternion.identity);

        platform.Add(newplatformGO);
        chunk newplatform = newplatformGO.GetComponent<chunk>();
        newplatform.Init(this, sm);
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
