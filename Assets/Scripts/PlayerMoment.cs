using System;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerMoment : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    [SerializeField] float speedincreaserate = 0.1f;

    [SerializeField] float rightmove = 1f;


    void Update()
    {
       
        transform.Translate(0f, 0f, speed * Time.deltaTime, Space.World);

        speed += speedincreaserate * Time.deltaTime;

        moveright();
    }

    void moveright()
    {
        if (Keyboard.current.dKey.isPressed)
        {
            transform.Translate(0f, rightmove, 0f);
            rightmove = 0f;
        }
    }
}
