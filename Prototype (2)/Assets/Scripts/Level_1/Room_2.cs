using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room_2 : MonoBehaviour
{
    public bool gotKey;
    public bool gotBroom;
    public bool topClosetOpen;
    public bool doorKeyUsed;
    public GameObject Room_2_Walls_Top, Room_2_Walls_Bottom;
    // Start is called before the first frame update
    void Start()
    {
        gotKey = false;
        gotBroom = false;
        topClosetOpen = false;
        doorKeyUsed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(doorKeyUsed){
            Room_2_Walls_Top.SetActive(false);
            Room_2_Walls_Bottom.SetActive(false);
        }
    }
}
