using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundListenerCheck : MonoBehaviour
{
    public AudioListener listener;
    // Start is called before the first frame update
    void Start()
    {
        listener = GetComponent<AudioListener>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("Sound") == 0)
        {
            listener.enabled = false;
        }
        else
        {
            listener.enabled = true;
        }
    }
}
