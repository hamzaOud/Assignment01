using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{

    public GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //If player presses left button, fire bullet
    }

    public void shoot()
    {
        Instantiate(bullet, new Vector3(transform.position.x, 0.5f, transform.position.z + 1f), Quaternion.Euler(90, 0, 0));
        if (PlayerPrefs.GetInt("Sound") == 1)
        {
            GetComponent<AudioSource>().Stop();
            GetComponent<AudioSource>().Play();
        }
    }
}
