using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
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
        transform.Translate(new Vector3(0f, 0f, -Time.deltaTime * 10));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && player.isInvincible) //If the player is invincible, destroy the fireball
        {
            Destroy(this.gameObject);
        }
        else if (other.gameObject.tag == "Player")
        {//If the fireball hits the player, Game over
            gameController.Die();
        }
    }
}
