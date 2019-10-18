using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invincibility : MonoBehaviour
{
    public Player player;
    public AudioSource audio;
    public AudioClip sclip;


    void Start()
    {
        player = GameObject.Find("Cow Girl").GetComponent<Player>();
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (PlayerPrefs.GetInt("Sound") == 1)
            {
                player.Invincible();
                audio.Play();
                GetComponent<MeshRenderer>().enabled = false;
                Destroy(this.gameObject, sclip.length);
            }
            else
            {
                player.Invincible();
                Destroy(this.gameObject);
            }
        }
    }
}
