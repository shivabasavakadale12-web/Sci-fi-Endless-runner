using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputScript : MonoBehaviour
{
    [SerializeField] float movespeed = 15f;

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
        Debug.Log(movement);

    }
    void MovePosition()
    {
        Vector3 currentposition = RB.position;
        Vector3 movedirection = new Vector3(movement.x, 0f, movement.y);
        Vector3 newposition = currentposition + movedirection * (movespeed * Time.fixedDeltaTime);

        RB.MovePosition(newposition);
    }
}