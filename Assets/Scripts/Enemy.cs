using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    GameControllerScript gameController;
    Player player;

    // Start is called before the first frame update
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
        if (other.gameObject.tag == "Player" && player.isInvincible)
        {
            Destroy(this.gameObject);
        }
        else if (other.gameObject.tag == "Player")
        {
            gameController.Die();
        }

        if (other.gameObject.tag == "Bullet")
        {
            Destroy(this.gameObject);
            Destroy(other.gameObject);
        }
    }
}
