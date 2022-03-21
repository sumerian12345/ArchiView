using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorHandle : MonoBehaviour
{
    public Transform handle;


    // Start is called before the first frame update



    public void resethandle()
    {
        transform.position = handle.position;
        transform.rotation = handle.rotation;
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        handle.GetComponent<Rigidbody>().velocity = Vector3.zero;
        handle.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
    }
}
