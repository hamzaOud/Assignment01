using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRoam : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Add code to randomize initial direction
        GetComponent<Rigidbody>().velocity = Vector3.left * 3; //Give initial movement direction
    }

    // Update is called once per frame
    void Update()
    {
         Ray ray = new Ray(transform.position, Vector3.left);
         //If the enemy gets close to the Left wall
         if (Physics.Raycast(ray, 1))
         { // Change direction towards the right
             GetComponent<Rigidbody>().velocity = Vector3.right * 3;
         }

         Ray rayRight = new Ray(transform.position, Vector3.right);
         //If the enemy gets close to the right wall
         if (Physics.Raycast(rayRight, 1))
         {// Change direction towards the left
             GetComponent<Rigidbody>().velocity = Vector3.left * 3; 
         }


       /* Ray ray = new Ray(transform.position, Vector3.left);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, 1))
        {
            if (hit.collider.gameObject.tag == "Terrain")
            {
                print("enemy hit left wall");
                GetComponent<Rigidbody>().velocity = Vector3.right * 3;
            }
        }

        Ray rayRight = new Ray(transform.position, Vector3.right);
        if (Physics.Raycast(ray, out hit, 1))
        {
            if (hit.collider.gameObject.tag == "Terrain")
            {
                GetComponent<Rigidbody>().velocity = Vector3.left * 3;
            }
        }*/
    }

}
