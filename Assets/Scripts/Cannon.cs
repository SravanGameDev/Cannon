using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private Transform cannonObject;

    private float rotateSpeed = 3f;
    private float rotateClamp = 25f;
    private float power = 10f;
    private const float rotationClamp = 10f;

    public Bullet cannonBullet;
    public bool enableCannonRotate;

    private Vector3 _rotation;
    private float speed = 10f;

    Vector2 turn;

    void Awake()
    {
        cannonObject = transform.GetChild(0);
        lineRenderer = cannonObject.GetComponent<LineRenderer>();
    }

    void Start() 
    {
        //CannonRotate();
    }

    void Update()
    {
        CannonRay();
        CannonMuzzleRotate();

        if (Input.GetMouseButtonDown(0))
            CannonShoot();
    }

    void CannonRotate()
    {
       
        float y = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        Vector3 rot = transform.localEulerAngles+ new Vector3(0,y,0) ;
        transform.rotation = Quaternion.Euler(rot);
        Debug.Log($"Current Quaternion values = {Quaternion.Euler(transform.localEulerAngles)}");

    }

    void CannonRay()
    {
        lineRenderer.SetPosition(0, cannonBullet.spawnLocation.position);
        lineRenderer.SetPosition(1, cannonBullet.LineRay.position);
    }

    void CannonMuzzleRotate()
    {
        turn.x = Input.GetAxis("Mouse Y") * rotateSpeed;
        turn.x = Mathf.Clamp(turn.x, -rotateClamp, rotateClamp);
        cannonObject.localEulerAngles = new Vector3(turn.x, 0, 0);
    }

    void CannonShoot()
    {
        GameObject bullet = Instantiate(cannonBullet.prefab,cannonBullet.spawnLocation.position,Quaternion.identity);
        Rigidbody rigidbody = bullet.AddComponent<Rigidbody>();
        rigidbody.useGravity = false;
        //rigidbody.velocity = power * cannonBullet.spawnLocation.up;
        rigidbody.AddForce(cannonObject.transform.up * (500+power));
        bullet.transform.SetParent(transform);
    }
}

[System.Serializable]
public struct Bullet
{
    public GameObject prefab;
    public Transform spawnLocation;
    public Transform LineRay;
}