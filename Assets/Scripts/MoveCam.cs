using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCam : MonoBehaviour
{
    public GameControllerScript gameController;
    private Rigidbody body;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
        body.velocity = new Vector3(0f, 0f, gameController.speed);

#if UNITY_ANDROID || UNITY_IOS

        transform.Translate(new Vector3(0, 0, -10));

#endif

    }

    // Update is called once per frame
    void Update()
    {
        body.velocity = new Vector3(0f, 0f, gameController.speed);
    }
}
