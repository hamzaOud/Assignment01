using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletVelocity : MonoBehaviour
{
    public float bulletSpeed = 8.0f;

    // Start is called before the first frame update
    void Start()
    {
            GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, bulletSpeed);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
