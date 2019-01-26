using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomController : MonoBehaviour
{
    public string nameOfRoom;
    public Text namelabel;
    public GameObject leftop,righttop,leflow,rightlow;
       
    public int open = 30;

    // Update is called once per frame
    void FixedUpdate()
    {

    }

    public void Recalc()



    {        switch (open)
        {
            case 0:
                leflow.SetActive(true);
                rightlow.SetActive(true);
                leftop.SetActive(true);
                righttop.SetActive(true);
                break;
            case 2:
                leflow.SetActive(true);
                rightlow.SetActive(true);
                leftop.SetActive(true);
                righttop.SetActive(false);
                break;
            case 4:
                leflow.SetActive(true);
                rightlow.SetActive(false);
                leftop.SetActive(true);
                righttop.SetActive(true);
                break;
            case 6:
                leflow.SetActive(true);
                rightlow.SetActive(false);
                leftop.SetActive(true);
                righttop.SetActive(false);
                break;
            case 8:
                leflow.SetActive(false);
                rightlow.SetActive(true);
                leftop.SetActive(true);
                righttop.SetActive(true);
                break;
            case 10:
                leflow.SetActive(false);
                rightlow.SetActive(true);
                leftop.SetActive(false);
                righttop.SetActive(true);
                break;
            case 12:
                leflow.SetActive(false);
                rightlow.SetActive(false);
                leftop.SetActive(true);
                righttop.SetActive(true);
                break;
            case 14:
                leflow.SetActive(false);
                rightlow.SetActive(false);
                leftop.SetActive(true);
                righttop.SetActive(false);
                break;
            case 16:
                leflow.SetActive(true);
                rightlow.SetActive(true);
                leftop.SetActive(false);
                righttop.SetActive(true);
                break;
            case 18:
                leflow.SetActive(true);
                rightlow.SetActive(true);
                leftop.SetActive(false);
                righttop.SetActive(false);
                break;
            case 20:
                leflow.SetActive(true);
                rightlow.SetActive(false);
                leftop.SetActive(false);
                righttop.SetActive(true);
                break;
            case 22:
                leflow.SetActive(true);
                rightlow.SetActive(false);
                leftop.SetActive(false);
                righttop.SetActive(false);
                break;
            case 24:
                leflow.SetActive(true);
                rightlow.SetActive(false);
                leftop.SetActive(true);
                righttop.SetActive(false);
                break;
            case 26:
                leflow.SetActive(false);
                rightlow.SetActive(true);
                leftop.SetActive(false);
                righttop.SetActive(false);
                break;
            case 28:
                leflow.SetActive(false);
                rightlow.SetActive(false);
                leftop.SetActive(false);
                righttop.SetActive(true);
                break;
            case 30:
                leflow.SetActive(false);
                rightlow.SetActive(false);
                leftop.SetActive(false);
                righttop.SetActive(false);
                break;
            default:
                break;
        }

        namelabel.text = nameOfRoom;
   
    }
}
