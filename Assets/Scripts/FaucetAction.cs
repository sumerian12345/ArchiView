using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaucetAction : MonoBehaviour
{
    public ParticleSystem stream;
    public float waterRatio;
    public void WaterChanged(DialInteractable dial)
    {
        float ratio = dial.currentAngle / dial.rotationMaximumAngle;
        waterRatio = ratio;
        WaterSpout();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    public void WaterSpout()
    {
        float particleCount = stream.particleCount*waterRatio + 50;
        stream.maxParticles = (int) particleCount;

    }
}