using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : Fighter
{
    private RaycastHit2D hit;
    protected float jumpVelocity = 3.0f;
    protected float xSpeed = 1.0f;

    protected virtual void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            rigidbody.velocity = Vector2.up * jumpVelocity;
        }
    }


    protected virtual void UpdateMotor(Vector3 input)
    {
        //reset moveDelta
        moveDelta = new Vector3(input.x * xSpeed, input.y * jumpVelocity, 0);

        //swap
        if (moveDelta.x > 0)
            transform.localScale = Vector3.one;
        else if (moveDelta.x < 0)
            transform.localScale = new Vector3(-1, 1, 1);

        // add push vector
        moveDelta += pushDirection;

        // reduce push force vere frame 
        pushDirection = Vector3.Lerp(pushDirection, Vector3.zero, pushRecoverySpeed);

        //màke sure we can move 
        

        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(moveDelta.x, 0), Mathf.Abs(moveDelta.x * Time.deltaTime), LayerMask.GetMask("Blocking", "Actor"));
        if (hit.collider == null)
        {
            //move
            transform.Translate(moveDelta.x * Time.deltaTime, 0, 0);

        }
    }

    protected bool IsGrounded()
    {
        return true;
    }
}
