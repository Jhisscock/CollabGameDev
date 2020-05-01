using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room_1 : MonoBehaviour
{
    public int count = 0;
    public GameObject Room_1_Walls_Top;
    public GameObject Room_1_Walls_Bottom;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(count >= 2){
            Room_1_Walls_Top.SetActive(false);
            Room_1_Walls_Bottom.SetActive(false);
        }
    }

    public void Room_1_Counter(){
        count++;
    }
}
