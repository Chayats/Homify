using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulbFlicker : MonoBehaviour
{
    private Rigidbody rb;
    private bool flickering = false;
    private IEnumerator FlickerCoroutine;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(!flickering)
        {
            float ontime = Random.Range(0.2f, 4.0f);
            float offtime = Random.Range(0.01f, 0.1f);
            FlickerCoroutine = Flicker(ontime, offtime);
            StartCoroutine(FlickerCoroutine);
        }
    }

    private IEnumerator Flicker(float ondelay, float offdelay)
    {
        flickering = true;
        yield return new WaitForSeconds(ondelay);
        rb.transform.Find("Light Bulb").gameObject.SetActive(false);
        yield return new WaitForSeconds(offdelay);
        rb.transform.Find("Light Bulb").gameObject.SetActive(true);
        flickering = false;
    }

}

