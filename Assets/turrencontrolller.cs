using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turrencontrolller : MonoBehaviour
{
    public GameObject guns;
    public GameObject barrel;
    public Alienify connectedresin;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (connectedresin.finished)
        {
            barrel.SetActive(false);
            return;
        }

        Vector3 pos = MasterControl.instance.Player.transform.position;

        pos.y = pos.y - .05f;

        guns.transform.LookAt(pos);
    }
}
