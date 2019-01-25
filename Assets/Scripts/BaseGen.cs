using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseGen : MonoBehaviour
{
    public Room[,] globalMap;
   public  static BaseGen instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        globalMap = new Room[30,30];

        for (int x = 0; x < 30; x++)
        {
            for (int y = 0; y < 30; y++)
            {
                string bob = "R:" + x.ToString() + "," + y.ToString();
                globalMap[x, y] = new Room(bob);

                if (y == 0|| y==30 || x==0 || x==30)
                {
                    globalMap[x, y].open = 0;
                }

            }
        }
    }


}
