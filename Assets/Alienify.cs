using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alienify : MonoBehaviour
{
     Vector3 actualsize;
    Vector3 actualsizenot;
    Vector3 initalsize = new Vector3 (0.001f,0.001f,0.001f);
    public bool finished;
    public MeshRenderer MR;
    public GameObject notificator;

     float growth;
    private void Start()
    {
        MR.enabled = false;
        actualsize = transform.localScale;
        transform.localScale = initalsize;
        actualsizenot = notificator.transform.localScale;
    }


    private void OnParticleCollision(GameObject other)
    {
        if (!finished)
        {
            MR.enabled = true;
            growth = growth + .003f;
            Debug.Log(other.name);
            transform.localScale = Vector3.Lerp(initalsize, actualsize, growth);

            notificator.transform.localScale = Vector3.Lerp(actualsizenot, initalsize, growth);

            if (growth > 1)
            {
                finished = true;
                notificator.SetActive(false);
            }
        }


    }
}
