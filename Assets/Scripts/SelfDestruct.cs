using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{

    void Update()
    {
        Destroy(this.gameObject,3f);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Target"))
        {
            GetComponent<Rigidbody>().useGravity = true;
        }
    }
}
