using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCam : MonoBehaviour
{
    public GameControllerScript gameController;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, gameController.speed);
    }

    // Update is called once per frame
    void Update()
    {   
        GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, gameController.speed);

        //GetComponent<AudioListener>().enabled = false;
    }
}
