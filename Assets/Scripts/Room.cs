using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room 
{
   
    public float homeyness;
    public Color debugcolour;
    public bool isVoid = true;
    public bool generated = false;
    public string nameOfRoom= "";
    public int open = 6+8+16; // binary flags clockwise from the top

    public Room(string name)
    {
        nameOfRoom = name;

        debugcolour = new Color (100,100,100 );
    }
}
