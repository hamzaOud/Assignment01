﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HomeButtons : MonoBehaviour
{

    // Start is called before the first frame update
    public void play()
    {
        SceneManager.LoadScene("SampleScene",LoadSceneMode.Single);
    }
}
