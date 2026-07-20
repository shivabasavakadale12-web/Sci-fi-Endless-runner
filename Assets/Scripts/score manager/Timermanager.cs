using System;
using TMPro;
using UnityEngine;

public class Timermanager : MonoBehaviour
{
    [SerializeField] TMP_Text timetext;

  float initialtime = 0f;
  bool gameover = true;

    public bool GameOver
    {
        get { return gameover; }
        set { gameover = value; }
    }

   void Update()
    {
        if(gameover)
        {

         initialtime += Time.deltaTime;
         timetext.text = initialtime.ToString("F0");

        }
    }  
}
