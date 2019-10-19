using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    // Start is called before the first frame update
    public GameControllerScript gameController;
    public Player player;
    new public AudioSource audio;
    public AudioClip sclip;
    public int maxHP;
    
    void Start()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameControllerScript>();
        player = GameObject.Find("Cow Girl").GetComponent<Player>();
        maxHP = 3;
     }

    // Update is called once per frame
    void Update()
    {
        if (gameController.elapsedTime > 30 && gameController.elapsedTime <= 60)
        {
            maxHP = 4;
        } else if (gameController.elapsedTime > 60)
        {
            maxHP = 5;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && player.isInvincible == false)
        {   //If player runs in obstacle, the player dies
            gameController.Die();
        }
        else if (other.gameObject.tag == "Player" && player.isInvincible == true)
        { //If player is invincible and runs in an obstacle, the obstacle gets destroyed
            if(PlayerPrefs.GetInt("Sound") == 1)
            {
                audio.Play();
                transform.position = Vector3.one * 9999f;
                Destroy(this.gameObject, sclip.length);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }
        else if (other.gameObject.tag == "Bullet") //If bullet hits obstacle, destroy both obstacle and bullet
        {
            maxHP--;
            if (zeroHP(maxHP))
            {
                if (PlayerPrefs.GetInt("Sound") == 1)
                {
                    audio.Play();
                    transform.position = Vector3.one * 9999f;
                    Destroy(this.gameObject, sclip.length);
                }
                else
                {
                    Destroy(this.gameObject);
                }

            }
            Destroy(other.gameObject);
        }
    }

    private bool zeroHP(int hp)
    {
        if (hp <= 0)
        {
            return true;
        }
        else return false;


    }
}
