using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void Move(float move)
    {
        anim.SetFloat("run", Mathf.Abs(move));
    }

    public void Jump()
    {
        anim.SetTrigger("jump");
    }

    public void FallingDown(float falling)
    {
        anim.SetFloat("fallingDown", Mathf.Abs(falling));

    }
    public void onGround(float onGround)
    {
        anim.SetFloat("onGround", Mathf.Abs(onGround));
    }
}
