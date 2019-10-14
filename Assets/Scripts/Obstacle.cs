using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    // Start is called before the first frame update
    public GameControllerScript gameController;
    public Player player;
    
    void Start()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameControllerScript>();
        player = GameObject.Find("Cow Girl").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && player.isInvincible == false)
        {   //If player runs in obstacle, the player dies
            gameController.Die();
        }
        else if (other.gameObject.tag == "Player" && player.isInvincible == true)
        { //If player is invincible and runs in an obstacle, the obstacle gets destroyed
            Destroy(this.gameObject);
        }
        else if (other.gameObject.tag == "Bullet") //If bullet hits obstacle, destroy both obstacle and bullet
        {
            Destroy(this.gameObject);
            Destroy(other.gameObject);
        }
    }
}
