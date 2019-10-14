using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool isInvincible = false;
    public bool isDoublingPoints = false;
    private float invincibilityTimer = 0.0f;
    private float doublePointsTimer = 0.0f;
    public float points = 0;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (isDoublingPoints && doublePointsTimer < 5)
        {
            points += Time.deltaTime * 100;
            doublePointsTimer += Time.deltaTime;
        }
        else if (isDoublingPoints && doublePointsTimer >= 5)
        {
            doublePointsTimer = 0.0f;
            isDoublingPoints = false;
        }
        else
        {
            points += Time.deltaTime;
        }

        if (isInvincible && invincibilityTimer < 10)
        {
            invincibilityTimer += Time.deltaTime;
        }
        else if (isInvincible && invincibilityTimer >= 10)
        {
            invincibilityTimer = 0.0f;
            isInvincible = false;
        }
    }

    public void Invincible()
    {
        isInvincible = true;
        invincibilityTimer = 0.0f;
    }

    public void DoublePoints()
    {
        isDoublingPoints = true;
        doublePointsTimer = 0.0f;
    }

    private void OnGUI()
    {
        if (isInvincible)
        {
            GUI.contentColor = Color.yellow;
            GUI.Label(new Rect(50, 100, 200, 100), "Invincible!");
        }

        if(isDoublingPoints)
        {
            //float remainingTime = 5.0 - doublePointsTimer;
            GUI.contentColor = Color.red;
            GUI.Label(new Rect(50, 150, 200, 100), "2x points!");
        }
    }
}
