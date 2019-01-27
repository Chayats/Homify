using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MasterControl : MonoBehaviour
{
    public static MasterControl instance;
    public GameObject Player;

    void Start()
    {
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
    }
}
