using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : Fighter
{
    [SerializeField] private LayerMask platformsLayerMask;
    private RaycastHit2D hit;
    protected float jumpVelocity = 3.0f;
    protected float xSpeed = 1.0f;
    private PlayerAnimation animPlayer;
    

    protected virtual void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        rigidbody = GetComponent<Rigidbody2D>();
        animPlayer = GetComponent<PlayerAnimation>();
    }

    private void Update()
    {
        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            animPlayer.Jump();
            rigidbody.velocity = Vector2.up * jumpVelocity;
            if (!IsGrounded())
                animPlayer.FallingDown(1);

        }

        if (!IsGrounded())
        {
            animPlayer.FallingDown(1);
        }
        else
            animPlayer.FallingDown(0);
     }


    protected virtual void UpdateMotor(Vector3 input)
    {
        //reset moveDelta
        moveDelta = new Vector3(input.x * xSpeed, input.y * jumpVelocity, 0);
        animPlayer.Move(input.x);
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
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0f, Vector2.down, .1f, platformsLayerMask);
        Debug.Log(raycastHit.collider);
        if(raycastHit.collider != null)
        {
            animPlayer.onGround(1);
            return true;
        }
        else
        {
            animPlayer.onGround(-1);
            return false;

        }
    }
}
