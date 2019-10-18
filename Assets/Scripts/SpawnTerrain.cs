using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SpawnItemInfo
{
    public GameObject item;
    public float weight;
    public float xRandomPosRange;
    public float zRandomPosRange;
    public float yOffset;

    public Vector3 GetRandomOffset()
    {
        return new Vector3(Random.Range(-xRandomPosRange, xRandomPosRange), yOffset, Random.Range(-zRandomPosRange, zRandomPosRange));
    }

}

public class SpawnTerrain : MonoBehaviour
{
    public SpawnItemInfo[] itemsToSpawn;

    public GameObject terrainPrefab;

    private GameControllerScript gameController;

    private float totalItemWeight;


    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameControllerScript>();
        //obstacle.transform.localScale = new Vector3(5, 1, 1);

        totalItemWeight = 0;
        foreach (SpawnItemInfo info in itemsToSpawn)
        {
            totalItemWeight += info.weight;
        }
    }

    // Update is called once per frame
    void Update()
    {
        /*if (gameController.elapsedTime > 10)
        {
            obstacle.transform.localScale = new Vector3(9, 2, 1);
        }*/
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Instantiate(terrainPrefab, new Vector3(0f, -0.5f, transform.position.z + 30), Quaternion.identity);

            float random = Random.Range(0, totalItemWeight);
            for (int i = 0; i < itemsToSpawn.Length; i++)
            {
                random = random - itemsToSpawn[i].weight;

                if (random <= 0)
                {
                    Vector3 itemPosition = transform.position + Vector3.forward * 30 + itemsToSpawn[i].GetRandomOffset();
                    Instantiate(itemsToSpawn[i].item, itemPosition, Quaternion.identity);
                    break;
                }
            }
        }
    }
}
