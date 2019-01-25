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
        xpos = 10;
        ypos = 10;

        roomsToDisplay = new GameObject[19];

        for (int i = 0; i < roomsToDisplay.Length; i++)
        {
            roomsToDisplay[i] = Instantiate(roomprefab,Offsets[i],transform.rotation);
            
        }

        UpdateRooms();
    }

    public void TranslateDL()
    {
        xpos--;
        
        UpdateRooms();
    }
    public void TranslateDR()
    {
       
        xpos++;
        UpdateRooms();
    }
    public void TranslateUL()
    {
        xpos--;
        ypos--;
        UpdateRooms();
    }
    public void TranslateUR()
    {
        xpos++;
        ypos--;
      
        UpdateRooms();
    }


    void UpdateRooms()
    {
        roomsToDisplay[0].GetComponent<RoomController>().nameOfRoom = BaseGen.instance.globalMap[xpos, ypos].nameOfRoom;
        roomsToDisplay[1].GetComponent<RoomController>().nameOfRoom = BaseGen.instance.globalMap[xpos+1, ypos-1].nameOfRoom;
        roomsToDisplay[2].GetComponent<RoomController>().nameOfRoom = BaseGen.instance.globalMap[xpos, ypos-1].nameOfRoom;
        roomsToDisplay[3].GetComponent<RoomController>().nameOfRoom = BaseGen.instance.globalMap[xpos-1, ypos-1].nameOfRoom;
        roomsToDisplay[4].GetComponent<RoomController>().nameOfRoom = BaseGen.instance.globalMap[xpos-1, ypos].nameOfRoom;
        roomsToDisplay[5].GetComponent<RoomController>().nameOfRoom = BaseGen.instance.globalMap[xpos, ypos+1].nameOfRoom;
        roomsToDisplay[6].GetComponent<RoomController>().nameOfRoom = BaseGen.instance.globalMap[xpos+1, ypos].nameOfRoom;

        roomsToDisplay[7].GetComponent<RoomController>().nameOfRoom = BaseGen.instance.globalMap[xpos-1, ypos - 2].nameOfRoom;
        roomsToDisplay[8].GetComponent<RoomController>().nameOfRoom = BaseGen.instance.globalMap[xpos, ypos-2].nameOfRoom;
        roomsToDisplay[9].GetComponent<RoomController>().nameOfRoom = BaseGen.instance.globalMap[xpos+1, ypos -2].nameOfRoom;
        roomsToDisplay[10].GetComponent<RoomController>().nameOfRoom = BaseGen.instance.globalMap[xpos+2, ypos - 1].nameOfRoom;
        roomsToDisplay[11].GetComponent<RoomController>().nameOfRoom = BaseGen.instance.globalMap[xpos+2, ypos].nameOfRoom;
        roomsToDisplay[12].GetComponent<RoomController>().nameOfRoom = BaseGen.instance.globalMap[xpos+2, ypos +1].nameOfRoom;
        roomsToDisplay[13].GetComponent<RoomController>().nameOfRoom = BaseGen.instance.globalMap[xpos+1, ypos + 1].nameOfRoom;
        roomsToDisplay[14].GetComponent<RoomController>().nameOfRoom = BaseGen.instance.globalMap[xpos, ypos+2].nameOfRoom;
        roomsToDisplay[15].GetComponent<RoomController>().nameOfRoom = BaseGen.instance.globalMap[xpos-1, ypos + 1].nameOfRoom;
        roomsToDisplay[16].GetComponent<RoomController>().nameOfRoom = BaseGen.instance.globalMap[xpos-2, ypos + 1].nameOfRoom;
        roomsToDisplay[17].GetComponent<RoomController>().nameOfRoom = BaseGen.instance.globalMap[xpos-2, ypos].nameOfRoom;
        roomsToDisplay[18].GetComponent<RoomController>().nameOfRoom = BaseGen.instance.globalMap[xpos-2, ypos - 1].nameOfRoom;



        roomsToDisplay[0].GetComponent<RoomController>().open = BaseGen.instance.globalMap[xpos, ypos].open;
        roomsToDisplay[1].GetComponent<RoomController>().open = BaseGen.instance.globalMap[xpos + 1, ypos - 1].open;
        roomsToDisplay[2].GetComponent<RoomController>().open = BaseGen.instance.globalMap[xpos, ypos - 1].open;
        roomsToDisplay[3].GetComponent<RoomController>().open = BaseGen.instance.globalMap[xpos - 1, ypos - 1].open;
        roomsToDisplay[4].GetComponent<RoomController>().open = BaseGen.instance.globalMap[xpos - 1, ypos].open;
        roomsToDisplay[5].GetComponent<RoomController>().open = BaseGen.instance.globalMap[xpos, ypos + 1].open;
        roomsToDisplay[6].GetComponent<RoomController>().open = BaseGen.instance.globalMap[xpos + 1, ypos].open;

        roomsToDisplay[7].GetComponent<RoomController>().open = BaseGen.instance.globalMap[xpos - 1, ypos - 2].open;
        roomsToDisplay[8].GetComponent<RoomController>().open = BaseGen.instance.globalMap[xpos, ypos - 2].open;
        roomsToDisplay[9].GetComponent<RoomController>().open = BaseGen.instance.globalMap[xpos + 1, ypos - 2].open;
        roomsToDisplay[10].GetComponent<RoomController>().open = BaseGen.instance.globalMap[xpos + 2, ypos - 1].open;
        roomsToDisplay[11].GetComponent<RoomController>().open = BaseGen.instance.globalMap[xpos + 2, ypos].open;
        roomsToDisplay[12].GetComponent<RoomController>().open = BaseGen.instance.globalMap[xpos + 2, ypos + 1].open;
        roomsToDisplay[13].GetComponent<RoomController>().open = BaseGen.instance.globalMap[xpos + 1, ypos + 1].open;
        roomsToDisplay[14].GetComponent<RoomController>().open = BaseGen.instance.globalMap[xpos, ypos + 2].open;
        roomsToDisplay[15].GetComponent<RoomController>().open = BaseGen.instance.globalMap[xpos - 1, ypos + 1].open;
        roomsToDisplay[16].GetComponent<RoomController>().open = BaseGen.instance.globalMap[xpos - 2, ypos + 1].open;
        roomsToDisplay[17].GetComponent<RoomController>().open = BaseGen.instance.globalMap[xpos - 2, ypos].open;
        roomsToDisplay[18].GetComponent<RoomController>().open = BaseGen.instance.globalMap[xpos - 2, ypos - 1].open;
        foreach (var room in roomsToDisplay)
        {
            room.GetComponent<RoomController>().Recalc();
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
