using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class EventActions : MonoBehaviour
{   [SerializeField] float jumpPowerMult = 1f;
    Rigidbody rb;

    void Teleport(Vector3 pos){
        transform.position = pos;
        Debug.Log(pos);
    }

    void Jump(float power){
        rb.AddForce(0, power * jumpPowerMult, 0);
        Debug.Log(power * jumpPowerMult);
    }


    void Awake(){
        rb = GetComponent<Rigidbody>();
    }
    void OnEnable (){
        EventCaller.TeleportEvent += Teleport;
        EventCaller.JumpEvent += Jump;
    }
    void OnDisable(){
        EventCaller.TeleportEvent -= Teleport;
        EventCaller.JumpEvent -= Jump;
    }

    

    

    
}
