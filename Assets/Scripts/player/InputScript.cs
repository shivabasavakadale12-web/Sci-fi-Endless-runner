using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class InputScript : MonoBehaviour
{
    [SerializeField] float movespeed = 15f;
    [SerializeField] float xclamp = 3f;
    [SerializeField] float zclamp = 0f;

    
    Vector2 movement;

    Rigidbody RB;
    
 
    private void Start()
    {
        RB = GetComponent<Rigidbody>();

    }

    private void FixedUpdate()
    {
        MovePosition();  
      
    }


    public void move(InputAction.CallbackContext context)
    {
       
        movement = context.ReadValue<Vector2>();
  

    }


    void MovePosition()
    {
        Vector3 currentposition = RB.position;
        Vector3 movedirection = new Vector3(movement.x, 0f, movement.y);
        Vector3 newposition = currentposition + movedirection * (movespeed * Time.fixedDeltaTime);

        newposition.x = Mathf.Clamp(newposition.x, -xclamp, xclamp);
        newposition.z = Mathf.Clamp(newposition.z, -zclamp, zclamp);

        RB.MovePosition(newposition);
    }
}   