using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlightControl : MonoBehaviour
{   
    private Rigidbody rb;
    public float V_Thrust;
    public float H_Thrust;
    public bool isGrounded = true;
    public bool hasToppled = false;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {  
        #if UNITY_EDITOR || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX
            
            //LimitRotation();

            if(Input.GetKey(KeyCode.Space) && !hasToppled)
            {
                isGrounded = false;
                ThrustUpdwards();
            }

            if(!isGrounded && !hasToppled)
            {
               KeyControl();
               YawControl();
            }


        #endif
        
    }

    private void ThrustUpdwards()
    {
        rb.AddForce(Vector3.up * V_Thrust);
        Debug.Log("thrusting vertically");
    }

    private void KeyControl()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");

        Vector3 MoveV = new Vector3(0, 1, 0);
        Vector3 MoveH = new Vector3(ver, 0, -hor);

        rb.AddRelativeForce(MoveH * H_Thrust);

        // Vector3 euler = transform.localEulerAngles;
        // euler.z = Mathf.Lerp(euler.z, ver, 2.0f * Time.deltaTime);
        // transform.localEulerAngles = euler;
        //LimitRotation();
    }

    private void YawControl()
    {

    }

    private void LimitRotation()
    {
         float minRotation = -45;
         float maxRotation = 45;
         Vector3 currentRotation = transform.localRotation.eulerAngles;
         currentRotation.x = Mathf.Clamp(currentRotation.x, minRotation, maxRotation);
         currentRotation.z = Mathf.Clamp(currentRotation.z, minRotation, maxRotation);
         transform.localRotation = Quaternion.Euler (currentRotation);
    }



    void OnCollisionStay(Collision coll)
    {
        if(coll.gameObject.tag == "floor")
        {       
            if(transform.rotation.x<=89f && transform.eulerAngles.x>=-89f)
                {
                    if(transform.eulerAngles.z<=89f && transform.eulerAngles.z>=-89f)
                    {   
                        isGrounded = true;
                    }
                }
        else
        {
            Debug.Log("toppled");
            hasToppled = true;

            Debug.Log(transform.eulerAngles.x);
             Debug.Log(transform.eulerAngles.z);

        }
            
        }

        
    }
}
