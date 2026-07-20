using System;
using TMPro;
using UnityEngine;

public class Timermanager : MonoBehaviour
{
    [SerializeField] TMP_Text timetext;

   public float initialtime;
   public bool elapsed = true;

    public static Timermanager instance;
   
 
  public void Update()
    {
        if(elapsed)
        {

         initialtime += Time.deltaTime;
         timetext.text = Time.realtimeSinceStartup.ToString("F0");

        }
    }

    public void timerstop()
    {
       elapsed = false;
    }

    
}
