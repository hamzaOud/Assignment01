using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControllerScript : MonoBehaviour
{

    public bool isPlaying;
    public Player player;
    public float initialSpeed = 4.0f;
    public float speedIncrementRate = 2.0f;
    public float elapsedTime = 0.0f;
    public float speed;

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        updateSpeed();
    }

    void updateSpeed ()
    {
        speed = initialSpeed + speedIncrementRate * Mathf.Log(elapsedTime);
    }

    private void OnGUI()
    {
        GUI.contentColor = Color.red;
        GUI.Label(new Rect(50,50,200,100), "Score:" + player.points);
        GUI.Label(new Rect(Screen.width - 200, 50, 200, 100), "High Score:" + PlayerPrefs.GetInt("HighScore"));

    }

    public void Die()
    {
        if (PlayerPrefs.GetInt("Sound") == 1)
        {
            GetComponent<AudioSource>().Stop();
            GetComponent<AudioSource>().Play();
        }
        if (PlayerPrefs.GetInt("HighScore") < player.points)
        {
            PlayerPrefs.SetInt("HighScore", Mathf.RoundToInt(player.points));
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
