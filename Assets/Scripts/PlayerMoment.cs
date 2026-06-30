using UnityEngine;


public class PlayerMoment : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    [SerializeField] float speedincreaserate = 0.1f;

   

  
    void Update()
    {
       
        transform.Translate(0f, 0f, speed * Time.deltaTime, Space.World);

        speed += speedincreaserate * Time.deltaTime;


    }
}
