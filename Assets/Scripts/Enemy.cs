using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    GameControllerScript gameController;
    Player player;
    private int healthPoint;

    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameControllerScript>();
        player = GameObject.Find("Cow Girl").GetComponent<Player>();
        healthPoint = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameController.elapsedTime > 30)
        {
            transform.localScale = new Vector3(4,4,4);
            healthPoint = 5;
        }
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
            healthPoint--;
            if (healthPoint <= 0)
            {
                Destroy(this.gameObject);
            }
            Destroy(other.gameObject);
        }
    }
}
