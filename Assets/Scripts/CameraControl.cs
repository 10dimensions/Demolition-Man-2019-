using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {

    private GameObject drone;      
    private Vector3 offset;        
    void Start () 
    {   
        drone = GameObject.FindGameObjectWithTag("drone");
        offset = transform.position - drone.transform.position;
    }
    
    void LateUpdate () 
    {
        transform.position = drone.transform.position + offset;
        transform.LookAt(drone.transform.position);
    }
}