using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invincibility : MonoBehaviour
{
    public Player player;
    new public AudioSource audio;
    public AudioClip sclip;
    GameControllerScript gameController;


    void Start()
    {
        player = GameObject.Find("Cow Girl").GetComponent<Player>();
        gameController = GameObject.Find("GameController").GetComponent<GameControllerScript>();
    }


    // Update is called once per frame
    void Update()
    {
        if (gameController.elapsedTime > 30)
        {
            transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }
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
