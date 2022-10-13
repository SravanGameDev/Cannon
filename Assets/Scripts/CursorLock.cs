using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CursorLock : MonoBehaviour
{
    void Start()
    {
        Cursor.lockState= CursorLockMode.Locked;
      
        orthographicView();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            ThirdPersonView();
        }
        if(Input.GetKeyDown(KeyCode.E))
        {
            orthographicView();
        }
    }


    void ThirdPersonView()
    {
        Vector3 rot= new Vector3(0, 90, 0);
        Vector3 pos= new Vector3(-1, 0.7f, 0);
        transform.localEulerAngles = rot;
        transform.position = Vector3.Lerp(transform.position, pos, 100);
        MoveTarget.thirdPersonView = true;
    }

    void orthographicView()
    {
        MoveTarget.thirdPersonView = false;
        transform.localEulerAngles = Vector3.zero;
        transform.position = new Vector3(5.44f, 2.76f, -8.32f);
    }
}
