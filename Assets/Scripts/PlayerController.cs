using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public bool menu = false;
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
    public Vector3 gravity;
    public GameObject cursor;
    public Vector3 localnormal;
    public Vector3 targeteula;
    public Vector3 truetarget;
   public  AudioSource gunAudio;
    Quaternion targetorientation;
    public bool vom = false;
    // Start is called before the first frame update
    void Start()
    {
        localnormal = new Vector3(0, 1, 0);
  
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



        Vector3 bob;
        Quaternion targetRotation;
        rb.AddForce(gravity);

        if (!menu)
        {
            rb.AddRelativeForce(Input.GetAxis("Horizontal") * speed, 0, Input.GetAxis("Vertical") * speed);

            if (localnormal == new Vector3(0, 1, 0) || localnormal == new Vector3(0, -1, 0))
            {
                bob = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);
                targetRotation = Quaternion.LookRotation(bob - transform.position);
            }
            else
            {


                bob = new Vector3(transform.position.x, target.transform.position.y, target.transform.position.z);
                //bob = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);

                targetRotation = Quaternion.LookRotation(bob - transform.position, Vector3.right);
            }





            str = Mathf.Min(strength * 2 * Time.deltaTime, 1);

            // Vector3 truetarget = targetRotation.eulerAngles;
            // truetarget.z = targeteula.z;
            // targetRotation.SetEulerAngles(truetarget);
            // targetRotation = targetRotation * targetorientation;

            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, str);

        }

    // Debug.Log(rb.velocity.magnitude);
    anim.SetFloat("Speed", rb.velocity.magnitude);


        //controls  
        if (!menu)
            if (!jumping && Input.GetKeyDown("space"))
            {

            Debug.Log("jump");
            jumping = true;
            anim.SetTrigger("jump");
            rb.AddRelativeForce(jumpProfile);

        }
      

        if (Input.GetMouseButtonDown(0))
        {
       
            vom = true;
            vomit.Play();
            gunAudio.Play();
        }

        if (Input.GetMouseButtonUp(0))
        {

            vom = false;
         
        }
        
        if (vomit.isPlaying && !vom)
        {
           
            vomit.Stop();
            gunAudio.Stop();
        }

       
       

        if (Input.GetMouseButton(1))
        {

            
            targeteula = transform.rotation.eulerAngles;
            targetReticle tr = cursor.GetComponent<targetReticle>();

            jumping = true;
            anim.SetTrigger("jump");
            rb.AddRelativeForce(jumpProfile);




            if (tr.normal.x == 1)
            {
               // gravity = new Vector3(-9, 0, 0);

                targeteula.z = 90;


                localnormal = tr.normal;
            }

            if (tr.normal.x == -1)
            {
               // gravity = new Vector3(9, 0, 0);
                localnormal = tr.normal;
                targeteula.z = -90;
            }

            if (tr.normal.y == 1)
            {
              //  gravity = new Vector3(0, -9, 0);
                localnormal = tr.normal;
                targeteula.z = 0;


            }
            if (tr.normal.y == -1)
            {
              //  gravity = new Vector3(0, 9, 0);
                localnormal = tr.normal;
                targeteula.z = 180;
            }


            transform.Rotate(targeteula);
           targetorientation = Quaternion.AngleAxis(targeteula.z, Vector3.back);

        }


    }


   



    public void TakeDamage(int damagePerShot, Vector3 point)
    {
        MasterControl.instance.health--;
    }
}
