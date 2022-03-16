using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugInformation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void LogInfo(string message)
    {
        Debug.Log(message);
    }
}
