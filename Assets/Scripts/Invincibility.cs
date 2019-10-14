using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invincibility : MonoBehaviour
{
    public Player player;

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
            player.Invincible();
            Destroy(this.gameObject);
        }
    }
}
