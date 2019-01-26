using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{


    public Rigidbody rb;
    public GameObject neck;
    public GameObject target;
    public ParticleSystem vomit;

    public GameObject shotPrefab;
    public int FireSpeed;

    private Rigidbody rb;
    private float speed = 10f;
    private bool CanJump = true;
    private Vector2 mouse;
    private Vector3 mouse3d;
    private Camera cam;
    private bool CanFire = true;
    private float FireRate;

    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(Input.GetAxis("Horizontal")*2, Input.GetAxis("Vertical")*2, 0) ;

        float dist = Vector3.Distance(target.transform.position, transform.position);
        if(dist > .3)
        {
            neck.transform.LookAt(target.transform);
        }


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

        if (!vomit.isPlaying && vom)
        {

            vomit.Play();
        }
        

        if (vomit.isPlaying && !vom)
        {
           
            vomit.Stop();
        }



}}
