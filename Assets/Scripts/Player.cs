using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool isInvincible = false;
    public bool isDoublingPoints = false;
    public float doublePointTime = 5;
    public float invincibilityTime = 10;
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
        if (isDoublingPoints)
        {
            points += Time.deltaTime * 100;
            UpdateTimer(doublePointTime, ref doublePointsTimer, ref isDoublingPoints);
        }
        else
        {
            points += Time.deltaTime;
        }

        if (isInvincible)
        {
            UpdateTimer(invincibilityTime, ref invincibilityTimer, ref isInvincible);
        }
    }

    private void UpdateTimer(float maxTime, ref float timer, ref bool status)
    {
        if (timer < maxTime)
        {
            timer += Time.deltaTime;
        }
        else
        {
            timer = 0.0f;
            status = false;
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
