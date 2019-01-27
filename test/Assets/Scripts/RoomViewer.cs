using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomViewer : MonoBehaviour
{
    GameObject[] roomsToDisplay;
    public GameObject player;
    public Vector3[] Offsets;
    public GameObject roomprefab;
    int xpos, ypos;

    // Start is called before the first frame update
    void Start()
    {
        xpos = 10;
        ypos = 10;

        roomsToDisplay = new GameObject[25];

        int i = 0;
        for (int x = -2; x < 3; x++)
        {
            for (int y = -2; y < 3; y++)
            {
                Vector3 pos = new Vector3( x, y, 0 );
                roomsToDisplay[i] = Instantiate(roomprefab,pos, transform.rotation);
                i++;
            }
        }

        UpdateRooms();
    }


   

    public void TranslateL()
    {
        xpos--;
        player.transform.Translate(1, 0f, 0);
        UpdateRooms();
    }
    public void TranslateR()
    {
        player.transform.Translate(-1, 0f, 0);
        xpos++;
        UpdateRooms();
    }
    public void TranslateU()
    {
        player.transform.Translate(0, 1f, 0);
        ypos--;
        UpdateRooms();
    }
    public void TranslateD()
    {
        player.transform.Translate(0, -1f, 0);
        
        ypos++;
      
        UpdateRooms();
    }


    void UpdateRooms()
    {
        int i = 0;
        for (int x = -2; x < 3; x++)
        {
            for (int y = -2; y < 3; y++)
            {
                Vector3 pos = new Vector3(x+xpos, y+ypos, 0);

                if (!(pos.x < 0 | pos.x > 30 | pos.y < 0 | pos.y > 30))
                {


                    roomsToDisplay[i].GetComponent<RoomController>().nameOfRoom = BaseGen.instance.globalMap[(int)pos.x, (int)pos.y].nameOfRoom;
                    roomsToDisplay[i].GetComponent<RoomController>().Recalc();
                }
                    i++;
            }
        }

        foreach (var room in roomsToDisplay)
        {
            room.GetComponent<RoomController>().Recalc();
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.x > .51)
        {
            TranslateR();
        }

        if (player.transform.position.x < -.51)
        {
            TranslateL();
        }
    }
}
