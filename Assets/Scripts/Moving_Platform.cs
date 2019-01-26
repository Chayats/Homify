using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving_Platform : MonoBehaviour
{
    private Rigidbody rb;
    public int direction = 1;

    public int MoveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        rb.velocity= new Vector3(direction*MoveSpeed, 0, 0);
    }
    void OnCollisionEnter(Collision other)
    {
        print("COLLISION");
        if (other.gameObject.CompareTag("Wall"))
        {
            ToggleDirection();
        }
    }

    public void ToggleDirection()
    {
        if (direction == 1)
            direction = -1;
        else if (direction == -1)
            direction = 1;
    }
}
