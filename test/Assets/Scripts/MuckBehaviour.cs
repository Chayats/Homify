using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuckBehaviour : MonoBehaviour
{
    private Rigidbody rb;
    private bool attached=false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision other)
    {
        if (!attached)
        {
            print("MUCK COLLISION");
            //store vector3 of position relative to parent upon collision
            transform.parent = other.transform.parent.transform;
            rb.useGravity = false;
            rb.isKinematic = true;
            rb.velocity = new Vector3(0, 0, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(attached)//update position based on parent position using vector3 relative
        {
            rb.velocity = new Vector3(0, 0, 0);
        }
    }
}
