using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTerrain : MonoBehaviour
{
    public GameObject terrainPrefab;
    public GameObject enemy; 
    public GameObject obstacle;
    public GameObject[] powerUps;

    private GameControllerScript gameController;


    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameControllerScript>();
        obstacle.transform.localScale = new Vector3(5, 1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameController.elapsedTime > 10)
        {
            obstacle.transform.localScale = new Vector3(9, 2, 1);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Instantiate(terrainPrefab, new Vector3(0f, -0.5f, transform.position.z + 15), Quaternion.identity);


            int random = Random.Range(0, 100);
            if (random <= 50) //AI to decide if it will spawn obstacle
            {
                if (gameController.elapsedTime > 10)
                {
                    Instantiate(obstacle, new Vector3(0, 0.5f, transform.position.z + Random.Range(14, 19)), Quaternion.identity);

                }
                else
                {
                    Instantiate(obstacle, new Vector3(Random.Range(-3, 3), 0.5f, transform.position.z + Random.Range(14, 19)), Quaternion.identity);
                }
            }
           /* else if (random <= 75)// If it does not spawn obstacle
            {
                float selectedPowerUps = Random.value;

                if (selectedPowerUps < 0.5) { //AI to decide which power-up to spawn
                    Instantiate(powerUps[0], new Vector3(Random.Range(-3, 3), 0.5f, transform.position.z + Random.Range(14, 19)), 
                    Quaternion.identity);
                }
                else
                {
                    Instantiate(powerUps[1], new Vector3(Random.Range(-3, 3), 0.5f, transform.position.z + Random.Range(14, 19)),
                    Quaternion.identity);
                }
            }*/
            else
            {
                Instantiate(enemy, new Vector3(Random.Range(-3, 3), 1.1f, transform.position.z + Random.Range(14, 19)), Quaternion.identity);
            }
        }
    }
}
