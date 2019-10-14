using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float speed = 4.0f;
    public GameControllerScript gameController;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

#if UNITY_EDITOR
        //Move character based on mouse's horizontal position
        transform.Translate(new Vector3((Input.mousePosition.x / Screen.width)*10 - 5, 0f, Time.deltaTime * gameController.speed));
#endif

#if UNITY_ANDROID
        transform.Translate(new Vector3(Input.acceleration.x, 0f, Time.deltaTime * gameController.speed));
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

        //if character is grounded and player presses space, make character jump
        if (isGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * 6.5f, ForceMode.Impulse);
        }

        if(Input.GetKeyDown(KeyCode.A))
        {
            transform.Rotate(new Vector3(0,-90,0), Space.Self);
        }
        if(Input.GetKeyDown(KeyCode.D))
        {
            transform.Rotate(new Vector3(0, 90, 0), Space.Self);
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
}
