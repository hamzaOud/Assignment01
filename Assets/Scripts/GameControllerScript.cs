using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControllerScript : MonoBehaviour
{

    public bool isPlaying;
    public Player player;
    public float speed = 4.0f;
    public float elapsedTime = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime >= 10.0f && elapsedTime < 20.0f)
        {
            speed = 6.0f;
        }
        else if (elapsedTime >= 20.0f)
        {
            speed = 8.0f;
        }
    }

    private void OnGUI()
    {
        GUI.Label(new Rect(50,50,200,100), "Score:" + player.points);
        GUI.Label(new Rect(Screen.width - 200, 50, 200, 100), "High Score:" + PlayerPrefs.GetInt("HighScore"));

    }

    public void Die()
    {
        if (PlayerPrefs.GetInt("HighScore") < player.points)
        {
            PlayerPrefs.SetInt("HighScore", Mathf.RoundToInt(player.points));
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
