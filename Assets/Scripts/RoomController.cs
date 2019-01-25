using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomController : MonoBehaviour
{
    public string nameOfRoom;
    public Text namelabel;


    // Update is called once per frame
    void Update()
    {
        namelabel.text = nameOfRoom;
    }
}
