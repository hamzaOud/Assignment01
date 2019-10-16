using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject fireball;
    private GameObject _ball;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, Vector3.back); // Ray originating from the enemy and heading backwards (-z)
        if (Physics.Raycast(ray, out hit, 45))
        {
            if (hit.collider.gameObject.tag == "Player") //if the ray hits the player
            { //Shoot a fireball
                if(_ball == null)
                {
                    _ball = Instantiate(fireball, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z - 1f), Quaternion.identity);
                }

                //Instantiate(fireball, new Vector3(transform.position.x, transform.position.y, transform.position.z + 1f), Quaternion.identity);
            }
        }

    }
}
