using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
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
        cam = Camera.main;
        rb = GetComponent<Rigidbody>();
        FireRate = 100 / (float)FireSpeed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        mouse.x = Input.mousePosition.x;
        mouse.y = cam.pixelHeight - Input.mousePosition.y;
        mouse3d = cam.ScreenToWorldPoint(new Vector3(mouse.x, mouse.y, cam.nearClipPlane));

        float MoveHorizontal = Input.GetAxis("Horizontal");
        //float MoveVertical = Input.GetAxis("Vertical");
        rb.velocity = new Vector3(MoveHorizontal * speed, rb.velocity.y, 0);

        if (!CanJump && rb.velocity.y < 0.01 && rb.velocity.y > -0.01)
        {
            StartCoroutine(TimeJump());
        }

        if (Input.GetButton("Jump") && CanJump)
        {
            Jump();
        }

        if(Input.GetButton("Fire1")&&CanFire&&MouseOnScreen())
        {
            StartCoroutine(Fire());
        }

    }

    bool MouseOnScreen()
    {
        
        if(mouse.x<=Screen.width && mouse.y<= Screen.height && mouse.x>0 && mouse.y>0 )
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    IEnumerator Fire()
    {
        CanFire = false;
        GameObject NewInst = Instantiate(shotPrefab);
        Rigidbody rbNew = NewInst.GetComponent<Rigidbody>();
        Rigidbody rbCurrent = GetComponent<Rigidbody>();

        print("mouse3d.x "+mouse3d.x+" rbcurrent.x "+rbCurrent.position.x+" mouse3d.y "+mouse3d.y+" rbcurrent.y "+rbCurrent.position.y);

        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit rayHit;
        if (Physics.Raycast(camRay, out rayHit))
        {
            rbNew.velocity = Vector3.Normalize(new Vector3(rayHit.point.x - rbCurrent.position.x, rayHit.point.y - rbCurrent.position.y, 0))*20;
        }

        
        float Y = rbCurrent.position.y + (float)1.5;
        float X = rbCurrent.position.x;
        float Z = rbCurrent.position.z;
        rbNew.position = new Vector3(X, Y, Z);
        yield return new WaitForSeconds(FireRate);
        CanFire = true;
    }


    void Jump()
    {
        print("Jump");
        rb.AddForce(new Vector3(rb.velocity.x, speed * 50, 0));
        CanJump = false;
    }
    IEnumerator TimeJump()
    {
        yield return new WaitForSeconds(1.4f);
        if(rb.velocity.y < 0.01 && rb.velocity.y > -0.01)
        {
            CanJump = true;
        }
        else
        {
            CanJump = false;
        }
    }
}
