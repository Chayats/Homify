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
        print("MUCK COLLISION");
        transform.parent = other.transform.parent.transform;
        rb.useGravity = false;
        rb.isKinematic = true;
        rb.velocity = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(attached)
        {
            rb.velocity = new Vector3(0, 0, 0);
        }
    }
}
