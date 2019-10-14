using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public Animator anim;
    float startTouchPosition, endTouchPosition;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            anim.SetBool("isRunning", false);
            anim.SetBool("isJumping", true);
            print(anim.GetCurrentAnimatorStateInfo(0).IsName("Jump").ToString());
        }


        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Jump") && anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        {
            anim.SetBool("isJumping", false);
            anim.SetBool("isRunning", true);
        }
    }
}

