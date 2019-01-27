using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{


    public Rigidbody rb;
    public GameObject neck;
    public GameObject head;
    public GameObject target;
    public ParticleSystem vomit;
    public Vector3 offset;
    public GameObject shotPrefab;
    public Animator anim;
     float str;
    public float speed;
    public float strength;
    public bool jumping;
    public Vector3 jumpProfile;



    // Start is called before the first frame update
    void Start()
    {

        
    }

    private void LateUpdate()
    {
        float dist = Vector3.Distance(target.transform.position, transform.position);
        if (dist > .3)
        {
            neck.transform.LookAt(target.transform);
           
            head.transform.LookAt(target.transform);
            head.transform.Rotate(offset);
        }

    }

    private void OnCollisionStay(Collision collision)
    {
        ContactPoint[] contactPoints = collision.contacts;
        bool validSurfaceNormal = false;
        for (int i = 0; i < contactPoints.Length; i++)
        {
            if (Vector3.Dot(contactPoints[i].normal, Vector3.up) > 0.5f)
            {
                validSurfaceNormal = true; break;
            }
        }

        if (validSurfaceNormal)
        {
            jumping = !true;
  
        }

    }

    // Update is called once per frame
    void Update()
    {

        if (!jumping && Input.GetKeyDown("space"))
            {

            Debug.Log("jump");
            jumping = true;
            anim.SetTrigger("jump");
            rb.AddRelativeForce(jumpProfile);

        }

      
        


        rb.AddRelativeForce(Input.GetAxis("Horizontal")* speed, 0,Input.GetAxis("Vertical")* speed) ;

        Vector3 bob = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);

        Quaternion targetRotation = Quaternion.LookRotation(bob - transform.position);
        str = Mathf.Min(strength * Time.deltaTime, 1);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, str);
    
        

    // Debug.Log(rb.velocity.magnitude);
    anim.SetFloat("Speed", rb.velocity.magnitude);


        //controls
        bool vom = false;
        if (Input.GetMouseButton(0))
        {
       
            vom = true;
        }
        else
        {
            
            vom = false;
        }

        if ( vom)
        {

            vomit.Play();
        }
        

        if (vomit.isPlaying && !vom)
        {
           
            vomit.Stop();
        }



}

    public void TakeDamage(int damagePerShot, Vector3 point)
    {
       
    }
}
