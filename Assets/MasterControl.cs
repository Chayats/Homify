using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MasterControl : MonoBehaviour
{
    public static MasterControl instance;
    public GameObject Player;
    Vector3 offset;
    public int health = 100;
    public Slider healthslider;

    void Start()
    {
    
        offset = transform.position - Player.transform.position;

        instance = this;
    }
    public Alienify[] resinclusters;

    public Slider levelcomplete;
   

    private void Update()
    {
        int complete = 0;





        foreach (Alienify cluster in resinclusters)
        {
            if (cluster.finished)
                complete++;
        }

        levelcomplete.maxValue = resinclusters.Length;
        levelcomplete.value = complete;

        offset.z = offset.z+ Input.GetAxis("Mouse ScrollWheel");


    }

    private void LateUpdate()
    {

        healthslider.value = health;

        if( health == 0)
        {
            SceneManager.LoadScene(0);
        }
       Vector3 target = (Player.transform.position + offset);
        target.x = Mathf.Round(target.x);
        target.y = Mathf.Round(target.y);
        target.z = Mathf.Round(target.z);

        transform.position = Vector3.Lerp(transform.position, target, .2f);


    }


}
