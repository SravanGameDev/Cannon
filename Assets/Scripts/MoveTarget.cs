using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTarget : MonoBehaviour
{
    int amplitude=2;
    float frequency = 0.8f;
    Vector3 initialPosition;

    public static bool thirdPersonView;
    public static bool enableRotate;

    void Start()
    {
        initialPosition = transform.position;
    }

    void Update()
    {
        if (thirdPersonView)
            ThirdPersonTarget();
        else
            UpdateSinPosition();
    }

    void UpdateSinPosition()
    {
        float x = 0;
        float y = Mathf.Sin(Time.time*frequency) * amplitude;
        float z = 0;

        transform.position = initialPosition + new Vector3(x, y, z);
    }

    void ThirdPersonTarget()
    {
        float x = 0;
        float y = Mathf.Sin(Time.time * frequency) * amplitude;
        float z = Mathf.Cos(Time.time * frequency) * amplitude;

        transform.position = initialPosition + new Vector3(x, y, z);
    }
         

    void UpdateLogic()
    {
        transform.position = initialPosition + new Vector3(0,Mathf.Sin(Time.time)*amplitude, 0);
    }
}
