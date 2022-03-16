using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class ButtonInteractable : MonoBehaviour
{
    [System.Serializable]
    public class ButtonPressedEvent: UnityEvent { }
    [System.Serializable]
    public class ButtonReleasedEvent : UnityEvent { }
    public ButtonPressedEvent OnButtonPressed;
    public ButtonReleasedEvent OnButtonReleased;
    public Vector3 axis = new Vector3(0, -1, 0);
    public float maxdistance;
    public float returnspeed = 1.0f;
    private Vector3 startingposition;
    private Rigidbody rigidbody;
    private Collider collider;
    private bool ispressed = false;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        collider = GetComponentInChildren<Collider>();
        startingposition = transform.position;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Converting local axis to world axis
        Vector3 worldaxis = transform.TransformDirection(axis);
        Vector3 endpoint = transform.position + worldaxis * maxdistance;
        float currentdistance = (transform.position - startingposition).magnitude;
        RaycastHit info;
        float move = 0.0f;
        if (rigidbody.SweepTest(-worldaxis, out info, returnspeed * Time.deltaTime + 0.005f))
        {
            move = (returnspeed * Time.deltaTime) - info.distance;
        }
        else
        {
            move -= returnspeed * Time.deltaTime;
        }
        float newdistance = Mathf.Clamp(currentdistance + move, 0, maxdistance);
        rigidbody.position = startingposition + worldaxis * newdistance;
        if (!ispressed && Mathf.Approximately(newdistance, maxdistance))
        {
            ispressed = true;
            OnButtonPressed.Invoke();
        }
        else if(ispressed && !Mathf.Approximately(newdistance, maxdistance))
        {
            ispressed = false;
            OnButtonReleased.Invoke();
        }
    }
}
