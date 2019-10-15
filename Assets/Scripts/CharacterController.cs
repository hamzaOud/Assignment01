using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float speed = 4.0f;
    public GameControllerScript gameController;
    public Shoot shooter;

    private Touch touch;
    private Vector2 beginPosition = Vector2.zero;
    private Vector2 endPosition = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
        shooter = GetComponent<Shoot>();
    }

    // Update is called once per frame
    void Update()
    {

#if UNITY_EDITOR
        //Move character based on mouse's horizontal position
        //transform.Translate(new Vector3((Input.mousePosition.x / Screen.width)*10 - 5, 0f, Time.deltaTime * gameController.speed));
        transform.Translate(new Vector3(Input.GetAxis("Horizontal"), 0f, Time.deltaTime * gameController.speed));

        if (Input.GetMouseButtonDown(0))
        {
            shooter.shoot();
        }

        //if character is grounded and player presses space, make character jump
        if (isGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            jump();
        }
#endif

#if UNITY_ANDROID
        transform.Translate(new Vector3(Input.acceleration.x, 0f, Time.deltaTime * gameController.speed));

        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:

                    beginPosition = touch.position;
                    break;

                case TouchPhase.Ended:

                    endPosition = touch.position;

                    if(beginPosition == endPosition)
                    {
                        shooter.shoot();
                    }
                    else if (beginPosition!= endPosition)
                    {
                        if (endPosition.y - beginPosition.y > 100 && isGrounded())
                        {
                            jump();
                        }
                    }


                    break;

            }
        }
#endif

#if UNITY_IOS
        transform.Translate(new Vector3(Input.acceleration.x, 0f, Time.deltaTime * gameController.speed));
#endif

        //clamp values from -4 to 4
        if (transform.position.x < -4)
        {
            Vector3 newPos = new Vector3(-4f, transform.position.y, transform.position.z);
            transform.position = newPos;
        }
        else if (transform.position.x > 4)
        {
            Vector3 newPos = new Vector3(4f, transform.position.y, transform.position.z);
            transform.position = newPos;
        }

    }

    private bool isGrounded()
    {
        if (transform.position.y < 0.2)
        {
            return true;
        }
        else { return false; }
    }

    private void jump()
    {
        GetComponent<Rigidbody>().AddForce(Vector3.up * 6.5f, ForceMode.Impulse);
    }
}
