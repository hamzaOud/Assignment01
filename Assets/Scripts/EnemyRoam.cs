using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRoam : MonoBehaviour
{
    Rigidbody rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        //Add code to randomize initial direction
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.velocity = Vector3.left * 3; //Give initial movement direction
    }

    // Update is called once per frame
    void Update()
    {
         Ray ray = new Ray(transform.position, Vector3.left);
        //If the enemy gets close to the Left wall
        RaycastHit hit;
         if (Physics.Raycast(ray, out hit, 1))
         { // Change direction towards the right
            if (hit.collider.tag == "Terrain")
            {
                rigidbody.velocity = Vector3.right * 3;
            }
         }

         Ray rayRight = new Ray(transform.position, Vector3.right);
        //If the enemy gets close to the right wall
        RaycastHit hitRight;
         if (Physics.Raycast(rayRight, out hitRight, 1 ))
         {// Change direction towards the left

            if (hitRight.collider.tag == "Terrain")
            {
                rigidbody.velocity = Vector3.left * 3;
            }
         }
    }

}
