using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EventCaller : MonoBehaviour
{
    //Teleport Vars
    [SerializeField] Vector3 pos1, pos2, pos3;
    public static event TeleportDelagate TeleportEvent;
    public delegate void TeleportDelagate(Vector3 pos);

    //Jump Vars
    float time = 0;
    public static event JumpDelagate JumpEvent;
    public delegate void JumpDelagate(float time);
    

    void Update(){
        TeleportInput();
        JumpInput(); 
    }
    
    void TeleportInput(){ // gets keys 1-3 and sets position set in inspector
        if (Input.GetKeyDown(KeyCode.Alpha1)){
            TeleportEvent?.Invoke(pos1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2)){
            TeleportEvent?.Invoke(pos2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3)){
            TeleportEvent?.Invoke(pos3);
        }
    }

    void JumpInput(){ // adds upward force to object based on how long space bar is held
        if (time == 0 && Input.GetKeyDown(KeyCode.Space)){
            time = Time.time;
        }
        if (Input.GetKeyUp(KeyCode.Space)){
            float timeHeld = Time.time - time;
            JumpEvent?.Invoke(timeHeld);
            time = 0;
        }
        
    }

    
    
}
