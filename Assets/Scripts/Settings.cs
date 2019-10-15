using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public Toggle soundToggle;

    // Start is called before the first frame update
    void Start()
    { 
    }

    // Update is called once per frame
    void Update()
    {
        if (soundToggle.isOn)
        {
            PlayerPrefs.SetInt("Sound", 1);
        }
        else if (!soundToggle.isOn)
        {
            PlayerPrefs.SetInt("Sound", 0);
        }
    }

    public void resetHighScore()
    {
        PlayerPrefs.SetInt("HighScore", 0);
    }

    public void toggleSound()
    {

    }

    public void back()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }
}
