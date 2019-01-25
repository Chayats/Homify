using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomViewer : MonoBehaviour
{
    GameObject[] roomsToDisplay;
    public Vector3[] Offsets;
    public GameObject roomprefab;
    int xpos, ypos;

    // Start is called before the first frame update
    void Start()
    {
        xpos = 15;
        ypos = 15;

        roomsToDisplay = new GameObject[7];

        for (int i = 0; i < roomsToDisplay.Length; i++)
        {
            roomsToDisplay[i] = Instantiate(roomprefab,Offsets[i],transform.rotation);
            
        }

        UpdateRooms();
    }

    public void TranslateDL()
    {
        xpos++;
        ypos++;
        UpdateRooms();
    }
    public void TranslateDR()
    {
       
        ypos--;
        UpdateRooms();
    }
    public void TranslateUL()
    {
        
        ypos++;
        UpdateRooms();
    }
    public void TranslateUR()
    {
        xpos--;
      
        UpdateRooms();
    }


    void UpdateRooms()
    {
        roomsToDisplay[0].GetComponent<RoomController>().nameOfRoom = BaseGen.instance.globalMap[xpos, ypos].nameOfRoom;
        roomsToDisplay[1].GetComponent<RoomController>().nameOfRoom = BaseGen.instance.globalMap[xpos-1, ypos].nameOfRoom;
        roomsToDisplay[2].GetComponent<RoomController>().nameOfRoom = BaseGen.instance.globalMap[xpos-1, ypos+1].nameOfRoom;
        roomsToDisplay[3].GetComponent<RoomController>().nameOfRoom = BaseGen.instance.globalMap[xpos, ypos+1].nameOfRoom;
        roomsToDisplay[4].GetComponent<RoomController>().nameOfRoom = BaseGen.instance.globalMap[xpos+1, ypos+1].nameOfRoom;
        roomsToDisplay[5].GetComponent<RoomController>().nameOfRoom = BaseGen.instance.globalMap[xpos+1, ypos].nameOfRoom;
        roomsToDisplay[6].GetComponent<RoomController>().nameOfRoom = BaseGen.instance.globalMap[xpos, ypos-1].nameOfRoom;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
